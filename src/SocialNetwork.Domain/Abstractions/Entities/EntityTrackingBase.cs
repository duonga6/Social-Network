
namespace SocialNetwork.Domain.Abstractions.Entities;

public class EntityTrackingBase<TKey> : EntityBase<TKey>, IEntityTrackingBase<TKey>
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
}
