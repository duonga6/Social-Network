using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostImageRepository : GenericRepository<PostImage>, IPostImageRepository
    {
        public PostImageRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<ICollection<PostImage>> GetAll()
        {
            return await _dbSet.Where(x => x.Status == 1).AsNoTracking().ToListAsync();
        }

        public override async Task<bool> Delete(Guid Id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
                if (entity == null) { return false; }

                entity.Status = 0;
                entity.UpdatedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function Delete", typeof(PostImageRepository));
                throw;
            }
        }

        public override async Task<bool> Update(PostImage post)
        {
            try
            {
                var entity = await _dbSet.FindAsync(post.Id);
                if (entity == null) { return false; }

                entity.Url = post.Url;
                entity.UpdatedAt = DateTime.UtcNow;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{repo} error function Update", typeof(PostImageRepository));
                throw;
            }
        }
    }
}
