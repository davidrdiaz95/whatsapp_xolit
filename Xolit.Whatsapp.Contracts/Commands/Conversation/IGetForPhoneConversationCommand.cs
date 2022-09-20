using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Commands.Conversation
{
    public interface IGetForPhoneConversationCommand
    {
        ConversationDTO? Execute(long phone);
    }
}
