using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IResponse> GetById(string requestId, Guid messagesId);
        Task<IResponse> Create(string requestId, CreateMessageRequest request);
        Task<IResponse> Create(string requestId, CreateMessageWithConversationRequest request);
        Task<IResponse> SeenMessage(string requestId, Guid messageId);
        Task<IResponse> RevokeMessage(string requestId, Guid messageId);
        Task<IResponse> Get(string requestId, Guid conversationId, int pageSize, string? searchString, DateTime? cursor);
    }
}
