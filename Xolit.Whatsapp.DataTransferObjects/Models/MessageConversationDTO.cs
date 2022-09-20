namespace Xolit.Whatsapp.DataTransferObjects.Models
{
    public class MessageConversationDTO
    {
        public string Message { get; set; }
        public bool IsAdvisor { get; set; }
        public int FkIdConversation { get; set; }
        public ConversationDTO Conversation { get; set; }
        public MessageConversationDTO()
        {
            this.Message = "";
            this.Conversation = new ConversationDTO();
        }
    }
}
