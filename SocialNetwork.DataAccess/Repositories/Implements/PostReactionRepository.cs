using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostReactionRepository : GenericRepository<PostReaction>, IPostReactionRepository
    {
        public PostReactionRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<bool> Add(PostReaction entity)
        {
            if (await _dbSet.AsNoTracking().AnyAsync(x => x.PostId == entity.PostId && x.UserId == entity.UserId))
            {
                return false;
            }

            _dbSet.Add(entity);
            return true;
        }

        public async Task<ICollection<PostReaction>> GetByPost(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.PostId == id)
                .Include(x => x.Reaction)
                .ToListAsync();
        }

        public async Task<ICollection<PostReaction>> GetByUser(string id)
        {
            return await _dbSet.AsNoTracking().Where(x => x.UserId == id).Include(x => x.Reaction).ToListAsync();
        }

        public async Task<PostReaction> GetById(Guid postId, string userId, int reactionId)
        {
            return await _dbSet.Include(x => x.Reaction)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId && x.ReactionId == reactionId);
        }

        public override async Task<bool> Update(PostReaction postReaction)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.PostId == postReaction.PostId && x.UserId == postReaction.UserId);
            if (entity == null)
            {
                return false;
            }

            entity.ReactionId = postReaction.ReactionId;
            entity.UpdatedAt = DateTime.UtcNow;

            return true;
        }

        public async Task<bool> Delete(Guid postId, string userId, int reactionId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId && x.ReactionId == reactionId);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            return true;
        }
    }
}
