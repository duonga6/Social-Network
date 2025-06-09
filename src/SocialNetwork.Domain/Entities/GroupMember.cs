namespace SocialNetwork.Domain.Entities;

public class GroupMember : EntityAuditBase<Guid>
{
    public Guid GroupId { set; get; }
    public string UserId { set; get; }
    public bool IsAdmin { set; get; }
    public bool IsSuperAdmin { set; get; }


    public virtual Group Group { set; get; }
    public virtual User User { set; get; }
}
