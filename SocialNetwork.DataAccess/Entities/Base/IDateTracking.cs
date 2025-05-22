namespace SocialNetwork.DataAccess.Entities
{
    public interface IDateTracking
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
