using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class PostMediaRepository : GenericRepository<PostMedia, Guid>, IPostMediaRepository
    {
        public PostMediaRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task Update(PostMedia media)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == media.Id);
            if (entity != null)
            {
                entity.Url = media.Url;
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
