namespace SocialNetwork.DataAccess.Entities
{
    public abstract class EntityTrackingBase<TKey> : EntityBase<TKey>, ITracking
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
