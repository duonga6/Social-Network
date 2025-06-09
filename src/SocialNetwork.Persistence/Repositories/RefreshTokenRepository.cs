using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Persistence.Repositories
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken, Guid>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<RefreshToken> GetTokenAsync(string token, string jti)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Token == token && x.JwtId == jti);
        }

        public async Task RevokeTokenAsync(RefreshToken token)
        {
            var tokenRevoke = await dbSet.FirstOrDefaultAsync(x => x.Id == token.Id);
            tokenRevoke.IsUsed = true;
            tokenRevoke.IsRevoked = true;
        }
    }
}
