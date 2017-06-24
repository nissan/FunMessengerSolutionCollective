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
            var messageHistory = await MessageRepository<Message>.GetMessagesAsync(d=>!d.Deleted);
            return messageHistory;
        }

    }
}
