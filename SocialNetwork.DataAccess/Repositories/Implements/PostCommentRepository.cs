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

        public override async Task<ICollection<PostComment>> GetAll()
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<bool> Update(PostComment entity)
        {
            try
            {
                var entityUpdate = await _dbSet.FindAsync(entity.Id);
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
                var entity = await _dbSet.FindAsync(id);
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
