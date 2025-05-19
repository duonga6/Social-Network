using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class PostCommentRepository : SoftDeleteRepository<PostComment, Guid>, IPostCommentRepository
    {
        public PostCommentRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<PostComment> GetByIdAsync(Guid id)
        {
           return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public override async Task UpdateAsync(PostComment entity)
        {
            var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id && !x.IsDeleted);
            if (entityUpdate != null)
            {
                entityUpdate.Content = entity.Content;
                entityUpdate.ModifiedDate = DateTime.UtcNow;
            }
        }

        public async Task<ICollection<PostComment>> GetByPostAsync(Guid postId)
        {
            var comments = await _dbSet.AsNoTracking()
                .Where(x => x.PostId == postId && !x.IsDeleted && x.ParentCommentId == null)
                .Include(x => x.User)
                .Include(x => x.ChildrenComment)
                .ThenInclude(x => x.User)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return comments;
        }

        public override async Task<ICollection<PostComment>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<PostComment, bool>> filter = null, Expression<Func<PostComment, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.User)
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

        public override async Task DeleteAsync(Guid id)
        {
            await UpdateDeep(_dbSet, id);
        }

        private async Task UpdateDeep(DbSet<PostComment> dbSet, Guid id)
        {
            var comment = await _dbSet.Include(x => x.ChildrenComment).FirstOrDefaultAsync(x => x.Id == id);

            if (comment != null)
            {
                comment.IsDeleted = true;
                if (comment.ChildrenComment != null)
                {
                    foreach (var item in comment.ChildrenComment)
                    {
                        await UpdateDeep(dbSet, item.Id);
                    }
                }
            }
        }


        public override async Task<ICollection<PostComment>> GetCursorPagedAsync(int pageSize, Expression<Func<PostComment, bool>> filter, bool getNext = true)
        {
            var query = _dbSet.AsNoTracking().Where(filter).Include(x => x.User);
            if (getNext)
            {
                return await query.OrderByDescending(x => x.CreatedDate).ThenByDescending(x => x.Id).Take(pageSize).ToListAsync();
            }
            else
            {
                var result = await query.OrderBy(x => x.CreatedDate).ThenBy(x => x.Id).Take(pageSize).ToListAsync();
                result.Reverse();
                return result;
            }
        }

    }

}
