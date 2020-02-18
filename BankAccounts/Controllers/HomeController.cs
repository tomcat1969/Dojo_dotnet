using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
         private MyContext dbContext;

         public HomeController (MyContext context)
         {
             dbContext = context;
         }
        public IActionResult Index()
        {
            return View();
        }

         public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email","Email already in use!");
                    return View("Index");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user,user.Password);


                dbContext.Add(user);
                dbContext.SaveChanges();

                //set the session
                HttpContext.Session.SetString("UserEmail",user.Email);
                var userInDB = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);


                return RedirectToAction("AccountDetail",new {id = userInDB.UserId});
            }else{
                return View("Index");
            }
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult DoLogin(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDB = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDB == null)
                {
                    ModelState.AddModelError("Email","Invalid Email");
                    return View("Login");
                } 
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission,userInDB.Password,userSubmission.Password);
                if(result == 0)
                {
                     ModelState.AddModelError("Email","Password does not match!");
                     return View("Login");
                }
                //set the session
                HttpContext.Session.SetString("UserEmail",userSubmission.Email);
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+HttpContext.Session.GetString("UserEmail"));
                return RedirectToAction("AccountDetail",new {id = userInDB.UserId});
            }else{
                return View("Login");
            }
            
            
        }

        public IActionResult AccountDetail(int id)
        {  
            Console.WriteLine("ooooooooooooooooooooooooooooooooooooo" +id);
            Console.WriteLine("ooooooooooooooooooooooooooooooooooooo" + HttpContext.Session.GetString("UserEmail"));
            User the_user = dbContext.Users.FirstOrDefault(u => u.UserId == id);
           if(the_user.Email != HttpContext.Session.GetString("UserEmail"))
           {
              return RedirectToAction("Login");
           }else{
               Wrapper wrapper = new Wrapper(); 
               wrapper.TransList = dbContext.Transactions.Include(t => t.Creator)
                                                        .Where(t => t.Creator.UserId == id).ToList();
                Decimal balance = 0;
               foreach(var e in wrapper.TransList)
               {
                    balance += e.Amount;
               }
               ViewBag.Balance = balance;

                ViewBag.The_User = dbContext.Users.FirstOrDefault(u => u.UserId == id);
               return View(wrapper);
           }


            
        }

        public IActionResult AddTransaction(Wrapper wrapper)
        {
            // Wrapper w = new Wrapper();
            // w = wrapper;
           //wrapper.oneTrans.UserId = 2;
            dbContext.Add(wrapper.oneTrans);
            dbContext.SaveChanges();

            return RedirectToAction("AccountDetail",new{id = wrapper.oneTrans.UserId });
        }


        ////////////////////////////////////////////////////////////

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
