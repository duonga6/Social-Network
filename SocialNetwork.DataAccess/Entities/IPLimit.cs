namespace SocialNetwork.DataAccess.Entities
{
    public class IPLimit : EntityTrackingBase<Guid>
    {
        public string IpAddress { set; get; }
    }
}
