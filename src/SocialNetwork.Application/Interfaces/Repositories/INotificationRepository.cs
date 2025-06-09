namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface INotificationRepository : IRepositoryBase<Notification, Guid>
    {
        Task SeenAsync(Guid Id);
        Task<ICollection<Notification>> GetUserNotificationsAsync(string userId);
        Task SeenAllNoticiatioAsync(string userId);
        Task<int> CountNotSeenAsync(string userId);
    }
}
