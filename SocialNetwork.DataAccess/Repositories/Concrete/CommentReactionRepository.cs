using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class CommentReactionRepository : GenericRepository<CommentReaction, Guid>, ICommentReactionRepository
    {
        public CommentReactionRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task AddAsync(CommentReaction entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public override async Task<CommentReaction> GetByIdAsync(Guid id)
        {
                return await _dbSet
                    .AsNoTracking()
                    .Include(x => x.Reaction)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CommentReaction> GetByIdAsync(Guid commentId, string userId, int reactionId)
        {
            return await _dbSet.AsNoTracking()
                .Include(x => x.Reaction)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.CommentId == commentId && x.UserId == userId && x.ReactionId == reactionId);
        }
    
        public override async Task UpdateAsync(CommentReaction entity)
        {
            var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            
            if (entityUpdate != null) 
            { 
                entityUpdate.ModifiedDate = DateTime.UtcNow;
                entityUpdate.ReactionId = entity.ReactionId;
            }

        }

        public async Task<ICollection<CommentReaction>> GetByCommentAsync(Guid commentId)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.CommentId == commentId)
                .Include(x => x.Reaction)
                .Include(x => x.User)
                .ToListAsync();
        }

        public override async Task<ICollection<CommentReaction>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<CommentReaction, bool>> filter = null, Expression<Func<CommentReaction, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.User)
                .Include(x => x.Reaction)
                .AsSplitQuery();

            if (isDesc)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);

            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override async Task<CommentReaction> FindOneByAsync(Expression<Func<CommentReaction, bool>> filter = null)
        {
                return await _dbSet
                    .AsNoTracking()
                    .Include(x => x.Reaction)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(filter);
        }
    }
}
