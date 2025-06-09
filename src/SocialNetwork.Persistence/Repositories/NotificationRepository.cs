namespace SocialNetwork.Persistence.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification, Guid>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<int> CountNotSeenAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Notification>> GetUserNotificationsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task SeenAllNoticiatioAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task SeenAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
