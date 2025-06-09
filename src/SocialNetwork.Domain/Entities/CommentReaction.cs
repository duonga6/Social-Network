namespace SocialNetwork.Domain.Entities;

public class CommentReaction : EntityTrackingBase<Guid>
{
    public int ReactionId { get; set; }
    public Reaction Reaction { get; set; }

    public Guid CommentId { get; set; }
    public virtual PostComment Comment { get; set; }

    public virtual User CreatedUser { get; set; }
}
