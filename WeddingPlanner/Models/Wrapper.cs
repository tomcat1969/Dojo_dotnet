using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wrapper
    {
        public User oneUser{get;set;}
        public List<User> users{get;set;}
        public Event oneEvent {get;set;}
        public List<Event> events{get;set;}

        public Association oneAssociation{get;set;}

        public List<Association> associations{get;set;}
        public LoginUser oneLoginUser{get;set;}
    }
}