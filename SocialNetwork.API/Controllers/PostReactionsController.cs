using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Responses;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class PostReactionsController : BaseController
    {
        private readonly IPostReactionService _postReactionService;

        public PostReactionsController(IPostReactionService postReactionService)
        {
            _postReactionService = postReactionService;
        }

        /// <summary>
        /// Get sum reaction of post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("GetCount")]
        [ProducesResponseType(typeof(DataResponse<int>), 200)]
        public async Task<IResponse> GetCount([FromQuery, Required]Guid postId)
        {
            return await _postReactionService.GetCount(UserId, postId);
        }
        
        /// <summary>
        /// Create reaction for post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetPostReactionResponse>), 200)]
        public async Task<IResponse> Create(CreatePostReactionsRequest request)
        {
            return await _postReactionService.Create(UserId, request);
        }

        /// <summary>
        /// Update reaction for post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(DataResponse<GetReactionResponse>), 200)]
        public async Task<IResponse> Update(UpdatePostReactionRequest request)
        {
            return await _postReactionService.Update(UserId, request);
        }

        /// <summary>
        /// Get user reaction on this post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("GetByUser")]
        [ProducesResponseType(typeof(DataResponse<GetPostReactionResponse>), 200)]
        public async Task<IResponse> GetByUser([FromQuery, Required]Guid postId)
        {
            return await _postReactionService.GetByUser(UserId, postId);
        }

        /// <summary>
        /// Get post reaction by postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("GetByPost/{postId}")]
        [ProducesResponseType(typeof(DataResponse<GetPostReactionResponse>), 200)]
        public async Task<IResponse> GetByPost(Guid postId)
        {
            return await _postReactionService.GetByPost(UserId, postId);
        }

        /// <summary>
        /// Get overview reaction: type reaction, total count
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("GetOverview/{postId}")]
        [ProducesResponseType(typeof(DataResponse<GetOverviewReactionResponse>), 200)]
        public async Task<IResponse> GetOverview(Guid postId)
        {
            return await _postReactionService.GetOverviewReaction(UserId, postId);
        }

        /// <summary>
        /// Delete post reaction
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpDelete("{postId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> Delete(Guid postId)
        {
            return await _postReactionService.Delete(UserId, postId);
        }
    }
}
