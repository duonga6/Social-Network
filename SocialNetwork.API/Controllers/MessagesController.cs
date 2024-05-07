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
        /// Get cursor messages
        /// </summary>
        /// <param name="conversationId"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CursorResponse<List<GetMessageResponse>>), 200)]
        public async Task<IActionResult> Get([FromQuery, Required] Guid conversationId, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery] string? searchString, [FromQuery] DateTime? cursor)
        {
            return ResponseModel(await _messageService.Get(UserId, conversationId, pageSize, searchString, cursor));
        }

        /// <summary>
        /// Get messages by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 200)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _messageService.GetById(UserId, Id));
        }

        /// <summary>
        /// Create message
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 201)]
        public async Task<IActionResult> Create([FromBody] CreateMessageRequest request)
        {
            return ResponseModel(await _messageService.Create(UserId, request));
        }

        /// <summary>
        /// Create message with conversaion id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ByConversation")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 201)]
        public async Task<IActionResult> Create([FromBody] CreateMessageWithConversationRequest request)
        {
            return ResponseModel(await _messageService.Create(UserId, request));
        }

        /// <summary>
        /// Revoke message
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 200)]
        public async Task<IActionResult> RevokeMessage(Guid Id)
        {
            return ResponseModel(await _messageService.RevokeMessage(UserId, Id));
        }

        /// <summary>
        /// Seen message
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 200)]
        public async Task<IActionResult> SeenMessage(Guid Id )
        {
            return ResponseModel(await _messageService.SeenMessage(UserId, Id));
        }
    }
}
