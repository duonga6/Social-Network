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
using SocialNetwork.Business.DTOs.CommentReactions.Responses;
using SocialNetwork.Business.DTOs.Response;

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
        /// Get comment of post by cursor pagination
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="pageSize"></param>
        /// <param name="desc"></param>
        /// <param name="endCursor"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet("GetCursor")]
        [ProducesResponseType(typeof(CursorResponse<List<GetPostCommentResponse>>), 200)]
        [AllowAnonymous]
        public async Task<IResponse> GetCursor([FromQuery, Required] Guid postId, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required] bool desc, [FromQuery] DateTime? endCursor, Guid? parentId)
        {
            return await _postCommentService.GetCursor(UserId, pageSize, endCursor, desc, postId, parentId);
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
        /// Get total comment of post (both child comment)
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <returns></returns>
        [HttpGet("GetCount/{postId}")]
        [ProducesResponseType(typeof(DataResponse<int>), 200)]
        public async Task<IResponse> GetCount(Guid postId)
        {
            return await _postCommentService.GetCount(UserId, postId);
        }

        /// <summary>
        /// Get total child comment of a comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/GetChildCount")]
        [ProducesResponseType(typeof(DataResponse<int>), 200)]
        public async Task<IResponse> GetChildCount(Guid Id)
        {
            return await _postCommentService.GetCountChild(UserId, Id);
        }


        /// <summary>
        /// Get child comment of comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet("{Id}/GetChild")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostCommentResponse>>), 200)]
        public async Task<IResponse> GetChild(Guid Id, [FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _postCommentService.GetChild(UserId, searchString, pageSize, pageNumber, Id);
        }

        /// <summary>
        /// Get overview reaction of comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Reactions/GetOverview")]
        [ProducesResponseType(typeof(DataResponse<OverviewReactionResponse<GetCommentReactionResponse>>), 200)]
        public async Task<IResponse> GetOverviewReaction(Guid Id)
        {
            return await _postCommentService.GetOverviewReaction(UserId, Id);
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
        /// <param name="commentReactionId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Reactions/{commentReactionId}")]
        [ProducesResponseType(typeof(DataResponse<GetCommentReactionResponse>), 200)]
        public async Task<IResponse> UpdateReaction(Guid Id, Guid commentReactionId, [FromBody] CreateCommentReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postCommentService.UpdateReaction(userId, Id, commentReactionId, request);
        }

        /// <summary>
        /// Delete reaction for comment (owner reaction)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentReactionId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Reactions/{commentReactionId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteReaction(Guid Id, Guid commentReactionId)
        {
            var userId = User.GetUserId();
            return await _postCommentService.DeleteReaction(userId, Id, commentReactionId);
        }

        #endregion

    }
}
