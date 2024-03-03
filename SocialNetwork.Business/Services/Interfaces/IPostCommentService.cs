using SocialNetwork.Business.DTOs.CommentReactions.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostCommentService
    {
        Task<IResponse> GetAll(string requestUserId, string? searchString, int pageSize, int pageNumber, Guid postId);
        Task<IResponse> GetCursor(string requestUserId, int pageSize, DateTime? endCursor, bool desc, Guid postId, Guid? parentId);
        Task<IResponse> GetCount(string requestUserId, Guid Id);
        Task<IResponse> GetCountChild(string requestUserId, Guid commentId);
        Task<IResponse> GetChild(string requestUserId, string? searchString, int pageSize, int pageNumber, Guid Id);
        Task<IResponse> GetOverviewReaction(string requestUserId, Guid commentId);
        Task<IResponse> GetById(string requestUserId, Guid id);
        Task<IResponse> Create(string requestUserId, CreatePostCommentRequest request);
        Task<IResponse> Update(string requestUserId, Guid id, UpdatePostCommentRequest request);
        Task<IResponse> Delete(string requestUserId, Guid id);

        Task<IResponse> GetReactions(string requestUserId, Guid postId, int pageSize, int pageNumber);
        Task<IResponse> GetReactionById(string requestUserId, Guid commentId, int reactionId);
        Task<IResponse> CreateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request);
        Task<IResponse> UpdateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request);
        Task<IResponse> DeleteReaction(string requestUserId, Guid commentId, int reactionId);

    }
}
