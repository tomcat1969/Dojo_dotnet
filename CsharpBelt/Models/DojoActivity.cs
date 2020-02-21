using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CsharpBelt.Models
{
    public class DojoActivity
    {
        [Key]
        public int DojoActivityId {get;set;}

        [Required]
        
         public string Title { get; set; }

         
         
         public DateTime Date {get;set;}

        
         [FutureTime]
         public DateTime Time {get;set;}

         [Required]
         public string Description {get;set;}

       
        public int Duration {get;set;}
        
        public string DurationUnit {get;set;}


         public int UserId {get;set;}
            // The MySQL DATETIME type can be represented by a DateTime
         public DateTime CreatedAt {get;set;} = DateTime.Now;
         public DateTime UpdatedAt {get;set;} = DateTime.Now;

         


         public List<Association> Associations {get;set;}// naivagation property for many to many

         public User Creator {get;set;} // naivagation property for one to many
    }




    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!
            DateTime convertedValue = Convert.ToDateTime(value);
            DateTime now = DateTime.Now;

            Console.WriteLine("********date********"+ convertedValue);
             Console.WriteLine("********now ********"+ now);

            if(convertedValue < now)
                return new ValidationResult("should be in the future!");
            Console.WriteLine("***********date is in future ****yes");     
            return ValidationResult.Success;


        }
    }

    public class FutureTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!
            DateTime convertedValue = Convert.ToDateTime(value);
            DateTime now = DateTime.Now;

            Console.WriteLine("*******time submit*********"+ convertedValue);
             Console.WriteLine("****************"+ now);

            if(convertedValue < now)
                return new ValidationResult("time should be in the future!");
            Console.WriteLine("***********date is in future ****yes");     
            return ValidationResult.Success;


        }
    }
}