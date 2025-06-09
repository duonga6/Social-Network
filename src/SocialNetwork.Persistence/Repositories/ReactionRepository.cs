namespace SocialNetwork.Persistence.Repositories
{
    public class ReactionRepository : RepositoryBase<Reaction, int>, IReactionRepository
    {
        public ReactionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
