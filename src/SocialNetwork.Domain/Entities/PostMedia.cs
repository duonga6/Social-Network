namespace SocialNetwork.Domain.Entities;

public class PostMedia : EntityAuditBase<Guid>
{
    public string Title { set; get; }
    public string Url { get; set; }
    public Guid PostId { get; set; }
    public int MediaTypeId { set; get; }
    public string UserId { set; get; }
    public MediaType MediaType { get; set; }

    public virtual User User { set; get; }
    public virtual Post Post { get; set; }
}
