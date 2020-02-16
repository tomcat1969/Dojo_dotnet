using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace LoginRegistration.Controllers
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



                return RedirectToAction("Success");
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
                return RedirectToAction("Success");
            }else{
                return View("Login");
            }
            
            
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            List<User> AllUsers = dbContext.Users.ToList();

            //greetings for login user
            string email_from_session = HttpContext.Session.GetString("UserEmail");
            if(email_from_session == null) return RedirectToAction("Login");

            User the_user = dbContext.Users.FirstOrDefault(u => u.Email == email_from_session);
            ViewBag.FirstName = the_user.FirstName;




            return View(AllUsers);
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

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
