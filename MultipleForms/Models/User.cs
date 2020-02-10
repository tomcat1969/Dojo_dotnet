using System;
using System.ComponentModel.DataAnnotations;

namespace MultipleForms.Models
{
    public class User
    {
        [Required]
        public string Username {get;set;}
        [Required]
        public int Age {get;set;}
    }


}