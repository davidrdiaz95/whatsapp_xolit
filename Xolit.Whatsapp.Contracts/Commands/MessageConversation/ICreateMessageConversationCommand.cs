using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Commands.MessageConversation
{
    public interface ICreateMessageConversationCommand
    {
        MessageConversationDTO Execute(MessageConversationDTO messageConversation);
    }
}
