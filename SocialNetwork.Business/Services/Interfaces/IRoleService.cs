using SocialNetwork.Business.DTOs.Role.Request;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(string id);
        Task<IResponse> Add(CreateRoleRequest request);
        Task<IResponse> Update(string Id, UpdateRoleRequest request);
        Task<IResponse> Delete(string Id);
    }
}
