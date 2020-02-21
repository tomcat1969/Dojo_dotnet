using System;
using Microsoft.EntityFrameworkCore;

namespace CsharpBelt.Models
{
   public class Association
    {
            public int AssociationId { get; set; }
            public int UserId { get; set; }
            public int DojoActivityId { get; set; }
            public User User { get; set; }
            public DojoActivity DojoActivity { get; set; }
    }
}