using System;

namespace events.Models

{
    public class RSVP:BaseEntity

    {
        public int RSVPid {get;set;}
        public int UserId {get;set;}

        public User User {get;set;}  //create object of User type named User. For queries only, not placed in DB
        public int EventId {get;set;}

        public Event Event {get;set;}

        public RSVP()  //constructor class

        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}