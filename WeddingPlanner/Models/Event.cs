using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Event
    {
        [Key]
        public int EventId {get;set;}

        [Required]
        [MinLength(2)]
         public string WedderOne { get; set; }

        [Required]
        [MinLength(2)]
         public string WedderTwo { get; set; }

        [Required]
        [FutureDate]
         public DateTime Date {get;set;}

         [Required]
         [MinLength(2)]
         public string Address{get;set;}

         public int UserId {get;set;}
         public DateTime CreatedAt {get;set;} = DateTime.Now;
         public DateTime UpdatedAt {get;set;} = DateTime.Now;

         
       public List<Association> Associations {get;set;} // naivagation property for many to many

       

       public User Creator {get;set;}
       
    }


    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!
            DateTime convertedValue = Convert.ToDateTime(value);
            DateTime now = DateTime.Now;

            Console.WriteLine("****************"+ convertedValue);
             Console.WriteLine("****************"+ now);

            if(convertedValue <= now)
                return new ValidationResult("should be in the future!");
                 
            return ValidationResult.Success;


        }
    }
}
