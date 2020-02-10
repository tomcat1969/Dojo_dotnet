using System;
using System.ComponentModel.DataAnnotations;

namespace MultipleForms.Models
{
    public class Product
    {
        [Required]
        [Display(Name="Product Name")]
        public string ProductName {get;set;}
        [Required]
        public double Price {get;set;}
    }
}