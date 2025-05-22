using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface INotificationRepository : IGenericRepository<Notification, Guid>
    {
        Task SeenAsync(Guid Id);
        Task<ICollection<Notification>> GetUserNotificationsAsync(string userId);
        Task SeenAllNoticiatioAsync(string userId);
        Task<int> CountNotSeenAsync(string userId);
    }
}
