using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Dojodachi.Controllers

{
    public class Dojodachi : Controller
    {
        [HttpGet]
        [Route("/")]

        public IActionResult Index()
        {
            int? checkHappy = HttpContext.Session.GetInt32("Happiness");  //check for session
            int? checkFull = HttpContext.Session.GetInt32("Fullness");
            int? checkEnergy = HttpContext.Session.GetInt32("Energy");


            if (checkHappy ==null)                                          //if session is null
            {

                HttpContext.Session.SetInt32("Happiness",20);               //setting session
                HttpContext.Session.SetInt32("Fullness",20);
                HttpContext.Session.SetInt32("Energy",50);
                HttpContext.Session.SetInt32("Meals",3);
                TempData["Message"]="";
            }

            

            if (checkFull >= 100 && checkEnergy >=100 && checkHappy >= 100)
            {
                TempData["Message"]="Your puppodachi is 100 fullness, happiness, and energy. You win, get back to work.";
            }

            TempData["happy"] = HttpContext.Session.GetInt32("Happiness");   //setting tempdata to pass to html
            TempData["full"] = HttpContext.Session.GetInt32("Fullness");
            TempData["energy"] = HttpContext.Session.GetInt32("Energy");
            TempData["meals"] = HttpContext.Session.GetInt32("Meals");

            System.Console.WriteLine();
            return View("index");
        }

        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            int? meals = HttpContext.Session.GetInt32("Meals");
            int? full = HttpContext.Session.GetInt32("Fullness");
            Random rand = new Random();
            if ((int)meals > 0)
            {
                meals -=1;
                int failure= rand.Next(1,5);

                if (failure !=4)
                {
                  full += rand.Next(5,11);  
                }
                else
                {
                    TempData["Message"]= "Puppodachi didn't like that meal and didn't gain any fullness!";
                }

            }

            else
            {
                TempData["Message"]= "No meals available!";
            }

            HttpContext.Session.SetInt32("Meals",(int)meals);
            HttpContext.Session.SetInt32("Fullness",(int)full);


            return RedirectToAction("index");
        }


        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? happy = HttpContext.Session.GetInt32("Happiness");
            Random rand = new Random();
            if ((int)energy > 4)
            {
                energy -=5;
                int failure = rand.Next(1,5);
                if (failure !=4)
                {
                    happy += rand.Next(5,11);
                }
                else
                {
                    TempData["Message"]= "Puppodachi took no pleasure from that play session. No happiness gained!";
                }

            }

            else
            {
                TempData["Message"]= "Not enough energy!";
            }

            HttpContext.Session.SetInt32("Energy",(int)energy);
            HttpContext.Session.SetInt32("Happiness",(int)happy);


            return RedirectToAction("index");
        }


        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? meals = HttpContext.Session.GetInt32("Meals");
            Random rand = new Random();
            if ((int)energy > 4)
            {
                energy -=5;
                meals += rand.Next(1,4);

            }

            else
            {
                TempData["Message"]= "Not enough energy!";
            }

            HttpContext.Session.SetInt32("Energy",(int)energy);
            HttpContext.Session.SetInt32("Meals",(int)meals);

            return RedirectToAction("index");
        }


        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? full = HttpContext.Session.GetInt32("Fullness");
            int? happy = HttpContext.Session.GetInt32("Happiness");

            if ((int)full > 4 && (int)happy > 4)
            {
                energy +=15;
                full -=5;
                happy -=5;

            }

            else
            {
                energy +=15;
                full -=5;
                happy -=5;
                
                if(full<=0)
                {
                   TempData["Message"]="Your puppodachi is at or below 0 fullness. You starved it to death, you monster."; 
                }
                if(happy <=0)
                {
                    TempData["Message"]="Your puppodachi is at or below 0 happiness and has killed itself.";
                }
                if (full <= 0 && happy <= 0)
                {
                    TempData["Message"]="Your puppodachi is at or below 0 fullness and happiness. It has been starved and fully depressed into suicide";
                }
                
            }

            HttpContext.Session.SetInt32("Energy",(int)energy);
            HttpContext.Session.SetInt32("Happiness",(int)happy);
            HttpContext.Session.SetInt32("Fullness",(int)full);

            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("index");
        }
    }
}