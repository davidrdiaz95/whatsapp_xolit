using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Services.Conversation
{
    public interface IConversationService
    {
        bool SaveConversation(ConversationDTO messageConversation);
    }
}
