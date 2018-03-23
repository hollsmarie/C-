using System;
using System.Collections.Generic;
using events.Models;
using events;
using System.ComponentModel.DataAnnotations;

namespace events.Models  //this model is all the fields to be passed into the DB.

{
    public class Event : BaseEntity
    {
        public int EventId {get;set;}

        [Required]
        public string Host {get;set;}

        [Required(ErrorMessage="Title field cannot be blank.")]
        public string Title {get;set;}

        [Required(ErrorMessage="Description field cannot be blank.")]
        [MinLength(10,ErrorMessage="Description must be at least 10 characters.")]
        public string Description {get;set;}

        [Required]
        [PastDate (ErrorMessage="Date must be in the future.")]
        public DateTime? Date {get;set;}

        [Required]
        public string Address {get;set;}

        public int UserId {get;set;} //id of event creator

        public List<Like> Likes {get;set;}

        public List<RSVP> RSVPS {get;set;} //creating a blueprint list type of RSVP called RSVP to use as a join table
        public Event() //constructor class
        {
            Likes = new List<Like>();
            RSVPS = new List<RSVP>();  //instantiating rsvps as a new list of RSVP type
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}