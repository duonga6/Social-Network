using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IPostCommentRepository : IGenericRepository<PostComment, Guid>
    {
        Task<ICollection<PostComment>> GetByPost(Guid postId);
    }
}
