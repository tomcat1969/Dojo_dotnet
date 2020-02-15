using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
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
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(d => d.CreatedAt).ToList();

            return View("Index", AllDishes);
        }

        [HttpGet("newdish")]
        public IActionResult NewDish()
        {   
                 return View();
             
            
        }
        [HttpPost("create")]
        public IActionResult CreateDish(Dish dish )
        {
            Console.WriteLine("^^^^^^^^^^^^^in createDish^^^^^^^^^^^^^^");
             if(ModelState.IsValid)
             {
                 dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
             }
                 Console.WriteLine("*******************************This part is working.");
                 return View("newdish");
            

        }
        [HttpGet("details/{dish_id}")]
        public IActionResult Details(int dish_id)
        {
            Dish the_dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dish_id);

            return View(the_dish);
        }
        [HttpGet("delete/{dish_id}")]
        public IActionResult Delete(int dish_id)
        {
            Dish the_dish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dish_id);
            dbContext.Dishes.Remove(the_dish);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet("edit/{dish_id}")]
        public IActionResult Edit(int dish_id)
        {
            Dish the_dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dish_id);

            Console.WriteLine("%%%%%%%%%%%%%%%%%%in Edit%%%%%%%%%%%%%%%%%%%%%"+ the_dish.Description);
            return View(the_dish);

        }
        [HttpPost("modify")]
        public IActionResult Modify(Dish dish)
        {
            Console.Write(dish.Name + "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            Dish the_dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dish.DishId);
            Console.Write(dish.Description + "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            the_dish.Name = dish.Name;
            the_dish.Chef = dish.Chef;
            the_dish.Calories = dish.Calories;
            the_dish.Tastiness = dish.Tastiness;
            the_dish.Description = dish.Description;
            the_dish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        /////////////////////////////////////////////////////
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
