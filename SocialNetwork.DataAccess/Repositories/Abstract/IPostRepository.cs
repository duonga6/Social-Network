using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IPostRepository : IGenericRepository<Post, Guid>
    {
        Task<bool> IsOwnerPost(string userId, Guid postId);
    }

}
