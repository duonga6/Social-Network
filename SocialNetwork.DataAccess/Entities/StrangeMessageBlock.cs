namespace SocialNetwork.DataAccess.Entities
{
    public class StrangeMessageBlock : BaseEntity<Guid>
    {
        /// <summary>
        /// FromId Block ToId
        /// </summary>
        public string FromId { set; get; }
        public string ToId { set; get; }

        /// <summary>
        /// ToId has been blocked by FromId
        /// </summary>
        public User FromUser { set; get; }
        public User ToUser { set; get; }
    }
}
