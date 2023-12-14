using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;

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
        /// Get all post (admin)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = RoleName.Administrator)]
        public async Task<IResponse> GetAll()
        {
            return await _postService.GetAll();
        }

        /// <summary>
        /// Get post by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _postService.GetById(UserId, Id);
        }

        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponse> Create([FromBody]CreatePostRequest request)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return new ErrorResponse(401, Messages.UnAuthorized);
            }

            request.AuthorId = userId;
            return await _postService.Create(request);
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostRequest request)
        {
            var userId = User.GetUserId();
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
        public async Task<IResponse> Delete(Guid Id)
        {
            var userId = User.GetUserId();
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
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Comments")]
        public async Task<IResponse> GetAllComment(Guid Id)
        {
            return await _postService.GetAllComments(Id);
        }

        /// <summary>
        /// Get comment by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Comments/{commentId}")]
        public async Task<IResponse> GetComment(Guid Id, Guid commentId) 
        { 
            return await _postService.GetCommentById(Id, commentId);
        }

        /// <summary>
        /// Create comment for post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Comments")]
        public async Task<IResponse> CreateComment(Guid Id, [FromBody] CreateCommentRequest request)
        {
            var userId = User.GetUserId();

            return await _postService.CreateComment(Id, userId, request);
        }

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Comments/{commentId}")]
        public async Task<IResponse> UpdateComment(Guid Id, Guid commentId, [FromBody] UpdateCommentRequest request)
        {
            var userId = User.GetUserId();

            return await _postService.UpdateComment(Id, commentId, userId, request);
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Comments/{commentId}")]
        public async Task<IResponse> DeleteComment(Guid Id, Guid commentId)
        {
            var userId = User.GetUserId();

            return await _postService.DeleteComment(Id, commentId, userId);
        }
        #endregion

        #region Post Reaction

        /// <summary>
        /// Get all reaction of post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Reactions")]
        public async Task<IResponse> GetAllReactions(Guid Id)
        {
            return await _postService.GetAllReactions(Id);
        }

        /// <summary>
        /// Get reaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Reactions")]
        public async Task<IResponse> GetReactionById(Guid Id, [FromBody] CreatePostReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postService.CreateReaction(Id, userId, request);
        }

        /// <summary>
        /// Update reaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reactionId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> UpdateReaction(Guid Id, int reactionId, [FromBody] CreatePostReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postService.UpdateReaction(Id, userId, reactionId, request);
        }

        /// <summary>
        /// Delete reaction by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reactionId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> DeleteReaction(Guid Id, int reactionId)
        {
            var userId = User.GetUserId();
            return await _postService.DeleteReaction(Id, userId, reactionId);
        }
        #endregion
    }

}
