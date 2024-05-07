namespace SocialNetwork.DataAccess.Entities
{
    public class MediaType : BaseEntity<int>
    {
        public string Name { set; get; }

        public virtual ICollection<PostMedia> PostMedias { set; get; }
        public virtual ICollection<Message> Messages { set; get; }
    }
}
