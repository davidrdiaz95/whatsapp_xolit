using Xolit.Whatsapp.Contracts.Commands.Conversation;
using Xolit.Whatsapp.DataAccess.Repositories.Imp;
using Xolit.Whatsapp.DataTransferObjects.Models;
using static Xolit.Whatsapp.Contracts.Mappers.IMapper;

namespace Xolit.Whatsapp.Domain.Commands.Conversation
{
    public class GetForPhoneConversationCommand : IGetForPhoneConversationCommand
    {
        private readonly IRepository<DataAccess.Models.Conversation> repository;
        private readonly IMapper<ConversationDTO, DataAccess.Models.Conversation> mapper;

        public GetForPhoneConversationCommand(IRepository<DataAccess.Models.Conversation> repository,
            IMapper<ConversationDTO, DataAccess.Models.Conversation> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public ConversationDTO? Execute(long phone)
        {
            var conversation = this.repository.SingleFindByInclude(x=> x.IdTelefono.Equals(phone),x=> (x.MessageConversation));
            if (conversation != null)
            {
                return this.mapper.MapTo(conversation);
            }
            return null;
        }
    }
}
