using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using events.Models;
using events;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace events.Controllers
{
    public class EventController : Controller
    {
        private EventContext _context;
        
        public EventController(EventContext context)

        {
            _context = context;
        }

        public int SessionCheck()
        {
          int? userid = HttpContext.Session.GetInt32("userid");
          if(userid ==null)

          {
              return 0;
          }
          return (int)userid;
        }
        
        [HttpGet]
        [Route("dashboard")] 

        public IActionResult Dashboard()
        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            User InSession = _context.Users.SingleOrDefault(u=>u.UserId == SessionCheck());
            ViewBag.User = InSession;
            ViewBag.Events = _context.Events.Include(events =>events.RSVPS).Include(events=>events.Likes).OrderBy(events=>events.Date).ToList();
            return View("dashboard");

        }

        [HttpGet]
        [Route("new")]

        public IActionResult New()

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            return View("new");
        }

        [HttpPost]
        [Route("add")]

        public IActionResult Add(Event model)

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            if(ModelState.IsValid)
            {
                Event newEvent = new Event //create an event object called newEvent
                {
                    Host = model.Host,
                    Title = model.Title,
                    Description = model.Description,
                    Address = model.Address,
                    Date = model.Date,
                    UserId = (int)SessionCheck()
                };

                _context.Add(newEvent);  //add newEvent to DB
                _context.SaveChanges();
                return RedirectToAction("Dashboard","Event");
            }
            else
            {
                return View("new");
            }
        }

        [HttpGet]
        [Route("show/{EventId}")]
        public IActionResult Show (int EventId)

        {
            Event thisEvent = _context.Events.Include(e=>e.RSVPS).ThenInclude(u=>u.User).SingleOrDefault(e=>e.EventId==EventId);

            ViewBag.ThisEvent = thisEvent;
            return View ("show");
        }

        [HttpGet]
        [Route("rsvp/{EventId}")]
        public IActionResult RSVP (int EventId)

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }
            
            RSVP rsvp = new RSVP
            {
                UserId = SessionCheck(),
                EventId = EventId
            };

            _context.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction ("Dashboard", "Event");
        }

        [HttpGet]
        [Route("unrsvp/{EventId}")]
        public IActionResult UnRSVP (int EventId)

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            RSVP rsvp = _context.RSVPS.SingleOrDefault(r=>r.UserId == SessionCheck() && r.EventId == EventId);

            _context.Remove(rsvp);
            _context.SaveChanges();
            return RedirectToAction ("Dashboard","Event");
        }

        [HttpGet]
        [Route("like/{EventId}")]

        public IActionResult Like (int EventId)

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            Like like = new Like
            {
                UserId = SessionCheck(),
                EventId = EventId
            };

            _context.Add(like);
            _context.SaveChanges();
            return RedirectToAction ("Dashboard", "Event");
        }

        [HttpGet]
        [Route("unlike/{EventId}")]

        public IActionResult UnLike (int EventId)

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            Like like = _context.Likes.SingleOrDefault(l=>l.UserId == SessionCheck() && l.EventId == EventId);
            _context.Remove(like);
            _context.SaveChanges();
            return RedirectToAction ("Dashboard", "Event");
        }


        [HttpGet]
        [Route("delete/{EventId}")]
        public IActionResult Delete (int EventId)
        {
            Event deletethis = _context.Events.SingleOrDefault(e=>e.EventId==EventId);
            _context.Remove(deletethis);
            _context.SaveChanges();
            return RedirectToAction("Dashboard","Event");
        }

    }
}
