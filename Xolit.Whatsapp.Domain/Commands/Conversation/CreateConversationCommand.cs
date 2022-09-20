using Xolit.Whatsapp.Contracts.Commands.Conversation;
using Xolit.Whatsapp.DataAccess.Repositories.Imp;
using Xolit.Whatsapp.DataTransferObjects.Models;
using static Xolit.Whatsapp.Contracts.Mappers.IMapper;

namespace Xolit.Whatsapp.Domain.Commands.Conversation
{
    public class CreateConversationCommand : ICreateConversationCommand
    {
        private readonly IRepository<DataAccess.Models.Conversation> repository;
        private readonly IMapper<ConversationDTO, DataAccess.Models.Conversation> mapper;

        public CreateConversationCommand(IRepository<DataAccess.Models.Conversation> repository,
            IMapper<ConversationDTO, DataAccess.Models.Conversation> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public ConversationDTO Execute(ConversationDTO conversation)
        {
            var model = this.mapper.MapFrom(conversation);
            this.repository.Insert(model);
            conversation.IdConversation = model.IdConversation;
            return conversation;
        }
    }
}
