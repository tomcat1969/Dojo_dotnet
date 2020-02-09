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


namespace OnePlusOne
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Home(string a,int b)
        {   ViewBag.a = a;
            ViewBag.b = b;
            return View();
        }


        [HttpPost]
        [Route("method")]
        // public string Method(string TextField, int NumberField)
        // {
        //     return "the combination is " + TextField + NumberField;
        // }    
        public IActionResult Method(string TextField, int NumberField)
            {
                return RedirectToAction("Home",new {a = TextField,b = NumberField});
            }

    }
}
