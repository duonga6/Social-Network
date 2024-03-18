using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Post : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public Guid? GroupId { set; get; }
        public string Privacy { set; get; }
        
        public virtual User Author { get; set; }
        public virtual Group Group { set; get; }
        public virtual ICollection<PostReaction> Reactions { get; set; }
        public virtual ICollection<PostMedia> PostMedias { get; set; }
        public virtual ICollection<SharePost> SharePosts { set; get; }
    }
}
