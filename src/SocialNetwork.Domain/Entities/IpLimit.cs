namespace SocialNetwork.Domain.Entities;

public class IPLimit : EntityTrackingBase<Guid>
{
    public string IpAddress { set; get; }
}
