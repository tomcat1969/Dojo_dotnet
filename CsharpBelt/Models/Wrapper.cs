using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CsharpBelt.Models
{
    public class Wrapper
    {
        public User oneUser{get;set;}
        public List<User> users{get;set;}
        public DojoActivity oneDojoActivity {get;set;}
        public List<DojoActivity> DojoActivities{get;set;}

        public Association oneAssociation{get;set;}

        public List<Association> associations{get;set;}
        public LoginUser oneLoginUser{get;set;}
    }
}