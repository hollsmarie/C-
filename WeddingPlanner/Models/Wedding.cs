using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models

{
    public class Wedding : BaseEntity
    {

        public int WeddingId {get;set;}

        
        public string WedderOne {get; set;}

        
        public string WedderTwo  {get;set;}

        public DateTime WeddingDate {get;set;}

        
        public string Address {get;set;}


        public int UserId { get; set; } //id of the wedding creator
        public User User { get; set; }
        public List<RSVP> RSVPs { get; set; }
        public Wedding()
        {
            RSVPs = new List<RSVP>();
        }
    }
}