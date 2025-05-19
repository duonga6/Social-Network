using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class PostRepository : SoftDeleteRepository<Post, Guid>, IPostRepository
    {
        public PostRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<Post> GetByIdAsync(Guid id)
        {
            var query = _dbSet.Where(x => !x.IsDeleted && x.Id == id)
                .Include(x => x.PostMedias.Where(i => i.IsDeleted == false))
                .Include(x => x.Author)
                .Include(x => x.SharePost)
                .ThenInclude(x => x.PostMedias.Where(i => i.IsDeleted == false))
                .Include(x => x.SharePost.Author)
                .Include(x => x.Group)
                .AsQueryable();

            return await query
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public override async Task UpdateAsync(Post post)
        {
            var updatePost = await _dbSet.FirstOrDefaultAsync(x => x.Id == post.Id && !x.IsDeleted);
            if (updatePost != null)
            {
                updatePost.Content = post.Content;
                updatePost.Access = post.Access;
                updatePost.ModifiedDate = DateTime.UtcNow;
            }
        }

        public override async Task<ICollection<Post>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<Post, bool>> filter = null, Expression<Func<Post, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.Author)
                .Include(x => x.PostMedias)
                .Include(x => x.SharePost)
                    .ThenInclude(x => x.PostMedias.Where(p => p.IsDeleted == false))
                .Include(x => x.SharePost.Author)
                .AsQueryable();

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
        public async Task<bool> IsOwnerPostAsync(string userId, Guid postId)
        {
            return await _dbSet.AsNoTracking().AnyAsync(x => x.AuthorId == userId && x.Id == postId);
        }
    }
}
