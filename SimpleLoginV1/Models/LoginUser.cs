using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleLoginV1.Models
{
    public class LoginUser
    {     
        [Required]
        [EmailAddress]

        public string Email {get;set;}
        [Required]

        public string Password {get;set;}

    }
}