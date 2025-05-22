using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IPostReactionRepository : IGenericRepository<PostReaction, Guid>
    {
        Task<ICollection<PostReaction>> GetByPostAsync(Guid postId);
        Task<ICollection<PostReaction>> GetByUserAsync(string userId);
        Task<ICollection<int>> GetTypeReactionAsync(Guid postId);
        Task<PostReaction> GetByIdAsync(Guid postId, string userId, bool noTracking = true);
        Task DeleteAsync(Guid postId, string userId);
    }
}
