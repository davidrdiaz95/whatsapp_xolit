using Xolit.Whatsapp.DataAccess.Models;
using Xolit.Whatsapp.DataTransferObjects.Models;
using static Xolit.Whatsapp.Contracts.Mappers.IMapper;

namespace Xolit.Whatsapp.Domain.Mappers
{
    public class ConversationMapper : IMapper<ConversationDTO, Conversation>
    {
        public Conversation MapFrom(ConversationDTO model)
        {
            var conversation = new Conversation();
            conversation.Status = model.Status;
            conversation.IdConversation = model.IdConversation;
            conversation.IdTelefono = model.IdTelefono;
            return conversation;
        }

        public ConversationDTO MapTo(Conversation model)
        {
            var conversation = new ConversationDTO();
            conversation.Status = model.Status;
            conversation.IdConversation= model.IdConversation;
            conversation.IdTelefono = model.IdTelefono;
            return conversation;
        }
    }
}
