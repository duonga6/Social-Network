using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostReactionService 
    {
        Task<IResponse> GetCount(string requestUserId, Guid postId);
        Task<IResponse> GetByUser(string requestUserId, Guid postId);
        Task<IResponse> GetByPost(string requestUserId, Guid postId);
        Task<IResponse> Create(string requestUserId, CreatePostReactionsRequest request);
        Task<IResponse> Update(string requestUserId, UpdatePostReactionRequest request);
        Task<IResponse> Delete(string requestUserId, Guid postId);
    }
}
