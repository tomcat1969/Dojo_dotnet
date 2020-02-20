
using System;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class Association
    {
            public int AssociationId { get; set; }
            public int UserId { get; set; }
            public int EventId { get; set; }
            public User User { get; set; }
            public Event Event { get; set; }
    }
}

