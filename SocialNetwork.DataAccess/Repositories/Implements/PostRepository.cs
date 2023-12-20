using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<Post> GetById(Guid id, bool asNoTracking = true)
        {
            var query = _dbSet.Where(x => x.Status == 1 && x.Id == id)
                .Include(x => x.Images.Where(i => i.Status == 1))
                .AsSplitQuery();

            if (asNoTracking)
            {
                return await query
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }

            return await query
                    .FirstOrDefaultAsync();
        }

        public override async Task<ICollection<Post>> FindBy(Expression<Func<Post, bool>> filter = null, bool asNoTracking = true)
        {
            var query = _dbSet.Where(filter)
                .Include(x => x.Images.Where(i => i.Status == 1))
                .OrderByDescending(x => x.CreatedAt)
                .AsSplitQuery();

            if (asNoTracking)
            {
                return await query.AsNoTracking().ToListAsync();
            }    

            return await query.ToListAsync();
        }

        public override async Task<ICollection<Post>> GetAll(bool asNoTracking)
        {
            var query = _dbSet.Where(x => x.Status == 1)
                .Include(x => x.Images.Where(i => i.Status == 1))
                .AsSplitQuery();

            if ( asNoTracking)
            {
                return await query.AsNoTracking().ToListAsync();
            }

            return await query.ToListAsync();
        }
        
        public override async Task<bool> Delete(Guid id)
        {
            var post = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
            if (post == null) { return false; }

            post.Status = 0;
            post.UpdatedAt = DateTime.UtcNow;

            return true;
        }

        public override async Task<bool> Update(Post post)
        {
            try
            {
                var updatePost = await _dbSet.FirstOrDefaultAsync(x => x.Id == post.Id && x.AuthorId == post.AuthorId && x.Status == 1);
                if (updatePost == null)
                {
                    return false;
                }

                updatePost.Title = post.Title;
                updatePost.Content = post.Content;
                updatePost.UpdatedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function Update", typeof(PostRepository));
                throw;
            }
        }

        public override async Task<ICollection<Post>> GetPaged(int pageSize, int pageNumber, Expression<Func<Post, bool>> filter = null, Expression<Func<Post, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.Author)
                .Include(x => x.Images)
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
