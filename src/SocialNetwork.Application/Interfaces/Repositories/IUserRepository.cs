namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        Task UpdateCoverImageAsync(string id, string url);
        Task UpdateAvatarAsync(string id, string url);
        Task SetLockoutEndDateAsync(string id, DateTime? time);
    }
}
