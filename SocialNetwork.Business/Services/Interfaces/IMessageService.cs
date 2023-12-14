using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IResponse> GetAll(string requestUserId, string targetUserId);
        Task<IResponse> SendMessage(string requestUserId, SendMessageRequest request);
        Task<IResponse> DeleteMessage(string requestUserId, Guid id);
    }
}
