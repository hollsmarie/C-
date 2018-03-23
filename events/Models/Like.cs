using System;

namespace events.Models

{
    public class Like:BaseEntity

    {
        public int LikeId {get;set;}
        public int UserId {get;set;}

        public User User {get;set;}  //create object of User type named User. For queries only, not placed in DB
        public int EventId {get;set;}

        public Event Event {get;set;}

        public Like()  //constructor class

        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}