using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace dojoLeague.Models
{
    
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id  {get;set;}
            

        [Required]
        [MinLength (3)]
        public string Name { get; set; }

        [Required (ErrorMessage="Level field required")]
        public int? Level { get; set; }
        public int Dojo_id{get;set;}

        public string Description{get;set;}
        public string Dojo_name{get;set;}


    }
}