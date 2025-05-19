namespace SocialNetwork.DataAccess.Entities
{
    public interface IAuditable : IDateTracking, IUserTracking, ISoftDelete
    {
    }
}
