using Newtonsoft.Json;
using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class PostMedia : BaseEntity<Guid>
    {
        public string Title { set; get; }
        public string Url { get; set; }
        public Guid PostId { get; set; }
        public int MediaTypeId { set; get; }
        public string UserId { set; get; }

        [JsonIgnore]
        public virtual User User { set; get; }
        [JsonIgnore]
        public virtual MediaType MediaType { set; get; }
        [JsonIgnore]
        public virtual Post Post { get; set; }
    }
}
