using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IPostRepository : ISoftDeleteRepository<Post, Guid>
    {
        Task<bool> IsOwnerPostAsync(string userId, Guid postId);
    }

}
