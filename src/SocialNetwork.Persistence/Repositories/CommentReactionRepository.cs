

using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Persistence.Repositories
{
    public class CommentReactionRepository : RepositoryBase<CommentReaction, Guid>, ICommentReactionRepository
    {
        public CommentReactionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<CommentReaction> FindSingleAsync(Guid commentId, string userId, int reactionId)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(
                c => 
                    c.CommentId.Equals(commentId) && 
                    c.CreatedBy.Equals(userId) && 
                    c.ReactionId.Equals(reactionId)
            );
        }

        public async Task<ICollection<CommentReaction>> GetByCommentAsync(Guid commentId)
        {
            return await dbSet
                .AsNoTracking()
                .Where(x => x.CommentId == commentId)
                .Include(x => x.Reaction)
                .Include(x => x.CreatedUser)
                .ToListAsync();
        }
    }
}
