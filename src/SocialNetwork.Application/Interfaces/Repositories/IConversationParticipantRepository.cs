namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IConversationParticipantRepository : IRepositoryBase<ConversationParticipant, Guid>
    {
        Task<List<Guid>> GetConversationParticipantIdsAsync(Guid conversationId);
        Task AddParticipantExistedAsync(Guid id);
    }
}
