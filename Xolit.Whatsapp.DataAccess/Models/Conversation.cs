using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xolit.Whatsapp.DataAccess.Models
{
    [Table("Conversation")]
    public class Conversation
    {
        public int IdConversation { get; set; }
        public long IdTelefono { get; set; }
        public int Status { get; set; }
        public virtual List<MessageConversation> MessageConversation { get; set; }
        public Conversation()
        {
            this.MessageConversation = new List<MessageConversation>();
        }
    }
}
