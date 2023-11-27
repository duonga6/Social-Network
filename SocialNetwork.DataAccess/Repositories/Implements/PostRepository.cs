using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<Post> GetById(Guid id)
        {
            return await _dbSet.Where(x => x.Status == 1 && x.Id == id)
                .Include(x => x.Images.Where(i => i.Status == 1))
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public override async Task<ICollection<Post>> FindBy(Expression<Func<Post, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(filter)
                .Include(x => x.Images.Where(i => i.Status == 1))
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync(cancellationToken);
        }

        public override async Task<ICollection<Post>> GetAll()
        {
            return await _dbSet.Where(x => x.Status == 1)
                .Include(x => x.Images)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }
        
        public override async Task<bool> Delete(Guid id)
        {
            var post = await _dbSet.FindAsync(id);
            if (post == null) { return false; }

            post.Status = 0;
            post.UpdatedAt = DateTime.UtcNow;

            return true;
        }

        public override async Task<bool> Update(Post post)
        {
            try
            {
                var updatePost = await _dbSet.FirstOrDefaultAsync(x => x.Id == post.Id && x.AuthorId == post.AuthorId);
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
    }
}
