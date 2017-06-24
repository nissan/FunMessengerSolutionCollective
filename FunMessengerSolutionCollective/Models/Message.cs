using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunMessengerSolutionCollective.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string SenderImageUrl { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}