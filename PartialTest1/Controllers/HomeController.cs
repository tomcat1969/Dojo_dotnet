using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartialTest1.Models;

namespace PartialTest1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentTime = DateTime.Now;
            ViewBag.Message = "the time is ";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.CurrentTime = DateTime.Now;
            ViewBag.Message = "the time is ";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
