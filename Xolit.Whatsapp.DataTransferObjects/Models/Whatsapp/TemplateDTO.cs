using System.Text.Json.Serialization;

namespace Xolit.Whatsapp.DataTransferObjects.Models.Whatsapp
{
    public class TemplateDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("language")]
        public LanguageDTO Language { get; set; }

        public TemplateDTO()
        {
            this.Name = "";
            this.Language = new LanguageDTO();
        }
    }
}
