namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IReactionRepository ReactionRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IPostImageRepository PostImageRepository { get; }
        IPostRepository PostRepository { get; }
        IPostCommentRepository PostCommentRepository { get;}

        Task<bool> CompleteAsync();
    }
}
