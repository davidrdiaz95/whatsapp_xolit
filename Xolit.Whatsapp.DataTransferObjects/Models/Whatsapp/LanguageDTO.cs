using System.Text.Json.Serialization;

namespace Xolit.Whatsapp.DataTransferObjects.Models.Whatsapp
{
    public class LanguageDTO
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        public LanguageDTO()
        {
            this.Code = "";
        }
    }
}
