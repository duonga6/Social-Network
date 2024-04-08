using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IPostReactionService 
    {
        Task<IResponse> GetCount(string requestUserId, Guid postId);
        Task<IResponse> GetByUser(string requestUserId, Guid postId);
        Task<IResponse> GetByPost(string requestUserId, Guid postId);
        Task<IResponse> GetOverview(string requestUserId, Guid postId);
        Task<IResponse> Create(string requestUserId, CreatePostReactionsRequest request);
        Task<IResponse> Update(string requestUserId, Guid id, UpdatePostReactionRequest request);
        Task<IResponse> Delete(string requestUserId, Guid postId);
    }
}
