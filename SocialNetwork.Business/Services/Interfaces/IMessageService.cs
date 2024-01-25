using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IResponse> GetByUser(string requestUserId, string targetUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> SendMessage(string requestUserId, SendMessageRequest request);
        Task<IResponse> RevokeMessage(string requestUserId, Guid id);
        Task<IResponse> GetById(string requestUserId, Guid id);
    }
}
