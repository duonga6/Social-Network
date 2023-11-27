using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<PostReaction> Reactions { get; set; }
        public virtual ICollection<PostImage> Images { get; set; }
    }
}
