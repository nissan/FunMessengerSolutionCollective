using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunMessengerSolutionCollective.Models;
using System.Threading.Tasks;

namespace FunMessengerSolutionCollective.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async ActionResult Index()
        {
            //set the user until I write the part that lets me select a user
            var _message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                ThreadId = Guid.NewGuid().ToString(),
                SenderName = "Nissan Dookeran",
                SenderImageUrl = "https://pbs.twimg.com/profile_images/340937461/nissan.jpg"
            };
            return View(_message);
        }
        [ActionName("Index")]
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id, ThreadId,Title,Body,SenderName,SenderImageUrl")] Message message)
        {
            message.DateTimeStamp = DateTime.Now.ToString();
            await MessageRepository<Message>.CreateMessageAsync(message);
            return RedirectToAction("Index");
        }
    }
}