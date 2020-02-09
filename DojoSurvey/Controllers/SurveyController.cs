using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class SurveyController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("backend")]

        public  RedirectToActionResult Backend(string name,string location,string language,string comment)
        {
            return RedirectToAction("Result", new{name=name,location =location , language = language, comment = comment});
        }





        [HttpGet("result")]
        public ViewResult Result(string name,string location,string language,string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View();

        }



    }   
       
}
