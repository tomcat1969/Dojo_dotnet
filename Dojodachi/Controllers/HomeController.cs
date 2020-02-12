using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index(string str)
        {
            

            int?  Happiness = HttpContext.Session.GetInt32("Happiness");
            int?  Fullness = HttpContext.Session.GetInt32("Fullness");
            int?  Energy = HttpContext.Session.GetInt32("Energy");
            int?  Meals = HttpContext.Session.GetInt32("Meals");
            if (Happiness == null) {
                HttpContext.Session.SetInt32("Happiness", 20);
            }
            if (Fullness == null) {
                HttpContext.Session.SetInt32("Fullness", 20);
            }
            if (Energy == null) {
                HttpContext.Session.SetInt32("Energy", 50);
            }
            if (Meals  == null) {
                HttpContext.Session.SetInt32("Meals", 3);
            
            }
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? meals = HttpContext.Session.GetInt32("Meals");

            
            
            ViewBag.Display = $"Fullness : {fullness}     Happiness : {happiness}       Meals : {meals}      Energy : {energy}";
            ViewBag.Log = str;
            
            return View();
        }
       
        [HttpGet("feed")]

        public RedirectToActionResult Feed()
        {
            int? meals = HttpContext.Session.GetInt32("Meals");
            int? fullness = HttpContext.Session.GetInt32("Fullness");

            Random random = new Random();
            string log = "";
            if(meals <= 0) 
            {
                log =  "you have no meals,so can not feed you Dojodochi";
            }
            else if(random.Next(0,4) == 1) 
            {
                
                int amount = random.Next(6,11);
                meals -= 1;  
                HttpContext.Session.SetInt32("Meals",(int)meals);
                fullness += amount;
                HttpContext.Session.SetInt32("Fullness", (int)fullness);
                log =  $"You feed you Dojodochi ! Fullness + {amount} , Meals - 1";
            }else{
                meals -= 1;  
                HttpContext.Session.SetInt32("Meals",(int)meals);
                log = $"You feed you Dojodochi ! Fullness + 0 , Meals - 1";
            }
            
            return RedirectToAction("Index", new { str=log });   //new { key=log }



        }

        [HttpGet("play")]

        public RedirectToActionResult Play()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? happiness = HttpContext.Session.GetInt32("Happiness");

            Random random = new Random();
            string log = "";
            
            if(random.Next(0,4) == 1) 
            {
                
                int amount = random.Next(6,11);
                energy -= 5;  
                HttpContext.Session.SetInt32("Energy",(int)energy);
                happiness += amount;
                HttpContext.Session.SetInt32("Happiness", (int)happiness);
                log =  $"You feed you Dojodochi ! Happiness + {amount} , Meals - 1";
            }else{
                 energy -= 5;  
                HttpContext.Session.SetInt32("Energy",(int)energy);
                log = $"You feed you Dojodochi ! Fullness + 0 , Meals - 1";
            }
            
            return RedirectToAction("Index", new { str=log });  



        }

        

         [HttpGet("working")]

        public RedirectToActionResult Working()
        {
            int? meals = HttpContext.Session.GetInt32("Meals");
            int? energy = HttpContext.Session.GetInt32("Energy");

            Random random = new Random();
            int amount = random.Next(1,4);
            meals += amount;
            energy -= 5;
            HttpContext.Session.SetInt32("Meals",(int)meals);
            HttpContext.Session.SetInt32("Energy",(int)energy);
            string log = $" your Dojodochi work ! Meals + {amount} , Energy - 5 !";
            return RedirectToAction("Index", new { str=log });     
        }
            //      this.Energy += 15;
            // this.Fullness -= 5;
            // this.Happiness -= 5;
            // return $" your Dojodochi slept! Fullness - 5 , Happiness - 5 , Energy + 15 !";

            [HttpGet("sleeping")]

            public RedirectToActionResult sleeping()
            {
                int? happiness = HttpContext.Session.GetInt32("Happiness");
                int? energy = HttpContext.Session.GetInt32("Energy");
                int? fullness = HttpContext.Session.GetInt32("Fullness");
                energy += 15;
                fullness += 5;
                happiness -= 5;
                HttpContext.Session.SetInt32("Energy",(int)energy);
                HttpContext.Session.SetInt32("Happiness", (int)happiness);
                HttpContext.Session.SetInt32("Fullness", (int)fullness);
                string log = $" your Dojodochi slept! Fullness - 5 , Happiness - 5 , Energy + 15 !";
                return RedirectToAction("Index", new { str=log });     
            }








        ////////////////////////////////////////////////////////////////////////////////////////////

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
