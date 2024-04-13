using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class GroupInviteService : BaseServices<GroupInviteService>, IGroupInviteService
    {
        public GroupInviteService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupInviteService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> AcceptRequest(string requestId, Guid id)
        {
            var inviteRequest = await _unitOfWork.GroupInviteRepository.GetById(id);
            if (inviteRequest == null) return new ErrorResponse(404, Messages.NotFound("Invite " + id.ToString()));

            var group = await _unitOfWork.GroupRepository.GetById(inviteRequest.GroupId);
            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group of invite"));

            var checkRequestPermission = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == requestId && x.GroupId == group.Id && x.IsAdmin);
            if (checkRequestPermission == null) return new ErrorResponse(400, Messages.AccessDeniedToGroup);

            var newMember = new GroupMember
            {
                GroupId = group.Id,
                UserId = inviteRequest.UserId,
            };

            await _unitOfWork.GroupMemberRepository.Add(newMember);
            await _unitOfWork.GroupInviteRepository.Delete(inviteRequest.Id);

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            var response = await _unitOfWork.GroupMemberRepository.GetById(newMember.Id, new Expression<Func<GroupMember, object>>[] { x => x.User });
            return new DataResponse<GetGroupMemberResponse>(_mapper.Map<GetGroupMemberResponse>(response), 201);
        }

        public async Task<IResponse> Create(string requestId, CreateGroupInviteRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetById(request.GroupId);
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Group id {request.GroupId}"));
            }

            var checkUserInvite = await _unitOfWork.GroupInviteRepository.FindOneBy(x => x.GroupId == request.GroupId && x.UserId == requestId);
            if (checkUserInvite != null) return new ErrorResponse(400, Messages.GroupInvitedExisted);

            var checkUserJoined = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == request.GroupId && x.UserId == requestId);
            if (checkUserJoined != null) return new ErrorResponse(400, Messages.GroupInvitedExisted);
                
            GroupInvite inviteNew = new()
            {
                GroupId = request.GroupId,
                UserId = requestId,
                CreatedId = requestId,
                UserAccepted = true,
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
                var groupAdminCheck = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == groupInvite.GroupId && x.UserId == requestId && x.IsAdmin == true);
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

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> GetByGroup(string requestId, string? searchString, int pageSize, int pageNumber, Guid groupId)
        {
            var group = await _unitOfWork.GroupRepository.GetById(groupId);
            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group " + groupId.ToString()));

            var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == requestId && x.GroupId == groupId && x.IsAdmin);
            if (checkAdmin == null) return new ErrorResponse(404, Messages.AccessDeniedToGroup);

            Expression<Func<GroupInvite, bool>> filter = x => x.GroupId == groupId && !x.AdminAccepted;

            int totalItems = await _unitOfWork.GroupInviteRepository.GetCount(filter);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (totalPages != 0 && pageNumber > totalPages) return new ErrorResponse(400, Messages.OutOfPage);

            var intites = await _unitOfWork.GroupInviteRepository.GetPaged(pageSize, pageNumber, new Expression<Func<GroupInvite, object>>[]
            {
                x => x.User
            }, filter, x => x.CreatedAt);

            var response = _mapper.Map<List<GetGroupInviteResponse>>(intites);

            return new PagedResponse<List<GetGroupInviteResponse>>(response, totalItems, 200);
        }
    }
}
