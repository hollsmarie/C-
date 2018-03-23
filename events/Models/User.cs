using System;
using System.Collections.Generic;
using events.Models;
using events;
using System.ComponentModel.DataAnnotations;

namespace events.Models  //this model is all the fields to be passed into the DB.

{
    public class User : BaseEntity
    {
        public int UserId {get;set;}
        public string First {get;set;}
        public string Last {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}

        public List<Like> Likes {get;set;}

        public List<RSVP> RSVPS {get;set;} //creating a blueprint list type of RSVP called RSVP to use as a join table
        public User() //constructor class
        {
            Likes = new List<Like>();
            RSVPS = new List<RSVP>();  //instantiating rsvps as a new list of RSVP type
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}