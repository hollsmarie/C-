using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using thewall.Models;
using thewall;

namespace thewall.Controllers

{

     public class MessageController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("display")]
        public IActionResult Display()

        {
            ViewBag.Name = HttpContext.Session.GetString("username");
            
            if (TempData["error"]!=null)
            {
                ViewBag.error = TempData["error"];
            }
            string messagequery = "SELECT message, user_id, messages.id, users.first, users.last FROM messages JOIN users ON messages.user_id WHERE messages.user_id = users.id;";
            // above line grabs message/user_id field from messages table and first/last from users table, joins them where messages user_id column where the user_id column matches the id column in the users table
            
            string commentquery = "SELECT comment, user_id, message_id, users.first, users.last FROM comments JOIN users ON comments.user_id WHERE comments.user_id = users.id;";
            
            var messages = Database.Query(messagequery);
            var comments = Database.Query(commentquery);

            ViewBag.Messages = messages;
            ViewBag.Comments = comments;
            return View("thewall", "Message");
        }

        [HttpPost]
        [Route("messagePost")]

        public IActionResult MessagePost(string mpost)

        {
            int? id = HttpContext.Session.GetInt32("userid");

            if (id == null)
            {
                return RedirectToAction("index","Login");
            }

            else
            {

                if (mpost == null)
                {
                    TempData["error"] = "Message field cannot be blank";
                    return RedirectToAction("Display");
                }

                else
                {
                    int userid = (int)id;

                    string query = $"INSERT into messages (message, user_id) VALUES ('{mpost}', '{userid}');";
                    Database.Execute(query);
                    return RedirectToAction("Display");
                }

            }
        }


        [HttpPost]
        [Route("commentPost")]

        public IActionResult CommentPost(string cpost, int messageID)

        {
            int? id = HttpContext.Session.GetInt32("userid");

            if (id == null)
            {
                return RedirectToAction("index","Login");
            }

            else
            {

                if (cpost == null)
                {
                    TempData["error"] = "Comment field cannot be blank";
                    return RedirectToAction("Display");
                }

                else
                {
                    int userid = (int)id;

                    string query = $"INSERT into comments (comment, user_id, message_id) VALUES ('{cpost}', {userid}, {messageID});";
                    Database.Execute(query);
                    return RedirectToAction("Display");
                }
            }
        }
    }
}