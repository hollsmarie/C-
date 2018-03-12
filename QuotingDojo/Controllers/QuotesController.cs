using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuotingDojo; //needs to match with directory name


namespace QuotingDojo.Controllers


{
    public class QuotesController : Controller
    {
        [HttpGet]
        [Route("/")]

        public IActionResult Index()
        {
            if (TempData["error"]!=null)
            {
                ViewBag.Error = TempData["error"];
            }

            return View("index");
        }

        [HttpPost]
        [Route("quotepost")]
        public IActionResult Create(string name, string quote)
        {
            if (name == null || quote ==null){
                TempData["Error"] = "Neither field can be left blank";
                return RedirectToAction("Index");
            }
            else {
                //should add to db
                string query = $"INSERT INTO users (name, quote, created_at) VALUES ('{name}','{quote}', NOW());";
                Database.Execute(query); 
                return RedirectToAction("Get"); //redirect to action goes to a method. redirect goes to route
            }
        }

        [HttpGet]
        [Route("quoteget")]
        public IActionResult Get()
        {
            //get all quotes
            string query = "SELECT * FROM users";
            var quotes = Database.Query(query);


            //to sort by ascending order?
            // quotes = quotes.OrderByDescending((quote) = > quotes["created_at"]).ToList();
           
            ViewBag.Quotes = quotes;
            return View("quoteboard");
        }
    }


}