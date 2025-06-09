using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Persistence.Repositories
{
    internal class PostReactionRepository : RepositoryBase<PostReaction, Guid>, IPostReactionRepository
    {
        public PostReactionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task DeleteAsync(Guid postId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<PostReaction> GetByIdAsync(Guid postId, string userId, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PostReaction>> GetByPostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PostReaction>> GetByUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<int>> GetTypeReactionAsync(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}
