using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IPostCommentRepository : IGenericRepository<PostComment, Guid>
    {
        Task<ICollection<PostComment>> GetByPost(Guid postId);
    }
}
