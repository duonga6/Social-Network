using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface INotificationRepository : IGenericRepository<Notification, Guid>
    {
        Task Seen(Guid Id);
        Task<ICollection<Notification>> GetUserNotifications(string userId);
        Task SeenAllNoticiation(string userId);
        Task<int> CountNotSeen(string userId);
    }
}
