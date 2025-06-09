namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface ICommentReactionRepository : IRepositoryBase<CommentReaction, Guid>
    {
        Task<CommentReaction> FindSingleAsync(Guid commentId, string userId, int reactionId);
        Task<ICollection<CommentReaction>> GetByCommentAsync(Guid commentId);
    }
}
