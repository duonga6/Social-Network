using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface ICommentReactionService
    {
        Task<IResponse> GetById(string requestUserId, Guid id);
        Task<IResponse> Create(string requestUserId, CreateCommentReactionRequests request);
        Task<IResponse> Update(string requestUserId, Guid id, UpdateCommentReactionRequest request);
        Task<IResponse> Delete(string requestUserId, Guid id);
        Task<IResponse> GetOverview(string requestUserId, Guid id);
    }
}
