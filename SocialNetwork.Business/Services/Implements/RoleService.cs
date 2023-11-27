using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Role.Request;
using SocialNetwork.Business.DTOs.Role.Responses;
using SocialNetwork.Business.Helper;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.Business.Services.Implements
{
    public class RoleService : BaseServices, IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<IdentityRole> roleManager) : base(unitOfWork, mapper)
        {
            _roleManager = roleManager;
        }

        public async Task<IResponse> Add(CreateRoleRequest request)
        {
            var checkExistRole = await _roleManager.FindByNameAsync(request.RoleName);
            if (checkExistRole != null)
            {
                return new ErrorResponse(400, Messages.RoleExist);
            }

            var newRole = new IdentityRole()
            {
                Name = request.RoleName
            };
            var result = await _roleManager.CreateAsync(newRole);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            return new DataResponse(_mapper.Map<GetRoleResponse>(newRole), 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public async Task<IResponse> GetAll()
        {
            var roles = await _unitOfWork.RoleRepository.GetAll();

            return new DataResponse(_mapper.Map<List<GetRoleResponse>>(roles), 200);
        }

        public async Task<IResponse> GetById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse(_mapper.Map<GetRoleResponse>(role), 200);
        }

        public async Task<IResponse> Update(string Id, UpdateRoleRequest request)
        {
            var updateRole = await _roleManager.FindByIdAsync(Id);
            if (updateRole == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            updateRole.Name = request.RoleName;
            updateRole.NormalizedName = request.RoleName.ToUpper();

            var result = await _roleManager.UpdateAsync(updateRole);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new DataResponse(_mapper.Map<GetRoleResponse>(updateRole), 204, Messages.UpdatedSuccessfully);
        }
    }
}
