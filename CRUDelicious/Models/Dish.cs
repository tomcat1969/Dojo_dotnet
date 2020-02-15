using System;
 using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
            public int DishId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string
            [Required]
            [MinLength(10)]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Chef 's Name:")]
            [MinLength(10, ErrorMessage = "!!Must be at least 10 chars long!!!!!")]
            public string Chef { get; set; }


            [Required]
            [Range(1,10)]

            public int Tastiness {get;set;}
            [Required]
             public int Calories {get;set;}
             [Required]
            public string Description { get; set;}
           
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} =DateTime.Now;
    }
}