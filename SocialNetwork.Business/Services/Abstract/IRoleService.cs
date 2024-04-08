using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

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
