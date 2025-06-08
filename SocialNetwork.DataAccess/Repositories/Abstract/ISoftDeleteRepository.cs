namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface ISoftDeleteRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        Task SoftDeleteAsync(TKey id);
        Task RestoreEntityAsync(TKey id);
    }
}
