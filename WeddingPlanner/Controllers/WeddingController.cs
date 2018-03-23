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
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext _context;

        public WeddingController(WeddingContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? seshcheck = HttpContext.Session.GetInt32("userid");

            if (seshcheck != null)
            {
                List<Wedding> allWeddings = _context.Weddings  //create a list of all weddings 
                    .Include(wedding => wedding.User)
                    .Include(wedding => wedding.RSVPs)
                        .ThenInclude(RSVP =>RSVP.User).ToList();
                List<Dictionary<string,object>> WeddingList = new List<Dictionary<string,object>>();
                
                foreach(Wedding wedding in allWeddings) //for loop to check for owner/rsvp. for each Wedding class with variable name wedding in all weddings from above
                {
                    bool Owned = false; //default set owned to false
                    bool RSVPED = false; //default set owned to false
                    int RSVPs = 0; //create rsvps and set to 0

                    if (HttpContext.Session.GetInt32("userid")==wedding.UserId)
                    {
                        Owned = true;
                    }

                    foreach (var rsvp in wedding.RSVPs)
                    {
                        if (rsvp.UserId == HttpContext.Session.GetInt32("userid"))
                        {
                            RSVPED = true;
                        }
                        RSVPs++;
                    }
                
                    Dictionary<string,object> newWeddingAdd = new Dictionary<string, object>();
                    newWeddingAdd.Add("WeddingId", wedding.WeddingId);
                    newWeddingAdd.Add("WedderOne", wedding.WedderOne);
                    newWeddingAdd.Add("WedderTwo", wedding.WedderTwo);
                    newWeddingAdd.Add("WeddingDate", wedding.WeddingDate);
                    newWeddingAdd.Add("Owned", Owned);
                    newWeddingAdd.Add("RSVPs", RSVPs);
                    newWeddingAdd.Add("RSVPED", RSVPED);
                    WeddingList.Add(newWeddingAdd);
                    

                }
                ViewBag.Weddings = WeddingList;
                return View("dashboard", "Wedding");
            }

            else 
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            int? seshcheck = HttpContext.Session.GetInt32("userid");

            if (seshcheck != null)
            {
                return View("new");
            }

            else 
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Wedding wedding)
        {
            if (ModelState.IsValid)
            {
                Wedding newWedding = new Wedding
                {
                    WedderOne = wedding.WedderOne,
                    WedderTwo = wedding.WedderTwo,
                    WeddingDate = wedding.WeddingDate,
                    Address = wedding.Address,
                    UserId = (int)HttpContext.Session.GetInt32("userid")
                };

                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            else
            {
                return View("new");
            }
        }

        [HttpGet]
        [Route ("delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
            Wedding deletethis = _context.Weddings.SingleOrDefault( //set object deletethis to anything that matches userid and wedding ID
                w => w.UserId == (int)HttpContext.Session.GetInt32("userid") && w.WeddingId == WeddingId);
                System.Console.WriteLine("******************************************");
                System.Console.WriteLine(deletethis);
                if (deletethis != null)
                {
                    _context.Weddings.Remove(deletethis);
                    _context.SaveChanges();
                }

                return RedirectToAction("Dashboard","Wedding");
            
        }

        [HttpGet]
        [Route("reserve/{WeddingId}")]

        public IActionResult Reserve(int WeddingId)

        {
            RSVP newRSVP = new RSVP
            {
                UserId = (int)HttpContext.Session.GetInt32("userid"),
                WeddingId = WeddingId
            };

            RSVP existingRSVP = _context.RSVP.SingleOrDefault
            (r => r.UserId == (int)HttpContext.Session.GetInt32("userid")&& r.WeddingId == WeddingId);
            if (existingRSVP == null)
            {
                _context.RSVP.Add(newRSVP);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard","Wedding");
        }

        [HttpGet]
        [Route("unrsvp/{weddingId}")]
        public IActionResult UnRSVP (int WeddingId)

        {
            RSVP negative = _context.RSVP.SingleOrDefault(
                r=>r.UserId == (int)HttpContext.Session.GetInt32("userid") && r.WeddingId == WeddingId);

            if (negative !=null)
            {
                _context.RSVP.Remove(negative);
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard","Wedding");
            
        }

        [HttpGet]
        [Route("show/{weddingId}")]
        public IActionResult Show (int WeddingId)

        {
            Wedding thisWedding = _context.Weddings.Include(w=>w.RSVPs).ThenInclude(r=>r.User).SingleOrDefault(w=>w.WeddingId==WeddingId);

            ViewBag.ThisWedding = thisWedding;
            return View ("show");
        }

    }
}
