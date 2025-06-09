namespace SocialNetwork.Domain.Entities;

public class Post : EntityAuditBase<Guid>
{
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public Guid? GroupId { set; get; }
    public PostAccess Access { set; get; }
    public Guid? SharePostId { set; get; }

    public User Author { get; set; }
    public Group Group { set; get; }
    public Post SharePost { set; get; }

    public ICollection<PostReaction> Reactions { get; set; }
    public ICollection<PostMedia> PostMedias { get; set; }
    public ICollection<PostComment> Comments { set; get; }
}
