using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface ICommentReactionRepository : IGenericRepository<CommentReaction, Guid>
    {
        Task<CommentReaction> GetById(Guid commentId, string userId, int reactionId);
        Task<bool> Delete(Guid commentId, string userId, int reactionId);
        Task<ICollection<CommentReaction>> GetByComment(Guid commentId);
    }
}
