using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostMediaRepository : GenericRepository<PostMedia, Guid>, IPostMediaRepository
    {
        public PostMediaRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task DeleteByPostId(Guid postId)
        {
            await _dbSet.Where(x => x.PostId == postId).UpdateFromQueryAsync(x => new() { Status = 0 });
        }
    }
}
