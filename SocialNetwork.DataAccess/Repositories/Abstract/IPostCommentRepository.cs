using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IPostCommentRepository : ISoftDeleteRepository<PostComment, Guid>
    {
        Task<ICollection<PostComment>> GetByPostAsync(Guid postId);
    }
}
