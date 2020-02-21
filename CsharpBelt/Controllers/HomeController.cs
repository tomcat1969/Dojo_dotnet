using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CsharpBelt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CsharpBelt.Controllers
{
    public class HomeController : Controller
    {
         private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(Wrapper w)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == w.oneUser.Email))
                {
                    ModelState.AddModelError("Email","Email already in use!");
                    return View("Index");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                 w.oneUser.Password = Hasher.HashPassword( w.oneUser, w.oneUser.Password);


                dbContext.Add( w.oneUser);
                dbContext.SaveChanges();

                //set the session
                HttpContext.Session.SetString("UserEmail", w.oneUser.Email);



                return RedirectToAction("Success");
            }else{
                return View("Index");
            }
        }


        public IActionResult DoLogin(Wrapper w)
        {
            if(ModelState.IsValid)
            {
                var userInDB = dbContext.Users.FirstOrDefault(u => u.Email == w.oneLoginUser.Email);
                if(userInDB == null)
                {
                    ModelState.AddModelError("Email","Invalid Email");
                    return View("Index");
                } 
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(w.oneLoginUser,userInDB.Password,w.oneLoginUser.Password);
                if(result == 0)
                {
                     ModelState.AddModelError("Email","Password does not match!");
                     return View("Index");
                }
                //set the session
                HttpContext.Session.SetString("UserEmail",w.oneLoginUser.Email);
                return RedirectToAction("Success");
            }else{
                return View("Index");
            }
            
            
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            // List<User> AllUsers = dbContext.Users.ToList();

            //greetings for login user
            string email_from_session = HttpContext.Session.GetString("UserEmail");
            if(email_from_session == null) return RedirectToAction("Index");

            User the_user = dbContext.Users.FirstOrDefault(u => u.Email == email_from_session);
            ViewBag.Name = the_user.Name;
            ViewBag.UserId = the_user.UserId;


            ////
            List<DojoActivity> allActivitiesFromDB = dbContext.DojoActivities
                                            .Where(a => a.CreatedAt > DateTime.Now)
                                            .OrderByDescending(a => a.Creator)
                                            .Include(e => e.Creator)
                                            .Include(e => e.Associations)
                                            .ThenInclude(a => a.User)
                                            .ToList();


            return View(allActivitiesFromDB);
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("newActivity")]
        public IActionResult NewActivity()
        {
            string email_from_session = HttpContext.Session.GetString("UserEmail");
            User userInDB = dbContext.Users.FirstOrDefault(u => u.Email == email_from_session);
            ViewBag.UserId = userInDB.UserId;
            return View("NewActivity");
        }

         public IActionResult AddDojoActivity(DojoActivity activitySummission)
        {
            Console.WriteLine(activitySummission.Time + "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            if(ModelState.IsValid)
            {
                Console.WriteLine("*********************1*******************");
               dbContext.Add(activitySummission);
               dbContext.SaveChanges();
 
               return RedirectToAction("Success");
            }else{
                Console.WriteLine("*********************2*******************");
                return View("NewActivity");
            }
        }

        ////////////////
         [HttpGet("DeleteDojoActivity/{DojoActivityId}")]
        public IActionResult DeleteDojoActivity(int DojoActivityId)
        {
            DojoActivity the_activity = dbContext.DojoActivities.SingleOrDefault(e => e.DojoActivityId == DojoActivityId);
            dbContext.DojoActivities.Remove(the_activity);
            dbContext.SaveChanges();
            return RedirectToAction("Success");

        }

        [HttpGet("AddAssociation/{DojoActivityId}/{UserId}")]
        public IActionResult AddAssociation(int DojoActivityId,int UserId)
        {
            Association a = new Association();
            a.DojoActivityId = DojoActivityId;
            a.UserId = UserId;
            dbContext.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Success");

        }

        [HttpGet("DeleteAssociation/{DojoActivityId}/{UserId}")]
        public IActionResult DeleteAssociation(int DojoActivityId,int UserId)
        {
            Association a = dbContext.Associations.SingleOrDefault(ass => ass.DojoActivityId == DojoActivityId && ass.UserId == UserId);
            dbContext.Associations.Remove(a);
            dbContext.SaveChanges();
            return RedirectToAction("Success");
        }

        [HttpGet("activityDetails/{DojoActivityId}/{UserId}")]
        public IActionResult ActivityDetails(int DojoActivityId,int UserId)
        {
            DojoActivity the_activity = dbContext.DojoActivities
                                .Include(a => a.Creator)
                                .Include(e => e.Associations)
                                .ThenInclude(a => a.User)
                                .FirstOrDefault(e => e.DojoActivityId == DojoActivityId);

             ViewBag.UserId = UserId;                   

            return View(the_activity);
        }







///////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
