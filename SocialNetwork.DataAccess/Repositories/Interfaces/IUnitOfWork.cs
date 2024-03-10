namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IReactionRepository ReactionRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IPostImageRepository PostImageRepository { get; }
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
