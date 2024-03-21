using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostImageRepository : GenericRepository<PostMedia, Guid>, IPostImageRepository
    {
        public PostImageRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<ICollection<PostMedia>> GetAll(bool asNoTracking = true)
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

        public override async Task Update(PostMedia post)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == post.Id && x.Status == 1);
            if (entity == null) 
            { 
                entity.Url = post.Url;
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
