using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostCommentService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(string requestUserId, Guid id);
        Task<IResponse> Create(string requestUserId, CreatePostCommentRequest request);
        Task<IResponse> Update(string requestUserId, Guid id, UpdatePostCommentRequest request);
        Task<IResponse> Delete(string requestUserId, Guid id);

        Task<IResponse> GetReactions(string requestUserId, Guid postId);
        Task<IResponse> GetReactionById(string requestUserId, Guid commentId, int reactionId);
        Task<IResponse> CreateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request);
        Task<IResponse> UpdateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request);
        Task<IResponse> DeleteReaction(string requestUserId, Guid commentId, int reactionId);

    }
}
