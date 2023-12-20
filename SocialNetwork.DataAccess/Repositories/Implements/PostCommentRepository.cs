using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostCommentRepository : GenericRepository<PostComment>, IPostCommentRepository
    {
        public PostCommentRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<ICollection<PostComment>> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .ToListAsync();
            }

            return await _dbSet.Where(x => x.Status == 1)
                    .ToListAsync();
        }

        public override async Task<PostComment> GetById(Guid id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
            }
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
        }

        public override async Task<bool> Update(PostComment entity)
        {
            try
            {
                var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id && x.Status == 1);
                if (entityUpdate == null) 
                {
                    return false;
                }

                entityUpdate.Content = entity.Content;
                entityUpdate.UpdatedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function Update", typeof(PostCommentRepository));
                throw;
            }
        }
    
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
                if (entity == null) { return false; }

                entity.Status = 0;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function Delete", typeof(PostCommentRepository));
                throw;
            }
        }

        public async Task<ICollection<PostComment>> GetByPost(Guid postId)
        {
            var comments = await _dbSet.AsNoTracking()
                .Where(x => x.PostId == postId && x.Status == 1)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return comments;
        }

        public override async Task<ICollection<PostComment>> GetPaged(int pageSize, int pageNumber, Expression<Func<PostComment, bool>> filter = null, Expression<Func<PostComment, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.User)
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
