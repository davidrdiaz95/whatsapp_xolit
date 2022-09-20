namespace Xolit.Whatsapp.DataTransferObjects.Models
{
    public class ConversationDTO
    {
        public int IdConversation { get; set; }
        public long IdTelefono { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }

        public ConversationDTO()
        {
            this.Message = "";
        }
    }
}
