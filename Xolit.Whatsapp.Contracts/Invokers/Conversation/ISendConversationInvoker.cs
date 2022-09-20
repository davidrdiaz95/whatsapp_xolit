using System.Threading.Tasks;
using Xolit.Modelos.DTO;
using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Contracts.Invokers.Conversation
{
    public interface ISendConversationInvoker
    {
        Task<bool> Execute(ConversationDTO conversation);    
    }
}
