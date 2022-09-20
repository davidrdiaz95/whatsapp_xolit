using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Commands.Conversation
{
    public interface ICreateConversationCommand
    {
        ConversationDTO Execute(ConversationDTO conversation);
    }
}
