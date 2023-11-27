using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IReactionRepository ReactionRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IRoleRepository RoleRepository { get; }

        public IPostImageRepository PostImageRepository { get; }

        public IPostRepository PostRepository { get; }

        public IPostCommentRepository PostCommentRepository { get; }

        public readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            ReactionRepository = new ReactionRepository(logger, context);
            UserRepository = new UserRepository(logger, context);
            RoleRepository = new RoleRepository(logger, context);
            RefreshTokenRepository = new RefreshTokenRepository(logger, context);
            PostImageRepository = new PostImageRepository(logger, context);
            PostRepository = new PostRepository(logger, context);
            PostCommentRepository = new PostCommentRepository(logger, context);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
