using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        #region Post

        /// <summary>
        /// Get all post (owner, friend's). Admin get all user's post
        /// </summary>
        /// <param name="searchString">Key word search</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostResponse>>), 200)]
        public async Task<IActionResult> GetAll([FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _postService.GetAll(UserId, searchString, pageSize, pageNumber));
        }

        /// <summary>
        /// Get post by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _postService.GetById(UserId, Id));
        }

        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IActionResult> Create([FromBody]CreatePostRequest request)
        {
            return ResponseModel(await _postService.Create(UserId, request));
        }

        [HttpPost("Share")]
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IActionResult> Share([FromBody]CreateSharePostRequest request)
        {
            return ResponseModel(await _postService.CreateShare(UserId, request));
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdatePostRequest request)
        {
            var ResponseModel(userId = User.GetUserId());
            if (userId == null)
            {
                return new ErrorResponse(401, Messages.UnAuthorized);
            }

            request.AuthorId = userId;
            return await _postService.Update(UserId, Id, request);
        }

        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var ResponseModel(userId = User.GetUserId());
            if (userId == null)
            {
                return new ErrorResponse(401, Messages.UnAuthorized);
            }

            return await _postService.Delete(UserId, Id);
        }
        #endregion
        
        #region Post Comment

        /// <summary>
        /// Get all comment of post
        /// </summary>
        /// <param name="Id">Id of post</param>
        /// <param name="searchString">Key word search</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet("{Id}/Comments")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostCommentResponse>>), 200)]
        public async Task<IActionResult> GetComment(Guid Id,[FromQuery] string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _postService.GetComments(UserId, Id, searchString, pageSize, pageNumber));
        }

        /// <summary>
        /// Get comment by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Comments/{commentId}")]
        [ProducesResponseType(typeof(DataResponse<GetPostCommentResponse>), 200)]
        public async Task<IActionResult> GetComment(Guid Id, Guid commentId) 
        { 
            return ResponseModel(await _postService.GetCommentById(UserId, Id, commentId));
        }

        /// <summary>
        /// Create comment for post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Comments")]
        [ProducesResponseType(typeof(DataResponse<GetPostCommentResponse>), 200)]
        public async Task<IActionResult> CreateComment(Guid Id, [FromBody] CreatePostCommentRequest request)
        {
            var ResponseModel(userId = User.GetUserId());

            return await _postService.CreateComment(UserId, Id, request);
        }

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Comments/{commentId}")]
        [ProducesResponseType(typeof(DataResponse<GetPostCommentResponse>), 200)]
        public async Task<IActionResult> UpdateComment(Guid Id, Guid commentId, [FromBody] UpdatePostCommentRequest request)
        {
            var ResponseModel(userId = User.GetUserId());

            return await _postService.UpdateComment(UserId, Id, commentId, request);
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Comments/{commentId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeleteComment(Guid Id, Guid commentId)
        {
            var ResponseModel(userId = User.GetUserId());

            return await _postService.DeleteComment(UserId, Id, commentId);
        }
        #endregion

        #region Post Reaction

        /// <summary>
        /// Get all reaction of post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet("{Id}/Reactions")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostReactionResponses>>), 200)]
        public async Task<IActionResult> GetAllReactions(Guid Id,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _postService.GetAllReactions(UserId, Id, pageSize, pageNumber));
        }

        /// <summary>
        /// Create post reaction
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Reactions")]
        [ProducesResponseType(typeof(DataResponse<GetPostReactionResponses>), 200)]
        public async Task<IActionResult> CreatePostReaction(Guid Id, [FromBody] CreatePostReactionRequest request)
        {
            return ResponseModel(await _postService.CreateReaction(UserId, Id, request));
        }

        /// <summary>
        /// Update reaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reactionId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Reactions/{reactionId}")]
        [ProducesResponseType(typeof(DataResponse<GetPostReactionResponses>), 200)]
        public async Task<IActionResult> UpdatePostReaction(Guid Id, int reactionId, [FromBody] CreatePostReactionRequest request)
        {
            return ResponseModel(await _postService.UpdateReaction(UserId, Id, reactionId, request));
        }

        /// <summary>
        /// Delete reaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reactionId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Reactions/{reactionId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeletePostReaction(Guid Id, int reactionId)
        {
            return ResponseModel(await _postService.DeleteReaction(UserId, Id, reactionId));
        }
        #endregion
    }

}
