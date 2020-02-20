using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
         private MyContext dbContext;

         public HomeController (MyContext context)
         {
             dbContext = context;
         }
        public IActionResult Index()   //////////////////////////Index
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
            ViewBag.FirstName = the_user.FirstName;
            ViewBag.UserId = the_user.UserId;


            ////
            List<Event> allEventsFromDB = dbContext.Events
                                            .Include(e => e.Associations)
                                            .ThenInclude(a => a.User)
                                            .ToList();


            return View(allEventsFromDB);
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet("newEvent")]
        public IActionResult NewEvent()
        {   string email_from_session = HttpContext.Session.GetString("UserEmail");
            User userInDB = dbContext.Users.FirstOrDefault(u => u.Email == email_from_session);
            ViewBag.UserId = userInDB.UserId;
            return View("NewEvent");
        }

        public IActionResult AddEvent(Event eventSummission)
        {
            if(ModelState.IsValid)
            {
               dbContext.Add(eventSummission);
               dbContext.SaveChanges();
 
               return RedirectToAction("Success");
            }else{
                return View("NewEvent");
            }
        }

        [HttpGet("DeleteEvent/{EventId}")]
        public IActionResult DeleteEvent(int EventId)
        {
            Event the_event = dbContext.Events.SingleOrDefault(e => e.EventId == EventId);
            dbContext.Events.Remove(the_event);
            dbContext.SaveChanges();
            return RedirectToAction("Success");

        }

        [HttpGet("AddAssociation/{EventId}/{UserId}")]
        public IActionResult AddAssociation(int EventId,int UserId)
        {
            Association a = new Association();
            a.EventId = EventId;
            a.UserId = UserId;
            dbContext.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Success");

        }

        [HttpGet("DeleteAssociation/{EventId}/{UserId}")]
        public IActionResult DeleteAssociation(int EventId,int UserId)
        {
            Association a = dbContext.Associations.SingleOrDefault(ass => ass.EventId == EventId && ass.UserId == UserId);
            dbContext.Associations.Remove(a);
            dbContext.SaveChanges();
            return RedirectToAction("Success");
        }

        [HttpGet("eventDetails/{EventId}/{UserId}")]
        public IActionResult EventDetails(int EventId,int UserId)
        {
            Event the_event = dbContext.Events
                                .Include(e => e.Associations)
                                .ThenInclude(a => a.User)
                                .FirstOrDefault(e => e.EventId == EventId);

                                

            return View(the_event);
        }







/////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
