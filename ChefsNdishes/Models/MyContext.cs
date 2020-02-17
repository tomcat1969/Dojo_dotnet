using System;
using Microsoft.EntityFrameworkCore;

namespace ChefsNdishes.Models
{
    public class MyContext : DbContext
    {
         public MyContext(DbContextOptions options) : base(options) { }

         // "dishes" table is represented by this DbSet "Dishes"
            public DbSet<Dish> Dishes {get;set;}

            public DbSet<Chef> Chefs {get;set;}

    }   
}