using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ChefsNdishes.Models
{
    public class Chef
    {
         [Key]
         public int ChefId {get;set;}

        [Required]

         public string FirstName {get;set;}

         [Required]
         public string LastName {get;set;}
         [Required]   
         public DateTime BirthDate {get;set;}

         public int Age{get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

         // Navigation property for related Dishes objects
         public List<Dish> CreatedDishes {get;set;}



    }   
}