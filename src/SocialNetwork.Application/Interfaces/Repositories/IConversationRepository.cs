namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IConversationRepository : IRepositoryBase<Conversation, Guid>
    {
        Task UpdateNewestMessageAsync(Guid conversationId);
    }
}
