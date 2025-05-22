namespace SocialNetwork.DataAccess.Entities
{
    public interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IAuditable
    {
    }
}
