using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface ISoftDeleteRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey>, IDateTracking, ISoftDelete
    {
        Task SoftDeleteAsync(TKey id);
        Task RestoreEntityAsync(TKey id);
    }
}
