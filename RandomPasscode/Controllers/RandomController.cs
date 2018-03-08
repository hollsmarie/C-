using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;



namespace RandomPasscode.Controllers

{
    public class RandomController : Controller
    {
        [HttpGet]
        [Route("/")]

        public IActionResult Index()
        {
            int? check = HttpContext.Session.GetInt32("Counter");
            System.Console.WriteLine(check);
            if (check ==null)
            {

                HttpContext.Session.SetInt32("Counter",0);
            }
            TempData["count"] = HttpContext.Session.GetInt32("Counter");
            Console.WriteLine(TempData["count"]);

            return View("index");
        }

        [HttpPost]
        [Route("generate")]

        public IActionResult Generate()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string passcode = "";
            Random rand = new Random();
            for (int x = 0; x< 14; x++)
            {
                int z = rand.Next(0,36);
                passcode+=chars[z];
            }
            TempData["passcode"]= passcode;
            int? count = HttpContext.Session.GetInt32("Counter");
            count+=1;
            HttpContext.Session.SetInt32("Counter",(int)count);

            return RedirectToAction("index");
        }
    }
}