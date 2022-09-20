using Xolit.Whatsapp.Contracts.Invokers.MessageConversation;
using Xolit.Whatsapp.Contracts.Services.Conversation;
using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Domain.Services.Conversation
{
    public class ConversationService : IConversationService
    {
        private readonly ISendMessageConversationInvoker sendMessageConversationInvoker;

        public ConversationService(ISendMessageConversationInvoker sendMessageConversationInvoker)
        {
            this.sendMessageConversationInvoker = sendMessageConversationInvoker;
        }

        public bool SaveConversation(ConversationDTO messageConversation)
        {
            return this.sendMessageConversationInvoker.Execute(messageConversation);
        }
    }
}
