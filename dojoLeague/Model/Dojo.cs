using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace dojoLeague.Models
{
    
    public abstract class BaseEntity{}
    
    public class Dojo : BaseEntity
    {
        [Key]
        public int Id  {get;set;}
            

        [Required]
        [MinLength (3)]
        public string Name { get; set; }

        [Required]
        [MinLength (5)]
        public string Location { get; set; }


        [Required]
        public string Information { get; set; }
        public ICollection<Ninja>ninjas {get;set;}


    }
}