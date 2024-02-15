using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.DTOs.CommentReactions.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class PostCommentsController : BaseController
    {
        private readonly IPostCommentService _postCommentService;

        public PostCommentsController(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }

        #region Comment

        /// <summary>
        /// Get all comment of post
        /// </summary>
        /// <param name="postId">Id of post</param>
        /// <param name="searchString">Key word search</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostCommentResponse>>), 200)]
        public async Task<IResponse> GetAll([FromQuery, Required] Guid postId, [FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _postCommentService.GetAll(UserId, searchString, pageSize, pageNumber, postId);
        }

        /// <summary>
        /// Get comment by Id (post owner || post owner's friend)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetPostCommentResponse>), 200)]
        public async Task<IResponse> GetById(Guid Id) 
        {
            return await _postCommentService.GetById(UserId, Id);
        }

        /// <summary>
        /// Create comment (post owner || post owner's friend)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetPostCommentResponse>), 200)]
        public async Task<IResponse> Create([FromBody] CreatePostCommentRequest request)
        {
            return await _postCommentService.Create(UserId, request);
        }

        /// <summary>
        /// Update comment (owner comment)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetPostCommentResponse>), 200)]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostCommentRequest request)
        {
            return await _postCommentService.Update(UserId, Id, request);
        }

        /// <summary>
        /// Delete comment (comment owner)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _postCommentService.Delete(UserId, Id);
        }

        /// <summary>
        /// Get sum comment of post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <returns></returns>
        [HttpGet("GetCount")]
        [ProducesResponseType(typeof(DataResponse<int>), 200)]
        public async Task<IResponse> GetCount([FromQuery, Required] Guid postId)
        {
            return await _postCommentService.GetCount(UserId, postId);
        }

        /// <summary>
        /// Get overview comment of post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        [HttpGet("GetOverview/{postId}")]
        public async Task<IResponse> GetOverview(Guid postId)
        {
            return await _postCommentService.GetOverviewComment(UserId, postId);
        }

        #endregion

        #region Reaction

        /// <summary>
        /// Get reaction of comment (post owner || post owner's friend)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current Page</param>
        /// <returns></returns>
        [HttpGet("{Id}/Reactions")]
        [ProducesResponseType(typeof(PagedResponse<List<GetCommentReactionResponse>>), 200)]
        public async Task<IResponse> GetAllReactions(Guid Id, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _postCommentService.GetReactions(UserId, Id, pageSize, pageNumber);
        }

        /// <summary>
        /// Create reaction for comment (post owner || post owner's friend)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Reactions")]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IResponse> CreateReaction(Guid Id, [FromBody] CreateCommentReactionRequest request)
        {
            return await _postCommentService.CreateReaction(UserId, Id, request);
        }

        /// <summary>
        /// Update reaction for comment (owner reaction)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Reactions/{reactionId}")]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IResponse> UpdateReaction(Guid Id, [FromBody] CreateCommentReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postCommentService.UpdateReaction(userId, Id, request);
        }

        /// <summary>
        /// Delete reaction for comment (owner reaction)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reactionId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Reactions/{reactionId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteReaction(Guid Id, int reactionId)
        {
            var userId = User.GetUserId();
            return await _postCommentService.DeleteReaction(userId, Id, reactionId);
        }

        #endregion

    }
}
