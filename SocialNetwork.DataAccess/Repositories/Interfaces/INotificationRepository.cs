using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface INotificationRepository : IGenericRepository<NotificationService>
    {
        Task<bool> Seen(Guid Id);
        Task<ICollection<NotificationService>> GetUserNotifications(string userId);
    }
}
