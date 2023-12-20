using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using System.ComponentModel.DataAnnotations;

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
        /// <param name="Id">User id</param>
        /// <param name="searchString">Key word search message</param>
        /// <param name="pageSize">Item per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetMessageResponse>>), 200)]
        public async Task<IResponse> GetConversation([FromQuery, Required]string Id, [FromQuery] string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _messageService.GetByUser(UserId, Id, searchString, pageSize, pageNumber);
        }

        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpGet("{messageId}")]
        [ProducesResponseType(typeof(GetMessageResponse), 200)]
        public async Task<IResponse> GetMessageById(Guid messageId)
        {
            return await _messageService.GetById(UserId, messageId);
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetMessageResponse), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteMessage(Guid Id)
        {
            return await _messageService.DeleteMessage(UserId, Id);
        }

    }
}
