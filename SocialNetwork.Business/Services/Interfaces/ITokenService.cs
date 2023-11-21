using SocialNetwork.Business.DTOs.Token;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface ITokenService
    {
        Task<Token> CreateToken(User user);
        Task<TokenWithMessage> RenewToken(RenewTokenRequest token);

    }
}
