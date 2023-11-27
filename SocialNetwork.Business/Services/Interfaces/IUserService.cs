using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResponse> GetById(string userId);
        Task<IResponse> Register(RegistrationRequest request);
        Task<IResponse> Login(LoginRequest request);
        Task<IResponse> AddRoles(string userId, AddRolesToUserRequest request);
        Task<IResponse> GetRoles(string userId);
        Task<IResponse> RenewToken(RenewTokenRequest token);
        Task<IResponse> UpdateRole(string userId, AddRolesToUserRequest request);
        Task<IResponse> GetPostById(string userId, Guid postId);
        Task<IResponse> GetPostByUser(string userId);
        Task<IResponse> CreatePost(string userId, CreatePostRequest request);
        Task<IResponse> DeletePost(string userId, Guid postId);
        Task<IResponse> UpdatePost(string userId, Guid postId, UpdatePostRequest request);
    }
}
