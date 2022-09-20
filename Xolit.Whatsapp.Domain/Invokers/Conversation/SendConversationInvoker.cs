using System.Threading.Tasks;
using Xolit.Whatsapp.Contracts.Commands.Conversation;
using Xolit.Whatsapp.Contracts.Commands.Whatsapp;
using Xolit.Whatsapp.Contracts.Invokers.Conversation;
using Xolit.Whatsapp.DataTransferObjects.Models;
using Xolit.Whatsapp.DataTransferObjects.Models.Whatsapp;

namespace Xolit.Whatsapp.Domain.Invokers.Conversation
{
    public class SendConversationInvoker : ISendConversationInvoker
    {
        private readonly ICreateConversationCommand conversationCommand;
        private readonly ISendMessageWhatsappCommand sendMessageWhatsapp;

        public SendConversationInvoker(ICreateConversationCommand conversationCommand,
            ISendMessageWhatsappCommand sendMessageWhatsapp)
        {
            this.conversationCommand = conversationCommand;
            this.sendMessageWhatsapp = sendMessageWhatsapp;
        }

        public async Task<bool> Execute(ConversationDTO conversation)
        {
            this.conversationCommand.Execute(conversation);
            RequestSendMessageDTO requestSendMessage = new RequestSendMessageDTO();
            var requestSendWhatsapp = await this.sendMessageWhatsapp.Execute(requestSendMessage);
            return requestSendWhatsapp;
        }
    }
}
