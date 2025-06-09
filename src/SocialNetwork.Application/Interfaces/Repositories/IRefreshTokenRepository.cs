namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IRepositoryBase<RefreshToken, Guid>
    {
        Task RevokeTokenAsync(RefreshToken token);
        Task<RefreshToken> GetTokenAsync(string token, string jti);
    }
}
