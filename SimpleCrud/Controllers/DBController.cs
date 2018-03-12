using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection; 


namespace SimpleCrud.Controllers


{
    public class Dojodachi : Controller
    {
        [HttpGet]
        [Route("/")]

        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");

            return AllUsers;
        }
    }
}