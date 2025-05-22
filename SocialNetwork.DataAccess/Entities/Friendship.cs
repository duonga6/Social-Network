namespace SocialNetwork.DataAccess.Entities
{
    public class Friendship : EntityAuditBase<Guid>
    {
        public string RequestUserId { get; set; }
        public string TargetUserId { get; set; }
        public int FriendshipTypeId { set; get; }

        public virtual User RequestUser { get; set; }
        public virtual User TargetUser { get; set; }
        public virtual FriendshipType FriendshipType {set;get;}
    }
}
