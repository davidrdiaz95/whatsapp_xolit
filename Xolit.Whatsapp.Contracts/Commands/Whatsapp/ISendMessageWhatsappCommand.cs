using System.Threading.Tasks;
using Xolit.Whatsapp.DataTransferObjects.Models.Whatsapp;

namespace Xolit.Whatsapp.Contracts.Commands.Whatsapp
{
    public interface ISendMessageWhatsappCommand
    {
        Task<bool> Execute(RequestSendMessageDTO requestSendMessage);
    }
}
