using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public abstract class SoftDeleteRepository<TEntity, TKey> : GenericRepository<TEntity, TKey>, ISoftDeleteRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey>, IDateTracking, ISoftDelete
    {
        protected SoftDeleteRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task RestoreEntityAsync(TKey id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity != null)
            {
                entity.IsDeleted = false;
            }
        }

        public async Task SoftDeleteAsync(TKey id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity != null)
            {
                entity.IsDeleted = true;
            }    
        }
    }
}
