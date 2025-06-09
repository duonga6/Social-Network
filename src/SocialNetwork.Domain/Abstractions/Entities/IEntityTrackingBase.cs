namespace SocialNetwork.Domain.Abstractions.Entities;

public interface IEntityTrackingBase<TKey> : IEntityBase<TKey>, IDateTracking, IUserTracking
{
}
