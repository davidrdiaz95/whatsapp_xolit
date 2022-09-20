using Xolit.Whatsapp.DataAccess.Models;
using Xolit.Whatsapp.DataTransferObjects.Models;
using static Xolit.Whatsapp.Contracts.Mappers.IMapper;

namespace Xolit.Whatsapp.Domain.Mappers
{
    public class MessageConversationMapper : IMapper<MessageConversationDTO, MessageConversation>
    {
        private readonly IMapper<ConversationDTO, Conversation> mapper;

        public MessageConversationMapper(IMapper<ConversationDTO, Conversation> mapper)
        {
            this.mapper = mapper;
        }

        public MessageConversation MapFrom(MessageConversationDTO model)
        {
            var messageConversation = new MessageConversation();
            messageConversation.Message = model.Message;
            messageConversation.FkIdConversation = model.FkIdConversation;
            messageConversation.IsAdvisor = model.IsAdvisor;
            messageConversation.Conversation = this.mapper.MapFrom(model.Conversation);
            return messageConversation;
        }

        public MessageConversationDTO MapTo(MessageConversation model)
        {
            var messageConversation = new MessageConversationDTO();
            messageConversation.Message = model.Message;
            messageConversation.FkIdConversation = model.FkIdConversation;
            messageConversation.IsAdvisor = model.IsAdvisor;
            return messageConversation;
        }
    }
}
