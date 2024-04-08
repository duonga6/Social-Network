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
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetPostReactionResponse>), 200)]
        public async Task<IResponse> Update(Guid Id, UpdatePostReactionRequest request)
        {
            return await _postReactionService.Update(UserId, Id, request);
        }

        ///// <summary>
        ///// Get user reaction on this post
        ///// </summary>
        ///// <param name="postId"></param>
        ///// <returns></returns>
        //[HttpGet("GetByUser")]
        //[ProducesResponseType(typeof(DataResponse<GetPostReactionResponses>), 200)]
        //public async Task<IResponse> GetByUser([FromQuery, Required]Guid postId)
        //{
        //    return await _postReactionService.GetByUser(UserId, postId);
        //}

        ///// <summary>
        ///// Get post reaction by postId
        ///// </summary>
        ///// <param name="postId"></param>
        ///// <returns></returns>
        //[HttpGet("GetByPost/{postId}")]
        //[ProducesResponseType(typeof(DataResponse<GetPostReactionResponse>), 200)]
        //public async Task<IResponse> GetByPost(Guid postId)
        //{
        //    return await _postReactionService.GetByPost(UserId, postId);
        //}

        /// <summary>
        /// Get overview reaction: type reaction, total count, user reacted
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("GetOverview/{postId}")]
        [ProducesResponseType(typeof(DataResponse<GetOverviewReactionResponse>), 200)]
        public async Task<IResponse> GetOverview(Guid postId)
        {
            return await _postReactionService.GetOverview(UserId, postId);
        }

        /// <summary>
        /// Delete post reaction
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _postReactionService.Delete(UserId, Id);
        }
    }
}
