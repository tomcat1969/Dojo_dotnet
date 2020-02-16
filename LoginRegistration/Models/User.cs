using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2)]
         public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
         public string LastName { get; set; }

         [EmailAddress]
         [Required]
         public string Email { get; set; }

         [DataType(DataType.Password)]
         [Required]
         [MinLength(8,ErrorMessage="Password must be 8 characters or longer!")]
         public string Password { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime
         public DateTime CreatedAt {get;set;} = DateTime.Now;
         public DateTime UpdatedAt {get;set;} = DateTime.Now;

         [NotMapped]
         [Compare("Password")]
         [DataType(DataType.Password)]
         public string Confirm{get;set;}
       
    }
}