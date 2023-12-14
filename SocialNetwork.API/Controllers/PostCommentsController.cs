using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;

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
        /// Get all comment in DB (admin only)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = RoleName.Administrator)]
        public async Task<IResponse> GetAll()
        {
            return await _postCommentService.GetAll();
        }

        /// <summary>
        /// Get comment by Id (post owner || post owner's friend || admin)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id) 
        {
            return await _postCommentService.GetById(UserId, Id);
        }

        /// <summary>
        /// Create comment (post owner || post owner's friend || admin)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreatePostCommentRequest request)
        {
            return await _postCommentService.Create(UserId, request);
        }

        /// <summary>
        /// Update comment (post owner || post owner's friend || admin)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IResponse> Update(Guid Id, [FromBody] UpdatePostCommentRequest request)
        {
            return await _postCommentService.Update(UserId, Id, request);
        }

        /// <summary>
        /// Delete comment (post owner || post owner's friend || admin)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _postCommentService.Delete(UserId, Id);
        }

        #endregion

        #region Reaction

        /// <summary>
        /// Get reaction of comment (post owner || post owner's friend || admin)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Reactions")]
        public async Task<IResponse> GetAllReactions(Guid Id)
        {
            return await _postCommentService.GetReactions(UserId, Id);
        }

        /// <summary>
        /// Create reaction for comment (post owner || post owner's friend)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Reactions")]
        public async Task<IResponse> CreateReaction(Guid Id, [FromBody] CreateCommentReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postCommentService.CreateReaction(Id, userId, request);
        }

        /// <summary>
        /// Update reaction for comment (owner reaction)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> UpdateReaction(Guid Id, [FromBody] CreateCommentReactionRequest request)
        {
            var userId = User.GetUserId();
            return await _postCommentService.UpdateReaction(Id, userId, request);
        }

        /// <summary>
        /// Delete reaction for comment (owner reaction)
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reactionId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Reactions/{reactionId}")]
        public async Task<IResponse> DeleteReaction(Guid Id, int reactionId)
        {
            var userId = User.GetUserId();
            return await _postCommentService.DeleteReaction(Id, userId, reactionId);
        }

        #endregion

    }
}
