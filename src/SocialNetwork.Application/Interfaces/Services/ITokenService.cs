using SocialNetwork.Application.DTOs;

namespace SocialNetwork.Application.Interfaces.Services
{
    public interface ITokenService
    {
        TokenDTO CreateToken(User user, List<string> roleNames);
    }
}
