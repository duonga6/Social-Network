namespace SocialNetwork.Domain.Abstractions.Entities;

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    public TKey Id { get; set; }
}
