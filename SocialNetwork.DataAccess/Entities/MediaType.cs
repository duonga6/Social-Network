namespace SocialNetwork.DataAccess.Entities
{
    public class MediaType : EntityTrackingBase<int>
    {
        public string Name { set; get; }

        public virtual ICollection<PostMedia> PostMedias { set; get; }
        public virtual ICollection<Message> Messages { set; get; }
    }
}
