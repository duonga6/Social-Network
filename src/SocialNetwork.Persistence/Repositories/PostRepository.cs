namespace SocialNetwork.Persistence.Repositories
{
    internal class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<bool> IsOwnerPostAsync(string userId, Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}
