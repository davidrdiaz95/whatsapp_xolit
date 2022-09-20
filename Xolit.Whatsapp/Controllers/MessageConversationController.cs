using Microsoft.AspNetCore.Mvc;
using Xolit.Whatsapp.Contracts.Services.Conversation;
using Xolit.Whatsapp.DataTransferObjects.Models;

namespace Xolit.Whatsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageConversationController : ControllerBase
    {
        private readonly IConversationService conversationService;

        public MessageConversationController(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        [HttpPost]
        [Route("test")]
        public IActionResult Test(ConversationDTO conversationDTO) 
        {
            return Ok(this.conversationService.SaveConversation(conversationDTO));
        }
    }
}
