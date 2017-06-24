namespace FunMessengerSolutionCollective.Models
{
    using Microsoft.Azure.Documents;
    using Newtonsoft.Json;

    public class Message
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "threadId")]
        public string ThreadId { get; set; }

        [JsonProperty(PropertyName = "senderName")]
        public string SenderName { get; set; }

        [JsonProperty(PropertyName = "senderImageUrl")]
        public string SenderImageUrl { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "isDeleted")]
        public bool Deleted { get; set; }
    }
}