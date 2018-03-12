using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AjaxNotes;

namespace AjaxNotes.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            if (TempData["error"]!=null)
            {
                ViewBag.Error=TempData["error"];
            }
            string query = "SELECT * FROM notes";
            var notes = Database.Query(query);

            ViewBag.Notes = notes;

            return View("Index");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(string title, string description)
        {

            if (title == null || description == null)
            {
                TempData["error"] = "All fields must be completed!";
                return RedirectToAction("Index");
            }
            else 
            {
                string query = $"INSERT INTO notes (title, description, created_at, updated_at) VALUES ('{title}', '{description}', NOW(), NOW());";
                Database.Execute(query);
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        [Route("edit/{NoteId}")]
        public IActionResult Edit(int NoteId)

        {
            if (TempData["error"]!=null)
            {
                ViewBag.Error=TempData["error"];
            }

            string query = $"SELECT * FROM notes Where notesid = {NoteId}";
            ViewBag.Note=Database.Query(query);
            return View("edit");
        }


        [HttpPost]
        [Route("update/{NoteId}")]
        public IActionResult Update(string title, string description, int NoteId)
        {
            if  (title == null || description == null)
            {
                TempData["error"] = "All fields must have values";
                return RedirectToAction("Edit");

            }

            else
            {
                string query = $"Update notes SET title='{title}', description='{description}', updated_at=NOW() WHERE notesid='{NoteId}'";
                Database.Execute(query);
            }
                return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("delete/{NoteId}")]
        public IActionResult Delete(int NoteId)
        {
            string query = $"Delete from notes WHERE notesid= {NoteId}";
            Database.Execute(query);
            return RedirectToAction("Index");
        }

        
    }
}
