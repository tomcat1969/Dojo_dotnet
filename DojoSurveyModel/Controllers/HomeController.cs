using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyModel.Models;

namespace DojoSurveyModel.Controllers
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


        //////////////////////////////////////////
        [HttpPost("result")]
        public IActionResult ProcessSurvey(string name,string location,string language,string comment)
        {
            Survey s1 = new Survey();
            s1.Name = name;
            s1.Location = location;
            s1.Language = language;
            s1.Comment = comment;
            Console.WriteLine("%%%%%%" + location);
            Console.WriteLine("$$$$$$$$$"+language);
            Console.WriteLine("$$$$$$$$$"+s1.Language);
            return RedirectToAction("Result",s1);
        }

        public IActionResult Result(Survey s1)
        {
            return View(s1);        
        }




        //////////////////////////////////////////

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
