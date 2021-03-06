using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bankAccounts.Models;
using bankAccounts;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace bankAccounts.Controllers
{
    public class LoginController : Controller
    {
        private BankContext _context;

        public LoginController(BankContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            int? seshcheck = HttpContext.Session.GetInt32("userid");

            if (seshcheck == null)
            {
                return View("index");
            }

            else
            {
                return RedirectToAction("Success");
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User newUser) //in () call upon the model class and then give it a variable name
        {
            if (ModelState.IsValid)
            {
                User exists = _context.Users.SingleOrDefault(User => User.Email == Register.Email);
                
                if (exists == 0)
                {
                    string query = $"INSERT INTO users (first, last, email, password) VALUES ('{newUser.First}', '{newUser.Last}','{newUser.Email}', '{newUser.Password}');";

                    //above line inserts/binds model object. access object by calling variable name and . for accessing keys
                    Database.Execute(query);
                    HttpContext.Session.SetString("username", newUser.First);
                    var sessionQ = Database.Query(emailCheck);  //rerun the query to see the newly created object by grabbing email
                    int id = (int)sessionQ[0]["idusers"]; //grabbing the user id and setting to "id"
                    // Console.Write(id);
                    HttpContext.Session.SetInt32("userid", id);  //setting session id

                    return RedirectToAction("Success");
                }
                else
                {
                    ViewBag.email = "Email address already taken.";
                    return View("index");
                }
            }
            else
            {
                ViewBag.email = "";
                return View("index");
            }

        }

        [HttpGet]               //page for logging back in
        [Route("logback")]
        public IActionResult Logback()
        {
            return View("logback");
        }

        [HttpPost]              //route and method for logging back in
        [Route("log")]
        public IActionResult Log(LogUser user)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * from users WHERE (email='{user.Email}')";
                var check = Database.Query(query);

                if (check.Count == 0)     //checking for count of objects matching above query
                {
                    ViewBag.Email = "Email not found!";
                    return View("logback");
                }
                else
                {
                    string password = (check[0]["password"]).ToString();  //going into object to grab value for key password
                    if (password != user.Password)
                    {
                        ViewBag.Password = "Incorrect password. Please retype.";
                        return View("logback");
                    }
                    else
                    {
                        int id = (int)check[0]["idusers"]; //set new int variable id to the value of key "idusers" from db
                        HttpContext.Session.SetInt32("userid", id);  //set session id to the currrent user's id
                        string firstname = (check[0]["first"]).ToString();
                        HttpContext.Session.SetString("username", firstname);
                        return RedirectToAction("Success");
                    }
                }
            }

            else
            {
                ViewBag.Email = "";   //seting warning messages to blank
                ViewBag.Password = "";
                return View("logback");

            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            ViewBag.Name = HttpContext.Session.GetString("username");
            return View("success");
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
