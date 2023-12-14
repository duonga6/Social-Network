namespace SocialNetwork.Business.Services.Interfaces
{
    public interface INotificationService
    {
        Task<bool> CreateNotification(string userId);
    }
}
