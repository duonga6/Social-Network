namespace SocialNetwork.Domain.Entities;

public class Friendship : EntityAuditBase<Guid>
{
    public string RequestUserId { get; set; }
    public string TargetUserId { get; set; }
    public FriendshipStatus FriendshipStatus { set; get; }

    public User RequestUser { get; set; }
    public User TargetUser { get; set; }
}
