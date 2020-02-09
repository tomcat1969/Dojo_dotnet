using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcDemo1.Models;


namespace MvcDemo1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

         public IActionResult Names()
            {
                // to a View that has defined a model as @model string[]
                string[] names = new string[]
                {
                "Sally", "Billy", "Joey", "Moose"
                };
                return View(names);
            }

         public IActionResult Message()
         {
             string msg = "this is a message !!";
             //ViewBag.msg = msg;
             return View(msg);
         }    

        public IActionResult Numbers()
        {
            int[] numbers = new int[]{1,2,3,4,5,6};
            return View(numbers);
        }

        public IActionResult Users()
        {
            List<User> users = new List<User>(){
                new User{
                    FirstName = "lin",
                    LastName = "Huang"
                },
                new User{
                    FirstName = "lin2",
                    LastName = "Huang"
                },
                new User{
                    FirstName = "lin3",
                    LastName = "Huang"
                }
            };

            return View(users);

        }


        public IActionResult User()
        {
            User user = new User(){
                FirstName = "Marry",
                LastName = "Wood"
            };
            return View(user);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
