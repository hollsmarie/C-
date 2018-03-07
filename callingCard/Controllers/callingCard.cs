using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingCard.Controllers
{
    public class callingCard : Controller
    {
        [HttpGet]
        [Route("")]
        public string Choices()
        {
            return "The following URL options will return info: /first, /last, /favcolor, /age, /all";
        }

        [HttpGet]
        [Route("first")]
        public JsonResult displayFirst()
        {
            return Json("Nick");
        }

        [HttpGet]
        [Route("last")]
        public JsonResult displayLast()
        {
            return Json("De Fina");
        }

        [HttpGet]
        [Route("favcolor")]
        public JsonResult displayColor()
        {
            return Json("green");
        }

        [HttpGet]
        [Route("age")]
        public JsonResult displayAge()
        {
            return Json("31");
        }

        [HttpGet]
        [Route("all")]
        public JsonResult displayAll(string first, string last, string favcolor, int age)
        {
            var callCard = new {
                first = "Nick",
                last = "De Fina",
                favcolor = "green",
                age = 31
            };
            return Json(callCard);
        }
    }
}