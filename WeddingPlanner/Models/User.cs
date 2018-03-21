using System;
using System.Collections.Generic;
using WeddingPlanner;
using WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models

{
    public class User : BaseEntity

    {
        public int UserId {get; set;}
        public string First {get;set;}
        public string Last {get;set;}
        public string Email {get;set;}

        public string Password {get;set;}

        public List<Wedding> Weddings {get;set;}
        public List<RSVP> RSVPs {get;set;}

        public User()

        {
            RSVPs = new List<RSVP>();
        }

    }
}