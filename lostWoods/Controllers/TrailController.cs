using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostWoods.Factory;
using lostWoods.Models;

namespace lostWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = new TrailFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View("Index");
        }



        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            return View("New");
        }


        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            trailFactory.Delete(id);
            return RedirectToAction("Index");
        }



        [HttpPost]
        [Route("add")]
        public IActionResult Add(Trail trail)
        {

            if(ModelState.IsValid)
            {

                trailFactory.Add(trail);
                return RedirectToAction("Index");
            }

            else
            {
                return View("new");
            }
            
        }


    
        [HttpGet]
        [Route("show/{id}")]
        public IActionResult Show(int id)
        {
            ViewBag.Trail = trailFactory.FindByID(id);

            return View("show");
        }
    }
}
