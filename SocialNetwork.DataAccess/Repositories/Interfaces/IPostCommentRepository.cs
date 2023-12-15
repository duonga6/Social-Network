using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IPostCommentRepository : IGenericRepository<PostComment>
    {
        Task<ICollection<PostComment>> GetByPost(Guid postId);  
    }
}
