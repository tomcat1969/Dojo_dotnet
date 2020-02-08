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
namespace TimeDisplay
{
    public class HomeController : Controller
    {
         [HttpGet("")]
        public ViewResult Home()
        {
            // This would be a case where we have to specify the file name
            DateTime CurrentTime = DateTime.Now;
            ViewBag.a = CurrentTime.ToString("f");




            return View();
        }

    }
       
}
