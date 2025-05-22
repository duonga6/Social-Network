namespace SocialNetwork.DataAccess.Entities
{
    public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IEntityAuditBase<TKey>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
