using System.Collections.Generic;
using Xolit.Whatsapp.Contracts.Commands.Conversation;
using Xolit.Whatsapp.Contracts.Commands.MessageConversation;
using Xolit.Whatsapp.Contracts.Invokers.MessageConversation;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Extensions;
using Xolit.Whatsapp.Contracts.QueryObjects.MessageConversation;
using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Domain.Invokers.MessageConversation
{
    public class SendMessageConversationInvoker : ISendMessageConversationInvoker
    {
        private readonly IGetForPhoneConversationCommand getForPhoneConversationCommand;
        private readonly ICreateConversationCommand createConversationCommand;
        private readonly ICreateMessageConversationCommand createMessageConversationCommand;
        private readonly IMessageConversationQueryObject messageConversationQueryObject;

        public SendMessageConversationInvoker(IGetForPhoneConversationCommand getForPhoneConversationCommand,
            ICreateConversationCommand createConversationCommand,
            ICreateMessageConversationCommand createMessageConversationCommand,
            IMessageConversationQueryObject messageConversationQueryObject)
        {
            this.getForPhoneConversationCommand = getForPhoneConversationCommand;
            this.createConversationCommand = createConversationCommand;
            this.createMessageConversationCommand = createMessageConversationCommand;
            this.messageConversationQueryObject = messageConversationQueryObject;
        }

        public bool Execute(ConversationDTO message)
        {
            var list = new List<DataAccess.Models.MessageConversation>();
            var messageConversation = new MessageConversationDTO();
            var conversation = this.getForPhoneConversationCommand.Execute(message.IdTelefono);
            if (conversation != null) 
                messageConversation.Conversation = conversation;
            else
                messageConversation.Conversation = message;

            messageConversation.Message = message.Message;
            messageConversation.IsAdvisor = true;
            messageConversation = this.createMessageConversationCommand.Execute(messageConversation);

            list = this.messageConversationQueryObject
                    .ForId(messageConversation.FkIdConversation).GetAll();

            return true;
        }
    }
}
