using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNdishes.Models;
using Microsoft.EntityFrameworkCore;




namespace ChefsNdishes.Controllers
{
    public class HomeController : Controller
    {
         private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Chef> allChefs = dbContext.Chefs.Include(c => c.CreatedDishes).ToList();
            // List<Dish> dishesWithChef = dbContext.Dishes.Include(d => d.Creator).ToList();

            



            return View(allChefs);
        }


        [HttpGet("new")]
        public ViewResult NewChef()
        {
            
            
            return View("NewChef");

        }
        private int howOld(DateTime birthDay)
        {
            long elapseTicks = DateTime.Now.Ticks - birthDay.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapseTicks);
            return elapsedSpan.Days / 365;
        }

        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                int age = howOld(newChef.BirthDate);
                newChef.Age = age;


                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }else{
                return View("NewChef");
            }
            
        }
        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> allChefs = dbContext.Chefs.Include(c => c.CreatedDishes).ToList();
            ViewBag.AllChefs = allChefs;
            return View();

        }

        public IActionResult AddDish(Dish newDish)
        {
             if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }else{
                return View("NewDish");
            }
        }

        [HttpGet("Dishes")]
        public ViewResult Dishes()
        {
            List<Dish> dishesWithChef = dbContext.Dishes.Include(d => d.Creator).ToList();
            return View(dishesWithChef);
        }



        /////////////////////////////////
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
