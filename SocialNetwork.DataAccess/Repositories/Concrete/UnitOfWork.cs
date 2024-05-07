using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
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
        public IMediaTypeRepository MediaTypeRepository { get; }
        public IPostMediaRepository PostMediaRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IGroupMemberRepository GroupMemberRepository { get; }
        public IGroupInviteRepository GroupInviteRepository { get; }
        public IConversationRepository ConversationRepository { get; }
        public IConversationParticipantRepository ConversationParticipantRepository { get; }
        public IMessageMemberReadRepository MessageMemberReadRepository { get; }

        private readonly AppDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            ReactionRepository = new ReactionRepository(logger, context);
            RefreshTokenRepository = new RefreshTokenRepository(logger, context);
            PostRepository = new PostRepository(logger, context);
            PostCommentRepository = new PostCommentRepository(logger, context);
            PostReactionRepository = new PostReactionRepository(logger, context);
            CommentReactionRepository = new CommentReactionRepository(logger, context);
            FriendshipRepository = new FriendshipRepository(logger, context);
            MessageRepository = new MessageRepository(logger, context);
            NotificationRepository = new NotificationRepository(logger, context);
            UserRepository = new UserRepository(logger, context);
            MediaTypeRepository = new MediaTypeRepository(logger, context);
            PostMediaRepository = new PostMediaRepository(logger, context);
            GroupRepository = new GroupRepository(logger, context);
            GroupMemberRepository = new GroupMemberRepository(logger, context);
            GroupInviteRepository = new GroupInviteRepository(logger, context);
            ConversationRepository = new ConversationRepository(logger, context);
            ConversationParticipantRepository = new ConversationParticipantRepository(logger, context);
            MessageMemberReadRepository = new MessageMemberReadRepository(logger, context);
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task<bool> CommitAsync()
        {
            var result =  await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            return result > 0;
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
