namespace FunMessengerSolutionCollective.Models
{
    using Microsoft.Azure.Documents;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "threadId")]
        public string ThreadId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "senderName")]
        public string SenderName { get; set; }

        [JsonProperty(PropertyName = "senderImageUrl")]
        public string SenderImageUrl { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]
        [JsonRequired]
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "dateTimeStamp")]
        public string DateTimeStamp { get; set; }

        [JsonProperty(PropertyName = "isDeleted")]
        public bool Deleted { get; set; }
    }
}