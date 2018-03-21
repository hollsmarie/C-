using Microsoft.EntityFrameworkCore;
using bankAccounts.Models;
using bankAccounts.Controllers;
 
namespace bankAccounts.Models
{
    public class BankContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users {get;set;}
    }
}