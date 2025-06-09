namespace SocialNetwork.Domain.Entities;

public class GroupInvite : EntityAuditBase<Guid>
{
    public Guid GroupId { set; get; }
    public string UserId { set; get; }
    public bool AdminAccepted { set; get; }
    public bool UserAccepted { set; get; }

    public Group Group { set; get; }
    public User User { get; set; }
    public User CreatedUser { set; get; }
}
