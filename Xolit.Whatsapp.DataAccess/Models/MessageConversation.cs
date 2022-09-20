using System.ComponentModel.DataAnnotations.Schema;

namespace Xolit.Whatsapp.DataAccess.Models
{
    [Table("MessageConversation")]
    public class MessageConversation
    {
        public int IdMessageConversation { get; set; }
        public string Message { get; set; }
        public bool IsAdvisor { get; set; }
        public int FkIdConversation { get; set; }
        public virtual Conversation Conversation { get; set; }
        public MessageConversation()
        {
            this.Message = "";
            this.Conversation = new Conversation();
        }
    }
}
