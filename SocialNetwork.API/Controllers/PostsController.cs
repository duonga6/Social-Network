using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;

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
        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _postService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _postService.GetById(Id);
        }

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

        [HttpPut("{Id}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostRequest request)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return new ErrorResponse(401, Messages.UnAuthorized);
            }

            request.AuthorId = userId;
            return await _postService.Update(Id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return new ErrorResponse(401, Messages.UnAuthorized);
            }

            return await _postService.Delete(userId, Id);
        }
        #endregion

        #region Post Comment
        [HttpGet("{Id}/Comments")]
        public async Task<IResponse> GetAllComment(Guid Id)
        {
            return await _postService.GetAllComments(Id);
        }

        [HttpGet("{Id}/Comments/{commentId}")]
        public async Task<IResponse> GetComment(Guid Id, Guid commentId) 
        { 
            return await _postService.GetCommentById(Id, commentId);
        }

        [HttpPost("{Id}/Comments")]
        public async Task<IResponse> CreateComment(Guid Id, [FromBody] CreateCommentRequest request)
        {
            var userId = User.GetUserId();

            return await _postService.CreateComment(Id, userId, request);
        }

        [HttpPut("{Id}/Comments/{commentId}")]
        public async Task<IResponse> UpdateComment(Guid Id, Guid commentId, [FromBody] UpdateCommentRequest request)
        {
            var userId = User.GetUserId();

            return await _postService.UpdateComment(Id, commentId, userId, request);
        }

        [HttpDelete("{Id}/Comments/{commentId}")]
        public async Task<IResponse> DeleteComment(Guid Id, Guid commentId)
        {
            var userId = User.GetUserId();

            return await _postService.DeleteComment(Id, commentId, userId);
        }
        #endregion

        #region Post Reaction
        [HttpGet("{Id}/Reactions")]
        public async Task<IResponse> GetAllReactions(Guid Id)
        {
            return await _postService.GetAllReactions(Id);
        }

        [HttpPost("{Id}/Reactions")]
        public async Task<IResponse> GetReactionById(Guid Id, CreatePostReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postService.CreateReaction(Id, userId, request);
        }

        [HttpPut("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> UpdateReaction(Guid Id, int reactionId, CreatePostReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postService.UpdateReaction(Id, userId, reactionId, request);
        }

        [HttpDelete("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> DeleteReaction(Guid Id, int reactionId)
        {
            var userId = User.GetUserId();
            return await _postService.DeleteReaction(Id, userId, reactionId);
        }
        #endregion
    }

}
