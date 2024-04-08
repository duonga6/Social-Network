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

        public override async Task Add(CommentReaction entity)
        {
            await _dbSet.AddAsync(entity);
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
    
        public override async Task Update(CommentReaction entity)
        {
            var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.CommentId == entity.CommentId && x.UserId == entity.UserId && x.ReactionId == entity.ReactionId);
            
            if (entityUpdate != null) 
            { 
                entityUpdate.UpdatedAt = DateTime.UtcNow;
                entityUpdate.ReactionId = entity.ReactionId;
            }

        }

        public async Task<ICollection<CommentReaction>> GetByComment(Guid commentId)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.CommentId == commentId)
                .Include(x => x.Reaction)
                .Include(x => x.User)
                .ToListAsync();
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
