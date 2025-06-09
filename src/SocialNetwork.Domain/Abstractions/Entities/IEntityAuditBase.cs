namespace SocialNetwork.Domain.Abstractions.Entities;

internal interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IAuditable
{
}
