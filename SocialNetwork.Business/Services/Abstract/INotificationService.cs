using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface INotificationService
    {
        Task<bool> CreateNotification(string fromUserId, string toUserId, NotificationEnum type, object notifiable);
        Task<IResponse> GetNotifications(string userId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> SeenNotification(string userId, Guid id);
        Task<IResponse> GetById(string userId, Guid id);
        Task<IResponse> GetCursor(string requestUserId, int pageSize, DateTime? cursor, bool getNext);
    }
}
