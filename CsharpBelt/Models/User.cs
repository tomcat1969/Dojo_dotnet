using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CsharpBelt.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2)]
         public string Name { get; set; }


         [EmailAddress]
         [Required]
         public string Email { get; set; }

         [DataType(DataType.Password)]
         [Required]
         [MinLength(8,ErrorMessage="Password must be 8 characters or longer!")]
         [StrongPW]
         public string Password { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime
         public DateTime CreatedAt {get;set;} = DateTime.Now;
         public DateTime UpdatedAt {get;set;} = DateTime.Now;

         [NotMapped]
         [Compare("Password")]
         [DataType(DataType.Password)]
         public string Confirm{get;set;}


         public List<Association> Associations {get;set;}// naivagation property for many to many

         public List<DojoActivity> CreatedDojoActivities {get;set;} // naivagation property for one to many
    }

    //        /^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$/

    public class StrongPWAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!
            string str_submit = Convert.ToString(value);
            char[] array = str_submit.ToCharArray();
            bool isHasNumber = false;
            bool isHaschar = false;
            bool isHasSpe = false;
            foreach(char ele in array)
            {
                if((int)ele >= 48 && (int)ele <= 57 ) isHasNumber = true;
                if((int)ele >= 32 && (int)ele <= 47 
                    || (int)ele >= 58 && (int)ele <= 64
                    || (int)ele >= 91 && (int)ele <= 96
                    || (int)ele >= 123 && (int)ele <= 127) isHasSpe = true;
                if((int)ele >= 65 && (int)ele<=122) isHaschar = true;    


            }
            if(isHaschar && isHasNumber && isHasSpe) 
            {return ValidationResult.Success;}

            return new ValidationResult("should be has a number or char or specal char!");

            

            


        }
    }
}