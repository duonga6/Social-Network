using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Services;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class PostCacheRepository : GenericRepository<Post, Guid>, IPostRepository
    {
        private readonly ICacheService _cacheService;

        public PostCacheRepository(ILogger logger, AppDbContext context, ICacheService cacheService) : base(logger, context)
        {
            _cacheService = cacheService;
        }

        public override async Task<Post> GetById(Guid id)
        {
            string key = "post-" + id.ToString();

            var cacheData = await _cacheService.GetValueAsync(key);

            if (cacheData != null)
            {
                var post = JsonConvert.DeserializeObject<Post>(cacheData);
                return post;
            } 
            else
            {
                var query = _dbSet.Where(x => x.Status == 1 && x.Id == id)
                .Include(x => x.PostMedias.Where(i => i.Status == 1))
                .Include(x => x.Author)
                .Include(x => x.SharePost)
                .ThenInclude(x => x.PostMedias.Where(i => i.Status == 1))
                .Include(x => x.SharePost.Author)
                .AsNoTracking()
                .AsQueryable();

                var post =  await query.FirstOrDefaultAsync();

                await _cacheService.SetKeyAsync(key, post, TimeSpan.FromMinutes(5));
                return post;
            }
        }
    }
}
