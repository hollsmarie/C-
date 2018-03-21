using System;
using System.Collections.Generic;

namespace bankAccounts.Models

{
    public class User : BaseEntity

    {
        public int UsersID {get; set;}
        public string First {get;set;}
        public string Last {get;set;}
        public string Email {get;set;}

        public string Password {get;set;}

        public double? Balance {get;set;}

        public List<Transaction> Transactions {get;set;}

        public User()

        {
            Transactions = new List<Transaction>();
        }
    }
}