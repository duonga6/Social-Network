using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Application.Interfaces;

public interface IUnitOfWork
{
    IReactionRepository ReactionRepository { get; }
    IRefreshTokenRepository RefreshTokenRepository { get; }
    IPostRepository PostRepository { get; }
    IPostCommentRepository PostCommentRepository { get; }
    IPostReactionRepository PostReactionRepository { get; }
    ICommentReactionRepository CommentReactionRepository { get; }
    IFriendshipRepository FriendshipRepository { get; }
    IMessageRepository MessageRepository { get; }
    INotificationRepository NotificationRepository { get; }
    IUserRepository UserRepository { get; }
    IPostMediaRepository PostMediaRepository { get; }
    IGroupRepository GroupRepository { get; }
    IGroupMemberRepository GroupMemberRepository { get; }
    IGroupInviteRepository GroupInviteRepository { get; }
    IConversationRepository ConversationRepository { get; }
    IConversationParticipantRepository ConversationParticipantRepository { get; }
    IMessageMemberReadRepository MessageMemberReadRepository { get; }
    IReportRepository ReportRepository { get; }
    IReportActionRepository ActionReportRepository { get; }
    IActionReportDidRepository ActionReportDidRepository { get; }
    IIPLimitRepository IPLimitRepository { get; }
    IRoleRepository RoleRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RolebackAsync();
}