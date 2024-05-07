using Newtonsoft.Json;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class Post : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public Guid? GroupId { set; get; }
        public PostAccess Access { set; get; }
        public Guid? SharePostId { set; get; }
        
        public virtual User Author { get; set; }
        public virtual Group Group { set; get; }
        public virtual Post SharePost { set; get; }

        [JsonIgnore]
        public virtual ICollection<PostReaction> Reactions { get; set; }
        public virtual ICollection<PostMedia> PostMedias { get; set; }
    }
}
