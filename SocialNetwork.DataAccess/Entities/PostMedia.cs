using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class PostMedia : BaseEntity<Guid>
    {
        public string Title { set; get; }
        public string Url { get; set; }
        public Guid PostId { get; set; }
        public int MediaTypeId { set; get; }

        public virtual MediaType MediaType { set; get; }
        public virtual Post Post { get; set; }
    }
}
