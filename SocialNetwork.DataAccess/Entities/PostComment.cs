using Newtonsoft.Json;

namespace SocialNetwork.DataAccess.Entities
{
    public class PostComment : EntityAuditBase<Guid>
    {
        public string Content { set; get; }

        public string UserId { set; get; }
        public virtual User User { set; get; }
        public string Path { set; get; }

        public Guid PostId { set; get; }
        public virtual Post Post { set; get; }

        public Guid? ParentCommentId { set; get; }
        public virtual PostComment ParentComment { set; get; }

        [JsonIgnore]
        public virtual ICollection<CommentReaction> Reactions { set; get; }
        [JsonIgnore]
        public virtual ICollection<PostComment> ChildrenComment { set; get; }
    }
}
