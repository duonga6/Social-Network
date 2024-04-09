using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
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
        public async Task<IActionResult> GetConversation([FromQuery, Required]string Id, [FromQuery] string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _messageService.GetByUser(UserId, Id, searchString, pageSize, pageNumber));
        }

        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpGet("{messageId}")]
        [ProducesResponseType(typeof(GetMessageResponse), 200)]
        public async Task<IActionResult> GetMessageById(Guid messageId)
        {
            return ResponseModel(await _messageService.GetById(UserId, messageId));
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetMessageResponse), 200)]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            return ResponseModel(await _messageService.SendMessage(UserId, request));
        }

        /// <summary>
        /// Delete message
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id:guid}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeleteMessage(Guid Id)
        {
            return ResponseModel(await _messageService.RevokeMessage(UserId, Id));
        }

    }
}
