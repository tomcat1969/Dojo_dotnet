using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleForms2.Models;

namespace MultipleForms2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create/product")]
        public IActionResult CreateProduct(IndexViewModel modelData)
        {
            // To get the submitted Product from the submission, 
            // we would just need to grab "NewProduct" from the modelData object
            Product submittedProduct = modelData.NewProduct;
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }


        [HttpPost("create/user")]
        public IActionResult CreateUser(IndexViewModel modelData)
        {
            // To get the submitted User from the submission, 
            // we would just need to grab "NewUser" from the modelData object
            User submittedUser = modelData.NewUser;
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



        //////////////////////////////////////////////

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
