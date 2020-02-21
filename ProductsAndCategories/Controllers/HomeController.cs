using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("categories");
        }


        [HttpGet("products")]
        public IActionResult Products()
        {
             Wrapper wrapper = new Wrapper(); 
             wrapper.Products = dbContext.Products.ToList();
             return View(wrapper);
        }

        public IActionResult AddProduct(Wrapper wrapper)
        {
            dbContext.Add(wrapper.oneProduct);
            dbContext.SaveChanges();
            return RedirectToAction("Products");
        }


        
        [HttpGet("categories")]
        public IActionResult Categories()
        {
             Wrapper wrapper = new Wrapper(); 
             wrapper.Categories = dbContext.Categories.ToList();
             return View(wrapper);
        }

        public IActionResult AddCategory(Wrapper wrapper)
        {
            dbContext.Add(wrapper.oneCategory);
            dbContext.SaveChanges();
            return RedirectToAction("Categories");
        }


        [HttpGet("products/{productId}")]
        public IActionResult Product(int productId)
        {
            Wrapper w = new Wrapper();
            w.oneProduct = dbContext.Products
                            .Include(p => p.Categories)
                            .ThenInclude(c => c.Category)
                            .FirstOrDefault(p => p.ProductId == productId);
            w.Categories = dbContext.Categories
                            .Include(c => c.Products)
                            .Where(c => c.Products.All(a => a.ProductId != productId)).ToList();

            return View(w);
        }

        public IActionResult AddCforP(Association a)
        {
            
            
            
            // a.Product = w.oneProduct;
            // a.Category = w.oneCategory;
            dbContext.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Product",new{productId = a.ProductId});
        }


        [HttpGet("category/{categoryId}")]
        public IActionResult Category(int categoryId)
        {
            ViewBag.the_category = dbContext.Categories
                                    .Include(c => c.Products)
                                    .ThenInclude(a => a.Product)
                                    .FirstOrDefault(p => p.CategoryId == categoryId);
            ViewBag.the_products_excluded = dbContext.Products
                                            .Include(p => p.Categories)
                                            .ThenInclude(a => a.Product)
                                            .Where(a => a.Categories.All(p => p.CategoryId != categoryId))
                                            .ToList();                        
            return View("Index");

        }
        public IActionResult AddPforC(Association a)
        {
             dbContext.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Category",new{categoryId = a.CategoryId});
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            Wrapper w = new Wrapper();
            w.oneProduct = dbContext.Products
                           .Include(p => p.Categories)
                           .ThenInclude(a => a.Category)
                           .FirstOrDefault(p => p.ProductId == 1);
            // Association ass = new Association();
            // ass.ProductId = 1;
            // ass.CategoryId = 4;
            // dbContext.Add(ass);
            // dbContext.SaveChanges();



        

            return View(w);
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
