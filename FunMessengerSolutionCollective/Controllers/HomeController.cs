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
                        SenderImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/80/Anonymous.png"
                    };
                    break;
                case 0:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Nissan Dookeran",
                        SenderImageUrl = "https://pbs.twimg.com/profile_images/340937461/nissan.jpg"
                    };
                    break;
                case 1:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Captain Hook",
                        SenderImageUrl = "https://sup3rjunior.files.wordpress.com/2013/03/captain-hook.jpg"
                    };
                    break;
                case 2:
                    _message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        ThreadId = Guid.NewGuid().ToString(),
                        SenderName = "Peter Pan",
                        SenderImageUrl = "https://drakalogia.wikispaces.com/file/view/4c4b3ee3cf63c82d77e04860c699876854bc4b79.jpg/499776162/4c4b3ee3cf63c82d77e04860c699876854bc4b79.jpg"
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