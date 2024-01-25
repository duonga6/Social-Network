using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class PostComment : BaseEntity<Guid>
    {
        public string Content { set; get; }

        public string UserId { set; get; }
        public virtual User User { set; get; }

        public Guid PostId { set; get; }
        public virtual Post Post { set; get; }

        public virtual ICollection<CommentReaction> Reactions { set; get; }
    }
}
