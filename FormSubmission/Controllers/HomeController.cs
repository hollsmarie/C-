using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;
using FormSubmission;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string first, string last, int age, string email, string password)
        {
            User NewUser = new User
            {
                First = first,
                Last = last,
                Age = age,
                Email = email,
                Password = password
            };
            TryValidateModel(NewUser);

            if( ModelState.IsValid){
                string query = $"INSERT INTO users (first, last, age, email, password) VALUES ('{first}', '{last}','{age}', '{email}', '{password}');";
                Database.Execute(query);
                return View("success");
                }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("error");
            }

        }
    }
}
