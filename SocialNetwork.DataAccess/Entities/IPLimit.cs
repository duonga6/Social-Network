namespace SocialNetwork.DataAccess.Entities
{
    public class IPLimit : BaseEntity<Guid>
    {
        public string IpAddress { set; get; }
    }
}
