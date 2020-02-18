using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNdishes.Models
{
    public class Dish
    {
         [Key]
         public int DishId {get;set;}
        [Required]
         public string DishName {get;set;}
         [Required]
         [Range(0,999999)]
         public int Calories {get;set;}
        [Required]
        [Range(0,6)]
         public int Tastiness {get;set;}

         [Required]
         public string Description {get;set;}
        
         public int ChefId {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;


         //Navigation property for related Chef object
         public Chef Creator {get;set;}



    }   

    
}