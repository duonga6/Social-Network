using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.Business.Services.Concrete
{
    public class GroupInviteService : BaseServices<GroupInviteService>,IGroupInviteService
    {
        public GroupInviteService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupInviteService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> Create(string requestId, CreateGroupInviteRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetById(request.GroupId);
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Group id {request.GroupId}"));
            }

            var inviteNew = new GroupInvite()
            {
                GroupId = request.GroupId,
                UserId = requestId,
            };

            await _unitOfWork.GroupInviteRepository.Add(inviteNew);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.AddError);
            }

            var response = _mapper.Map<GetGroupInviteResponse>(inviteNew);

            return new DataResponse<GetGroupInviteResponse>(response, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestId, Guid Id)
        {

            var groupInvite = await _unitOfWork.GroupInviteRepository.GetById(Id);
            if (groupInvite == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Group invite {Id}"));
            }

            if (requestId != groupInvite.UserId)
            {
                var groupAdminCheck = await _unitOfWork.GroupAdminRepository.FindOneBy(x => x.GroupId == groupInvite.GroupId && x.UserId == requestId);
                if (groupAdminCheck == null)
                {
                    return new ErrorResponse(404, Messages.PermissionDenied("Not owner or group admin"));
                }
            }

            await _unitOfWork.GroupInviteRepository.Delete(Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public Task<IResponse> GetByGroup(string requestId, string? searchString, int pageSize, int pageNumber, Guid groupId)
        {

            throw new NotImplementedException();
        }
    }
}
