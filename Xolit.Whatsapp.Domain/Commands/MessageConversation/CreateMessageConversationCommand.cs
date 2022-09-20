using Xolit.Whatsapp.Contracts.Commands.MessageConversation;
using Xolit.Whatsapp.DataAccess.Repositories.Imp;
using Xolit.Whatsapp.DataTransferObjects.Models;
using static Xolit.Whatsapp.Contracts.Mappers.IMapper;

namespace Xolit.Whatsapp.Domain.Commands.MessageConversation
{
    public class CreateMessageConversationCommand : ICreateMessageConversationCommand
    {
        private readonly IRepository<DataAccess.Models.MessageConversation> repository;
        private readonly IMapper<MessageConversationDTO,DataAccess.Models.MessageConversation> mapper;
        private readonly IRepository<DataAccess.Models.Conversation> repository1;

        public CreateMessageConversationCommand(IRepository<DataAccess.Models.MessageConversation> repository,
            IMapper<MessageConversationDTO, DataAccess.Models.MessageConversation> mapper,
            IRepository<DataAccess.Models.Conversation> repository1)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repository1 = repository1;
        }

        public MessageConversationDTO Execute(MessageConversationDTO messageConversation)
        {
            var model = this.mapper.MapFrom(messageConversation);
            if (messageConversation.Conversation.IdConversation >0)
            {
                var conversation = this.repository1.SingleFindBy(x => x.IdConversation.Equals(messageConversation.Conversation.IdConversation));
                model.Conversation = conversation;
            }
            this.repository.Insert(model);
            return messageConversation;
        }
    }
}
