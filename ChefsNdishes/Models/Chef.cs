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
         [FutureDate]
         [Greater18]
         public DateTime BirthDate {get;set;}

         public int Age{get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

         // Navigation property for related Dishes objects
         public List<Dish> CreatedDishes {get;set;}



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

            if(convertedValue >= now)
                return new ValidationResult("birth day should be in the past!");
                 
            return ValidationResult.Success;


        }
    }

     public class Greater18Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!
            DateTime convertedValue = Convert.ToDateTime(value);
            int age = howOld(convertedValue);

            if(age < 18)
                return new ValidationResult("Age should greater then 18 years old!");
                 
            return ValidationResult.Success;


        }

        private int howOld(DateTime birthDay)
        {
            long elapseTicks = DateTime.Now.Ticks - birthDay.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapseTicks);
            return elapsedSpan.Days / 365;
        }
    }
}