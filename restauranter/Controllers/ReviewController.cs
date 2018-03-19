using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
{
    public class ReviewController : Controller
{
    private ReviewContext _context;
 
    public ReviewController(ReviewContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Review newReview) //pass through Model name followed by variable
        {
            if(ModelState.IsValid)
            {
                _context.Add(newReview);
                _context.SaveChanges();                
                return RedirectToAction("Reviews");
            }
            else
            {
                return View ("Index");
            }

        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> allReviews = _context.Reviews.OrderByDescending(r => r.Date).ToList();
            ViewBag.Reviews = allReviews;
            return View("reviews");
        }


    }
}
