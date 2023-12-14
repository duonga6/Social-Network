using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class MessagesController : BaseController
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Get all message with target user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IResponse> GetConversation(string Id)
        {
            return await _messageService.GetAll(UserId, Id);
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponse> SendMessage([FromBody] SendMessageRequest request)
        {
            return await _messageService.SendMessage(UserId, request);
        }

        /// <summary>
        /// Delete message
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id:guid}")]
        public async Task<IResponse> DeleteMessage(Guid Id)
        {
            return await _messageService.DeleteMessage(UserId, Id);
        }

    }
}
