using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BankAccounts.Models

{
    public class Transaction
    {
        [Key]
         public int TransactionId {get;set;}

         public Decimal Amount {get;set;}

         public DateTime CreatedAt {get;set;} = DateTime.Now;
         public DateTime UpdatedAt {get;set;} = DateTime.Now;

         public int UserId {get;set;}

         public User Creator {get;set;}

         

    }
}