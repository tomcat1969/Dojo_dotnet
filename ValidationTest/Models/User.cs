using System.ComponentModel.DataAnnotations;
namespace ValidationTest.Models
{
    public class User
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Your Username:")] 
        public string Username { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }// Class definition
    }
}
