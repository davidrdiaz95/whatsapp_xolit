using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Invokers.MessageConversation
{
    public interface ISendMessageConversationInvoker
    {
        bool Execute(ConversationDTO messageConversation);
    }
}
