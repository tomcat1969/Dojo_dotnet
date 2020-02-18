using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BankAccounts.Models

{
    public class Wrapper
    {
        public User oneUser {get;set;}

        public List<User> UserList {get;set;}

        public Transaction oneTrans{get;set;}
        public List<Transaction> TransList{get;set;}

         

    }
}