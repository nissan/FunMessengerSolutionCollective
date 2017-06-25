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
        public ActionResult Index(int? user)
        {
            Message _message = new Message();
            switch (user)
            {
                default:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Anonymous",
                        SenderImageUrl = "/Images/Anonymous.png"
                    };
                    break;
                case 0:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Nissan Dookeran",
                        SenderImageUrl = "/Images/nissan.jpg"
                    };
                    break;
                case 1:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Captain Hook",
                        SenderImageUrl = "/Images/captain-hook.jpg"
                    };
                    break;
                case 2:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Peter Pan",
                        SenderImageUrl = "/Images/peter-pan.jpg"
                    };
                    break;
            }
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