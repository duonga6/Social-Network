using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(Guid id);
        Task<IResponse> Create(CreatePostRequest request);
        Task<IResponse> Update(Guid id, UpdatePostRequest request);
        Task<IResponse> Delete(string userId, Guid postId);


        Task<IResponse> GetAllComments(Guid postId);
        Task<IResponse> GetCommentById(Guid postId, Guid commentId);
        Task<IResponse> CreateComment(Guid postId, string userId, CreateCommentRequest request);
        Task<IResponse> UpdateComment(Guid postId, Guid commentId, string userId, UpdateCommentRequest request);
        Task<IResponse> DeleteComment(Guid postId, Guid commentId, string userId);

        Task<IResponse> GetAllReactions(Guid postId);
        Task<IResponse> GetReactionById(Guid postId, string userId, int reactionId);
        Task<IResponse> CreateReaction(Guid postId, string userId, CreatePostReactionRequest request);
        Task<IResponse> UpdateReaction(Guid postId, string userId,int reactionId, CreatePostReactionRequest request);
        Task<IResponse> DeleteReaction(Guid postId, string userId, int reactionId);
    }
}
