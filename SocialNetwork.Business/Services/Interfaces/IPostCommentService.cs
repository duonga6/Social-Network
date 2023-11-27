using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostCommentService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(Guid id);
        Task<IResponse> Create(CreatePostCommentRequest request);
        Task<IResponse> Update(Guid id, UpdatePostCommentRequest request);
        Task<IResponse> Delete(Guid id);

        Task<IResponse> GetReactions(Guid postId);
        Task<IResponse> GetReactionById(Guid commentId, string userId, int reactionId);
        Task<IResponse> CreateReaction(Guid commentId, string userId, CreateCommentReactionRequest request);
        Task<IResponse> UpdateReaction(Guid commentId, string userId, CreateCommentReactionRequest request);
        Task<IResponse> DeleteReaction(Guid commentId, string userId, int reactionId);

    }
}
