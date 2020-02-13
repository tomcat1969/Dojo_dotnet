using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LingQdemo.Models;

namespace LingQdemo.Controllers
{
    public class HomeController : Controller
    {
       Dojodachi mypet = new Dojodachi();

        
        public IActionResult Index()
        {


            Product[] myProducts = new Product[]
            {
                new Product { Name = "Jeans", Category = "Clothing", Price = 24.7 },
                new Product { Name = "Socks", Category = "Clothing", Price = 8.12 },
                new Product { Name = "Scooter", Category = "Vehicle", Price = 99.99 },
                new Product { Name = "Skateboard", Category = "Vehicle", Price = 24.99 },
                new Product { Name = "Skirt", Category = "Clothing", Price = 17.5 }
            };
            IEnumerable<Product> orderedProducts = myProducts.OrderByDescending(prod => prod.Price);
            IEnumerable<Product> justClothings = myProducts.Where(pro => pro.Category == "Clothing");
            
            Product justJeans = myProducts.FirstOrDefault(prod => prod.Name == "Jeans");
            ViewBag.p1 =  justJeans.Name;
            return View(justClothings);
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
