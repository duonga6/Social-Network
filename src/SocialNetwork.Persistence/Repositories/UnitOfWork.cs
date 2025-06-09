using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace SocialNetwork.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReactionRepository ReactionRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IPostRepository PostRepository { get; }
        public IPostCommentRepository PostCommentRepository { get; }
        public IPostReactionRepository PostReactionRepository { get; }
        public ICommentReactionRepository CommentReactionRepository { get; }
        public IFriendshipRepository FriendshipRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPostMediaRepository PostMediaRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IGroupMemberRepository GroupMemberRepository { get; }
        public IGroupInviteRepository GroupInviteRepository { get; }
        public IConversationRepository ConversationRepository { get; }
        public IConversationParticipantRepository ConversationParticipantRepository { get; }
        public IMessageMemberReadRepository MessageMemberReadRepository { get; }
        public IReportRepository ReportRepository { get; }
        public IReportActionRepository ActionReportRepository { get; }
        public IActionReportDidRepository ActionReportDidRepository { get; }
        public IIPLimitRepository IPLimitRepository { get; }
        public IRoleRepository RoleRepository { get; }

        private readonly AppDbContext _dbContext;
        private readonly IDbContextTransaction _transaction;

        public UnitOfWork(AppDbContext dbContext, ILoggerFactory loggerFactory)
        {

        }

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task RolebackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
