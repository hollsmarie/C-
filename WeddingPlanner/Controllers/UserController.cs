using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using WeddingPlanner;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private WeddingContext _context;

        public UserController(WeddingContext context)
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
                return View("Index");
            }

            else
            {
                return RedirectToAction("Success", "User");
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(Reg model) //in () call upon the model class and then give it a variable name
        {
            if (ModelState.IsValid)
            {
                User exists = _context.Users.SingleOrDefault(user => user.Email == model.Email);

                if (exists != null)
                {
                    ModelState.AddModelError("Email", "Email already exists in the database");
                    return View("Index");

                }
                else
                {
                    PasswordHasher<Reg> Hasher = new PasswordHasher<Reg>();
                    string hashed = Hasher.HashPassword(model, model.Password);
                    User newUser = new User
                    {
                        First = model.First,
                        Last = model.Last,
                        Email = model.Email,
                        Password = hashed,
                    };

                    _context.Add(newUser);
                    _context.SaveChanges();
                    User CurrUser = _context.Users.SingleOrDefault(user => user.Email == newUser.Email); //see the newly created object by grabbing email
                    HttpContext.Session.SetInt32("userid", CurrUser.UserId); //setting session id
                    HttpContext.Session.SetString("username", CurrUser.First);
                    ViewBag.Name = HttpContext.Session.GetString("username");

                    return RedirectToAction("Success", "User");
                }

            }
            else
            {
                return View("Index");
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
        public IActionResult Log(LogUser loginuser)
        {

            User Existing = _context.Users.Where(u => u.Email == loginuser.Email).SingleOrDefault(); //checking email against db
            {
                if (Existing == null)
                {
                    ModelState.AddModelError("Email", "Email not found in database.");
                    return View("logback");
                }

                else
                {

                    var hasher = new PasswordHasher<User>();

                    if(hasher.VerifyHashedPassword(Existing, Existing.Password,loginuser.Password) == 0) // checking if hashed pword matches hashed pword in db
                    {
                        ModelState.AddModelError("Password", "Incorrect password!");
                        return View("logback");
                    }

                    else
                    {
                    HttpContext.Session.SetInt32("userid", Existing.UserId); //set session id to the currrent user's id
                    HttpContext.Session.SetString("username", Existing.First);
                    ViewBag.Name = HttpContext.Session.GetString("username");
                    return RedirectToAction("Success");
                    }

                }
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
            return RedirectToAction("Index");
        }
    }
}
