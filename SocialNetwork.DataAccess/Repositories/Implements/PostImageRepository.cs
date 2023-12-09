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

        public override async Task<ICollection<PostImage>> GetAll(bool asNoTracking = true)
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

        public override async Task<bool> Delete(Guid Id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == Id && x.Status == 1);
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
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == post.Id && x.Status == 1);
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
