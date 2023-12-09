using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

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
                var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id && x.PostId == entity.PostId && x.UserId == entity.UserId && x.Status == 1);
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
    }
}
