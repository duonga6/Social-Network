namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IReactionRepository ReactionRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IPostRepository PostRepository { get; }
        IPostCommentRepository PostCommentRepository { get;}
        IPostReactionRepository PostReactionRepository { get; }
        ICommentReactionRepository CommentReactionRepository { get; }
        IFriendshipRepository FriendshipRepository { get; }
        IMessageRepository MessageRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IUserRepository UserRepository { get; }
        IMediaTypeRepository MediaTypeRepository { get; }
        IPostMediaRepository PostMediaRepository { get; }

        Task<bool> CompleteAsync();
    }
}
