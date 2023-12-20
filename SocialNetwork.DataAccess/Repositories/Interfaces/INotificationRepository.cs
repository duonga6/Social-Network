using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<bool> Seen(Guid Id);
        Task<ICollection<Notification>> GetUserNotifications(string userId);
    }
}
