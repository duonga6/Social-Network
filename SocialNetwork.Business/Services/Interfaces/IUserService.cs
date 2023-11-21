using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResponse> GetById(string id);
        Task<IResponse> Register(RegistrationRequest request);
        Task<IResponse> Login(LoginRequest request);
        Task<IResponse> AddRoles(AddRolesToUserRequest request);
        Task<IResponse> GetRoles(string id);
        Task<IResponse> RenewToken(RenewTokenRequest token);
    }
}
