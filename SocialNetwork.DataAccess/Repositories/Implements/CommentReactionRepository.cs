using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class CommentReactionRepository : GenericRepository<CommentReaction, Guid>, ICommentReactionRepository
    {
        public CommentReactionRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<bool> Add(CommentReaction entity)
        {
            if (await _dbSet.AnyAsync(x => x.UserId == entity.UserId && x.CommentId == entity.CommentId)) 
            {
                return false;
            }

            await _dbSet.AddAsync(entity);
            return true;
        }

        public override async Task<CommentReaction> GetById(Guid id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet
                    .AsNoTracking()
                    .Include(x => x.Reaction)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }

            return await _dbSet
                   .Include(x => x.Reaction)
                   .Include(x => x.User)
                   .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CommentReaction> GetById(Guid commentId, string userId, int reactionId)
        {
            return await _dbSet.AsNoTracking()
                .Include(x => x.Reaction)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.CommentId == commentId && x.UserId == userId && x.ReactionId == reactionId);
        }
    
        public override async Task<bool> Update(CommentReaction entity)
        {
            var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.CommentId == entity.CommentId && x.UserId == entity.UserId && x.ReactionId == entity.ReactionId);
            if (entityUpdate == null) { return false; }

            entityUpdate.UpdatedAt = DateTime.UtcNow;
            entityUpdate.ReactionId = entity.ReactionId;

            return true;
        }

        public async Task<bool> Delete(Guid commentId, string userId, int reactionId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.CommentId == commentId && x.UserId == userId && x.ReactionId == reactionId);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return true;
        }

        public async Task<ICollection<CommentReaction>> GetByComment(Guid commentId)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.CommentId == commentId)
                .Include(x => x.Reaction)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<ICollection<int>> GetTypeReaction(Guid commentId)
        {
            return await _dbSet.AsNoTracking().Where(x => x.CommentId == commentId).Select(x => x.ReactionId).Distinct().ToListAsync();
        }

        public override async Task<ICollection<CommentReaction>> GetPaged(int pageSize, int pageNumber, Expression<Func<CommentReaction, bool>> filter = null, Expression<Func<CommentReaction, object>> orderBy = null, bool isDesc = true)
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

        public override async Task<CommentReaction> FindOneBy(Expression<Func<CommentReaction, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet
                    .AsNoTracking()
                    .Include(x => x.Reaction)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(filter);
            }
            return await _dbSet
                .Include(x => x.User)
                 .Include(x => x.Reaction)
                .FirstOrDefaultAsync(filter);
        }
    }
}
