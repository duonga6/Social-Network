namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post, Guid>
    {
        Task<bool> IsOwnerPostAsync(string userId, Guid postId);
    }
}
