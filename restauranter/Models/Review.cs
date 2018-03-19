using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace restauranter.Models
{
    
    public abstract class BaseEntity{}
    
    public class Review : BaseEntity
    {
            
        public int ReviewID { get; set; }

        [Required]
        [MinLength (1)]
        public string ReviewName { get; set; }

        [Required]
        [MinLength (1)]
        public string RestName { get; set; }

        [Required]
        [MinLength (10)]
        public string Comment { get; set; }


        [Required]
        [PastDate]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0,5)]
        public int Stars { get; set; }

    }
}