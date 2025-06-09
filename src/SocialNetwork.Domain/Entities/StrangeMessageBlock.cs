namespace SocialNetwork.Domain.Entities;

public class StrangeMessageBlock : EntityAuditBase<Guid>
{
    /// <summary>
    /// FromId Block ToId
    /// </summary>
    public string FromId { set; get; }

    /// <summary>
    /// ToId has been blocked by FromId
    /// </summary>
    public string ToId { set; get; }

    public User FromUser { set; get; }
    public User ToUser { set; get; }
}
