using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostReactionRepository : GenericRepository<PostReaction, Guid>, IPostReactionRepository
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
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<ICollection<PostReaction>> GetByUser(string id)
        {
            return await _dbSet.AsNoTracking().Where(x => x.UserId == id).Include(x => x.Reaction).ToListAsync();
        }

        public async Task<ICollection<int>> GetTypeReaction(Guid postId)
        {
            return await _dbSet.AsNoTracking().Where(x => x.PostId == postId).Select(x => x.ReactionId).Distinct().ToListAsync();
        }

        public async Task<PostReaction> GetById(Guid postId, string userId, bool noTracking = true)
        {
            if (noTracking)
            return await _dbSet.Include(x => x.Reaction)
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);

            return await _dbSet.Include(x => x.Reaction)
                .FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);
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

        public async Task Delete(Guid postId, string userId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);
            _dbSet.Remove(entity);
        }

        public override async Task<PostReaction> FindOneBy(Expression<Func<PostReaction, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet
                    .AsNoTracking()
                    .Where(filter)
                    .Include(x => x.Reaction)
                    .FirstOrDefaultAsync();
            }
            return await _dbSet
                .Where(filter)
                .Include(x => x.Reaction)
                .FirstOrDefaultAsync();
        }

        public override async Task<ICollection<PostReaction>> FindBy(Expression<Func<PostReaction, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet
                    .AsNoTracking()
                    .Where(filter)
                    .Include(x => x.Reaction)
                    .Include(x => x.User)
                    .ToListAsync();
            }
            return await _dbSet
                    .Include(x => x.Reaction)
                    .Include(x => x.User)
                    .Where(filter)
                    .ToListAsync();
        }

        public override async Task<ICollection<PostReaction>> GetPaged(int pageSize, int pageNumber, Expression<Func<PostReaction, bool>> filter = null, Expression<Func<PostReaction, object>> orderBy = null, bool isDesc = true)
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
    }
}
