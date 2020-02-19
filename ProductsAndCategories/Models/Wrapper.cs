using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class Wrapper
    {
        public Product oneProduct {get;set;}

        public List<Product> Products{get;set;}

        public Category oneCategory{get;set;}

        public List<Category> Categories{get;set;}

    }
}