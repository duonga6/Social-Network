using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class PostImage : BaseEntity
    {
        public string Url { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
