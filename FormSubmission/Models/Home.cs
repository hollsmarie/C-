using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace FormSubmission.Models
{
    
    public abstract class BaseEntity{}
    
    public class User : BaseEntity
    {
        [Required]
        [MinLength (3)]
        public string First { get; set; }

        [Required]
        [MinLength (3)]
        public string Last { get; set; }

        [Required]
        [Range (0, 120, ErrorMessage="Must input a number for age.")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength (8)]
        public string Password { get; set; }
    }
}