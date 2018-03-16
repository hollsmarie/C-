using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace lostWoods.Models
{
    
    public abstract class BaseEntity{}
    
    public class Trail : BaseEntity
    {
        public int Id  {get;set;}
            

        [Required]
        [MinLength (3)]
        public string Name { get; set; }

        [Required]
        [MinLength (10)]
        public string Description { get; set; }


        [Required]
        [Range(0,1000000)]  
        public float Length { get; set; }

        [Required]
        [Range(0,1000000)]
        public float Elevation { get; set; }

        [Required]
        [Range(0,1000000)]
        public float Longitude {get;set;}


        [Required]
        [Range(0,1000000)]
        public float Latitude {get;set;}

    }
}