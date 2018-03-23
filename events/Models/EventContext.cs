using Microsoft.EntityFrameworkCore;

namespace events.Models  //A DbContext instance represents a session with the database and can be used to query and save instances of your entities. 

{
    public class EventContext: DbContext

    {
        //this context is what actually sets tables in pgadmin
        public EventContext(DbContextOptions<EventContext>options) : base(options){}
        public DbSet<Event>Events {get;set;}
        public DbSet<User>Users {get;set;}
        public DbSet<RSVP> RSVPS {get;set;}

        public DbSet<Like> Likes {get;set;}
    }
}