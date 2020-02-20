using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
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


         public List<Association> Associations {get;set;}// naivagation property for many to many

         public List<Event> CreatedEvents {get;set;} // naivagation property for one to many
       
    }
}
