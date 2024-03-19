using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.CommentReactions.Responses;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Response;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class CommentReactionsController : BaseController
    {
        private readonly ICommentReactionService _commentReactionService;

        public CommentReactionsController(ICommentReactionService commentReactionService)
        {
            _commentReactionService = commentReactionService;
        }

        /// <summary>
        /// Create reaction for comment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IResponse> Create([FromBody] CreateCommentReactionRequests request)
        {
            return await _commentReactionService.Create(UserId, request);
        }

        /// <summary>
        /// Delete reaction of comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _commentReactionService.Delete(UserId, Id);
        }

        /// <summary>
        /// Get overview reaction of comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(DataResponse<GetOverviewReactionResponse>), 200)]
        [HttpGet("{Id}/GetOverview")]        
        public async Task<IResponse> GetOverview(Guid Id)
        {
            return await _commentReactionService.GetOverview(UserId, Id);
        }

        /// <summary>
        /// Update reaction of comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IResponse> Update(Guid id, UpdateCommentReactionRequest request)
        {
            return await _commentReactionService.Update(UserId, id, request);
        }
    }
}
