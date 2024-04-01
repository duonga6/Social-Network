using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
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
        public IGroupAdminRepository GroupAdminRepository { get; }
        public IGroupMemberRepository GroupMemberRepository { get; }


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
            GroupAdminRepository = new GroupAdminRepository(logger, context);
            GroupMemberRepository = new GroupMemberRepository(logger, context);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
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
