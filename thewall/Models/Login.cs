using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace thewall.Models
{
    
    public abstract class BaseEntity{}
    
    public class User : BaseEntity
    {
        [Required]
        [MinLength (3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string First { get; set; }

        [Required]
        [MinLength (3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string Last { get; set; }

        [Required]
        [EmailAddress]
        //WHAT IS THE EMAIL REGEX?????
        public string Email { get; set; }

        [Required]
        [MinLength (8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string Confirm {get;set;}



    }

    public class LogUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

    }
}