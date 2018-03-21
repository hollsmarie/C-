using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace bankAccounts.Models

{
    public class Transaction: BaseEntity

    {
        public int TransactionID{get;set;}
        public int UsersID{get;set;}

        public User user{get;set;}

        public double? Amount {get;set;}

        public DateTime Date {get;set;}
    }
}