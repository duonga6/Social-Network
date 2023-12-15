using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface INotificationService
    {
        Task<bool> CreateNotification(string fromUserId, string toUserId, TypeNotification type);
        Task<IResponse> GetNotifications(string userId);
        Task<IResponse> SeenNotification(string userId, Guid id);
        Task<IResponse> GetById(string userId, Guid id);
    }
}
