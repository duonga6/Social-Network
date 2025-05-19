using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, Guid>
    {
        Task RevokeTokenAsync(RefreshToken token);
        Task<RefreshToken> GetTokenAsync(string Token, string Jti);
    }
}
