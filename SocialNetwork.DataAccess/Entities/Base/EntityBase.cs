namespace SocialNetwork.DataAccess.Entities
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
