using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface ICommentReactionRepository : IGenericRepository<CommentReaction, Guid>
    {
        Task<CommentReaction> GetByIdAsync(Guid commentId, string userId, int reactionId);
        Task<ICollection<CommentReaction>> GetByCommentAsync(Guid commentId);
    }
}
