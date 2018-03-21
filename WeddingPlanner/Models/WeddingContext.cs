using Microsoft.EntityFrameworkCore;
using System;
using WeddingPlanner;
using WeddingPlanner.Models;
using System.Linq; 


namespace WeddingPlanner.Models

{
    public class WeddingContext : DbContext

    {
        public WeddingContext(DbContextOptions<WeddingContext>options) : base(options) {}
        public DbSet<User> Users {get;set;}

        public DbSet<RSVP> RSVP {get;set;}
        public DbSet<Wedding> Weddings {get;set;}

    }
}