using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface ITokenService
    {
        Task<Token> CreateToken(User user);
        Task<TokenWithMessage> RenewToken(RenewTokenRequest token);

    }
}
