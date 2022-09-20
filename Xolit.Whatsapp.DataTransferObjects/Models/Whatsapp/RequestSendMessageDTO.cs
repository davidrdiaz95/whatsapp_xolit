using System.Text.Json.Serialization;

namespace Xolit.Whatsapp.DataTransferObjects.Models.Whatsapp
{
    public class RequestSendMessageDTO
    {
        [JsonPropertyName("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("template")]
        public TemplateDTO Template { get; set; }

        public RequestSendMessageDTO()
        {
            this.Type = "";
            this.MessagingProduct = "";
            this.Template = new TemplateDTO();
            this.To = "";
        }
    }
}
