using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

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
        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _postCommentService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id) 
        {
            return await _postCommentService.GetById(Id);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreatePostCommentRequest request)
        {
            return await _postCommentService.Create(request);
        }

        [HttpPut("{Id}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostCommentRequest request)
        {
            return await _postCommentService.Update(Id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _postCommentService.Delete(Id);
        }

        #endregion

        #region Reaction

        [HttpGet("{Id}/Reactions")]
        public async Task<IResponse> GetAllReactions(Guid Id)
        {
            return await _postCommentService.GetReactions(Id);
        }

        [HttpPost("{Id}/Reactions")]
        public async Task<IResponse> CreateReaction(Guid Id, [FromBody] CreateCommentReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postCommentService.CreateReaction(Id, userId, request);
        }

        [HttpPut("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> UpdateReaction(Guid Id, [FromBody] CreateCommentReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postCommentService.UpdateReaction(Id, userId, request);
        }

        [HttpDelete("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> DeleteReaction(Guid Id, int reactionId)
        {
            var userId = User.GetUserId();
            return await _postCommentService.DeleteReaction(Id, userId, reactionId);
        }

        #endregion

    }
}
