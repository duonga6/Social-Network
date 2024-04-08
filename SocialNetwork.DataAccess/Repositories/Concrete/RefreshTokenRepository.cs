using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken, Guid>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<RefreshToken> GetToken(string Token, string Jti)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Token == Token && x.JwtId == Jti);
        }

        public async Task RevokeToken(RefreshToken token)
        {
            var tokenRevoke = await _dbSet.FirstOrDefaultAsync(x => x.Id == token.Id);
            if (tokenRevoke != null)
            {
                tokenRevoke.IsUsed = true;
                tokenRevoke.IsRevoked = true;
            }


        }
    }
}
