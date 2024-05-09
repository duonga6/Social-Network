using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Wrapper;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class ConversationsController : BaseController
    {
        private readonly IConversationService _conversationService;

        public ConversationsController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        #region Conversation

        /// <summary>
        /// Get conversation by cursor
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CursorResponse<List<GetConversationResponse>>), 200)]
        public async Task<IActionResult> Get([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, string? searchString, DateTime? cursor)
        {
            return ResponseModel(await _conversationService.GetConversation(UserId, pageSize, searchString, cursor));
        }

        /// <summary>
        /// Get conversation by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetConversationResponse>), 200)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _conversationService.GetById(UserId, Id));
        }

        /// <summary>
        /// Get conversation by user Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet("GetByUID/{UserId}")]
        [ProducesResponseType(typeof(DataResponse<GetConversationResponse>), 200)]
        public async Task<IActionResult> GetByUserId(string UserId)
        {
            return ResponseModel(await _conversationService.GetByUserId(this.UserId, UserId));
        }

        /// <summary>
        /// Update name of conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetConversationResponse>), 200)]
        public async Task<IActionResult> Update(Guid Id, UpdateConversationRequest request)
        {
            return ResponseModel(await _conversationService.Update(UserId, Id, request));
        }
        
        /// <summary>
        /// Create conversation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetConversationResponse>), 201)]
        public async Task<IActionResult> Create(CreateConversationRequest request)
        {
            return ResponseModel(await _conversationService.Create(UserId, request));
        }

        /// <summary>
        /// Delete conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return ResponseModel(await _conversationService.Delete(UserId, Id));
        }

        #endregion

        #region Participant

        /// <summary>
        /// Get Participant of conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Participants")]
        [ProducesResponseType(typeof(PagedResponse<List<GetConversationParticipantResponse>>), 200)]
        public async Task<IActionResult> GetParticipant(Guid Id,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber, string? searchString)
        {
            return ResponseModel(await _conversationService.GetParticipant(UserId, Id, pageSize, pageNumber, searchString));
        }

        /// <summary>
        /// Get participant by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ParticipantId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Participants/{ParticipantId}")]
        [ProducesResponseType(typeof(DataResponse<GetConversationParticipantResponse>), 200)]
        public async Task<IActionResult> GetParticipantById(Guid Id, Guid ParticipantId)
        {
            return ResponseModel(await _conversationService.GetParticipantById(UserId, Id, ParticipantId));
        }

        /// <summary>
        /// Get conversation participant by userId
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Participants/UID")]
        [ProducesResponseType(typeof(DataResponse<GetConversationParticipantResponse>), 200)]
        public async Task<IActionResult> GetParticipantByUID(Guid Id,[FromQuery, Required] string userId)
        {
            return ResponseModel(await _conversationService.GetParticipantByUserId(UserId, Id, userId));
        }

        /// <summary>
        /// Add participant for conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Participants")]
        [ProducesResponseType(typeof(DataResponse<GetConversationParticipantResponse>), 201)]
        public async Task<IActionResult> AddParticipant(Guid Id, CreateParticipantRequest request)
        {
            return ResponseModel(await _conversationService.AddParticipant(UserId, Id, request));
        }

        /// <summary>
        /// Remove participant
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ParticipantId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Participants/{ParticipantId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> RemoveParticipant(Guid Id, Guid ParticipantId)
        {
            return ResponseModel(await _conversationService.RemoveParticipant(UserId, Id, ParticipantId));
        }

        /// <summary>
        /// Update name of participant
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ParticipantId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Participants/{ParticipantId}")]
        [ProducesResponseType(typeof(DataResponse<GetConversationParticipantResponse>), 200)]
        public async Task<IActionResult> UpdateParticipant(Guid Id, Guid ParticipantId,[FromBody] UpdateParticipantRequest request)
        {
            return ResponseModel(await _conversationService.UpdateParticipant(UserId, Id, ParticipantId, request));
        }

        #endregion

        #region Admin
        
        /// <summary>
        /// Get Admin of conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Administrators")]
        [ProducesResponseType(typeof(PagedResponse<List<GetConversationParticipantResponse>>), 200)]
        public async Task<IActionResult> GetAdmin(Guid Id,[Required, FromQuery, Range(1, int.MaxValue)] int pageSize, [Required, FromQuery, Range(1, int.MaxValue)] int pageNumber, string? searchString)
        {
            return ResponseModel(await _conversationService.GetAdmin(UserId, Id, pageSize, pageNumber, searchString));
        }

        /// <summary>
        /// Create admin for conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Administrators")]
        [ProducesResponseType(typeof(DataResponse<GetConversationParticipantResponse>), 200)]
        public async Task<IActionResult> AddAdmin(Guid Id, CreateConversationAdminRequest request)
        {
            return ResponseModel(await _conversationService.AddAdmin(UserId, Id, request));
        }

        /// <summary>
        /// Delete admin of conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ParticipantId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Administrators/{ParticipantId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> RemoveAdmin(Guid Id, Guid ParticipantId)
        {
            return ResponseModel(await _conversationService.RemoveAdmin(UserId, Id, ParticipantId));
        }

        #endregion

        #region Message

        /// <summary>
        /// Get message of conversation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageSize"></param>
        /// <param name="cursor"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Messages")]
        [ProducesResponseType(typeof(CursorResponse<List<GetMessageResponse>>), 200)]
        public async Task<IActionResult> GetMessage(Guid Id, int pageSize, DateTime? cursor, string? searchString)
        {
            return ResponseModel(await _conversationService.GetMessage(UserId, Id, pageSize, cursor, searchString));
        }
        
        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Messages/{MessageId}")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 200)]
        public async Task<IActionResult> GetMessageById(Guid Id, Guid MessageId)
        {
            return ResponseModel(await _conversationService.GetMessageById(UserId, Id, MessageId));
        }

        /// <summary>
        /// Create message
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Messages")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 201)]
        public async Task<IActionResult> CreateMessage(Guid Id,[FromBody] CreateMessageOnConversationRequest request)
        {
            return ResponseModel(await _conversationService.CreateMessage(UserId, Id, request));
        }

        /// <summary>
        /// Unsend message
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Messages/{MessageId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> UnsendMessage(Guid Id, Guid MessageId)
        {
            return ResponseModel(await _conversationService.UnsendMessage(UserId, Id, MessageId));
        }

        /// <summary>
        /// Seen message
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Messages/{MessageId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> SeenMessage(Guid Id, Guid MessageId)
        {
            return ResponseModel(await _conversationService.SeenMessage(UserId, Id, MessageId));
        }

        #endregion
    }
}
