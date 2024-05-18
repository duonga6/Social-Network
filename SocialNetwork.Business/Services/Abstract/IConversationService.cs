using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.Services.Abstract
{
    public interface IConversationService
    {
        Task<IResponse> GetConversation(string requestId, int pageSize, string? searchString, DateTime? cursor, ConversationType? type);
        Task<IResponse> GetById(string requestId, Guid conversationId);
        Task<IResponse> GetByUserId(string requestId, string userId);
        Task<IResponse> Create(string requestId, CreateConversationRequest request);
        Task<IResponse> Delete(string requestId, Guid conversationId);
        Task<IResponse> Update(string requestId, Guid conversationId, UpdateConversationRequest request);

        Task<IResponse> GetParticipant(string requestId, Guid id, int pageSize, int pageNumber, string? searchString);
        Task<IResponse> GetParticipantByUserId(string requestId, Guid id, string userId);
        Task<IResponse> GetParticipantById(string requestId, Guid id, Guid participantId);
        Task<IResponse> AddParticipant(string requestId, Guid id, CreateParticipantRequest request);
        Task<IResponse> RemoveParticipant(string requestId, Guid id, Guid participantId);
        Task<IResponse> UpdateParticipant(string requestId, Guid id, Guid participantId, UpdateParticipantRequest request);

        Task<IResponse> GetAdmin(string requestId, Guid id, int pageSize, int pageNumber, string? searchString);
        Task<IResponse> AddAdmin(string requestId, Guid id, CreateConversationAdminRequest request);
        Task<IResponse> RemoveAdmin(string requestId, Guid id, Guid participantId);

        Task<IResponse> GetMessage(string requestId, Guid id, int pageSize, DateTime? cursor, string? searchString);
        Task<IResponse> GetMessageById(string requestId, Guid id, Guid messageId);
        Task<IResponse> CreateMessage(string requestId, Guid id, CreateMessageOnConversationRequest request);
        Task<IResponse> UnsendMessage(string requestId, Guid id, Guid messageId);
        Task<IResponse> SeenMessage(string requestId, Guid id, Guid messageId);
    }
}
