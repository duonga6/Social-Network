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
        IGroupMemberRepository GroupMemberRepository { get; }
        IGroupInviteRepository GroupInviteRepository { get; }
        IConversationRepository ConversationRepository { get; }
        IConversationParticipantRepository ConversationParticipantRepository { get; }
        IMessageMemberReadRepository MessageMemberReadRepository { get; }
        IReportRepository ReportRepository { get; }
        IActionReportRepository ActionReportRepository { get; }
        IActionReportDidRepository ActionReportDidRepository { get; }

        Task<bool> CompleteAsync();

        Task BeginTransactionAsync();

        Task<bool> CommitAsync();

        Task RollbackAsync();
    }
}
