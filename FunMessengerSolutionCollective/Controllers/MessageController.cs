using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FunMessengerSolutionCollective.Models;
using System.Threading.Tasks;

namespace FunMessengerSolutionCollective.Controllers
{
    public class MessageController : ApiController
    {
        //Message[] messageHistory = new Message[]
        //{
        //  new Message
        //  {
        //      Id = 1,
        //      Sender = "Nissan Dookeran",
        //      SenderImageUrl="https://pbs.twimg.com/profile_images/340937461/nissan.jpg",
        //      Text="Hello world!",
        //      DateTimeStamp = DateTime.Now
        //  }
        //};

        public async Task<IEnumerable<Message>> GetMessageHistoryAsync()
        {
            var messageHistory = await MessageRepository<Message>.GetMessagesAsync(d => !d.Deleted);
            return messageHistory.OrderByDescending(c => c.DateTimeStamp);
        }
      
        public async Task<IHttpActionResult> PostMessage(string senderName, string senderImageUrl, string title, string body, string threadId)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                ThreadId = threadId.Equals(String.Empty) ? Guid.NewGuid().ToString() : threadId,
                SenderName = senderName,
                SenderImageUrl = senderImageUrl,
                Title = title,
                Body = body,
                DateTimeStamp = DateTime.Now.ToString()
            };

            await MessageRepository<Message>.CreateMessageAsync(message);
            return Ok(message);



        }
    }
}
