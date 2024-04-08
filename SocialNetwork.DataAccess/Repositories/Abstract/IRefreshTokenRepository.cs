using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, Guid>
    {
        Task RevokeToken(RefreshToken token);
        Task<RefreshToken> GetToken(string Token, string Jti);
    }
}
