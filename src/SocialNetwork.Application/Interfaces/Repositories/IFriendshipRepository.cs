namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IFriendshipRepository : IRepositoryBase<Friendship, Guid>
    {
        Task<ICollection<Friendship>> GetAllFriendshipAsync(string userId);
        Task<ICollection<string>> GetFriendIdsAsync(string userId);
        Task<FriendshipStatus> GetStatusAsync(string userId1, string userId2);
    }
}
