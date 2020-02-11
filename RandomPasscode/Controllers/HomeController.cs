using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {

        private string getOnePasscode()
        {
            Random random = new Random();
            char[] array = new char[14];
            int count = 0;
            while (count < 14)
            {
                int temp = random.Next(48,90);
                if(temp < 58 || temp > 64) {
                    array[count] = (char)temp;
                    count++;
                }
            }
            StringBuilder builder = new StringBuilder();
            foreach (char val in array){
                builder.Append(val);
            }
            string result = builder.ToString();

            

            return result;
        }
        // [HttpGet("")]
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null) {
                HttpContext.Session.SetInt32("count", 0);
            }
            
            ViewBag.Passcode = getOnePasscode();
            ViewBag.count = count;

           
            return View();
        }

        [HttpGet("generate")]
        public IActionResult Generate()
        {
            System.Console.WriteLine("in generate route **************************");
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null) {
                HttpContext.Session.SetInt32("count", 0);
            }else {
                count++;
                HttpContext.Session.SetInt32("count",(int)count);
            }
            string passcode = getOnePasscode();
            return RedirectToAction("Index");
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            System.Console.WriteLine("in test route ****************");
            return RedirectToAction("Index");
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
