namespace SocialNetwork.DataAccess.Repositories.Abstract
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
        IGroupRepository GroupRepository{ get; }
        IGroupAdminRepository GroupAdminRepository { get; }
        IGroupMemberRepository GroupMemberRepository { get; }
        IGroupInviteRepository GroupInviteRepository { get; }

        Task<bool> CompleteAsync();

        Task BeginTransaction();

        Task Commit();

        Task Rollback();
    }
}
