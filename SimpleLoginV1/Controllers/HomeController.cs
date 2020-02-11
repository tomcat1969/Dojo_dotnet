using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginV1.Models;

namespace SimpleLoginV1.Controllers
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
        /////////////////////////////////////////////////////

        [HttpPost("/create/user")]
        public IActionResult CreateUser(User newUser)       
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }  


        [HttpPost("/login/user")]
        public IActionResult LoginUser(LoginUser newUser)    
        {

            Console.WriteLine("###########################");
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");   
        }

        [HttpGet("success")]
        public string Success()
        {
            return "You have successfully submitted!";
        }





        ////////////////////////////////////////////////////
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
