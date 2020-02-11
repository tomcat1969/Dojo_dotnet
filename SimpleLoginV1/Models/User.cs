using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleLoginV1.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]

        public string First_name {get;set;}

        [Required]
        [MinLength(2)]

        public string Last_name {get;set;}

        [Required]

        public string Password {get;set;}

         [Required]
         [Compare("Password",ErrorMessage ="Password and Confirm Password doesn't match.")]


        public string Comfirm_PW {get;set;}

        
        [Required]
        [EmailAddress]

        public string Email {get;set;}

    }
}