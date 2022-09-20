using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Services.MessageConversation
{
    public interface IMessageConversationService
    {
        bool SendMessage(MessageConversationDTO messageConversation);
    }
}
