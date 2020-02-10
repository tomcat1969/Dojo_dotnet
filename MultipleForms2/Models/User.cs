using System;
using System.ComponentModel.DataAnnotations;
public class User
{
    [Required]
    public string Username {get;set;}
    [Required]
    public int Age {get;set;}
}

