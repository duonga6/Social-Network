using AutoMapper;
using LinqKit;
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
    internal class GroupMemberService : BaseServices<GroupMemberService>, IGroupMemberService
    {
        public GroupMemberService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupMemberService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> Delete(string requestId, Guid id)
        {
            var memberDelete = await _unitOfWork.GroupMemberRepository.GetById(id);
            if (memberDelete == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Member"));
            }

            var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == requestId && x.IsAdmin && x.GroupId == memberDelete.GroupId);

            if (memberDelete.UserId != requestId && checkAdmin == null)
            {
                return new ErrorResponse(400, Messages.AccessDeniedToGroup);
            }

            if (memberDelete.IsAdmin && !checkAdmin.IsSuperAdmin)
            {
                return new ErrorResponse(400, Messages.AccessDeniedToGroup);
            }

            await _unitOfWork.GroupMemberRepository.Delete(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> Delete(string requestId, Guid groupId, string userId)
        {
            var memberDelete = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == userId && x.GroupId == groupId);
            if (memberDelete == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Member"));
            }

            var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == requestId && x.IsAdmin && x.GroupId == groupId);

            if (memberDelete.UserId != requestId && checkAdmin == null)
            {
                return new ErrorResponse(400, Messages.AccessDeniedToGroup);
            }

            if (memberDelete.IsAdmin && !checkAdmin.IsSuperAdmin)
            {
                return new ErrorResponse(400, Messages.AccessDeniedToGroup);
            }

            await _unitOfWork.GroupMemberRepository.Delete(memberDelete.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> GetAll(string requestId, int pageSize, int pageNumber, string? searchString, Guid groupId)
        {
            var group = await _unitOfWork.GroupRepository.GetById(groupId);

            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group"));

            if (!group.IsPublic && (await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == requestId && x.GroupId == groupId) == null)) {
                return new ErrorResponse(400, Messages.AccessDeniedToGroup);
            }

            Expression<Func<GroupMember, bool>> filter = x => x.GroupId == groupId;

            if (searchString != null)
            {
                filter = filter.And(x => (x.User.FirstName + " " + x.User.LastName).Contains(searchString.Trim()));
            }

            int totalItems = await _unitOfWork.GroupMemberRepository.GetCount(filter);
            int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);

            if (totalPage != 0 && pageNumber > totalPage) return new ErrorResponse(400, Messages.OutOfPage);

            var members = await _unitOfWork.GroupMemberRepository.GetPaged(pageSize, pageNumber,
                    new Expression<Func<GroupMember, object>>[]
                    {
                        x => x.User
                    },
                    filter,
                    x => x.CreatedAt
                );

            var result = _mapper.Map<List<GetGroupMemberResponse>>(members);

            return new PagedResponse<List<GetGroupMemberResponse>>(result, totalItems, 200);
        }

        public async Task<IResponse> InviteUser(string requestId, CreateGroupMemberRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetById(request.GroupId);

            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group"));

            var checkUserRequest = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == request.GroupId && x.UserId == requestId);
            if (checkUserRequest == null) return new ErrorResponse(400, Messages.AccessDeniedToGroup);

            var checkUserInvite = await _unitOfWork.GroupInviteRepository.FindOneBy(x => x.GroupId == request.GroupId && x.UserId == request.UserId && x.CreatedId == requestId);
            if (checkUserInvite != null) return new ErrorResponse(400, Messages.GroupInvitedExisted);

            var checkUserJoined = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == request.GroupId && x.UserId == request.UserId);
            if (checkUserJoined != null) return new ErrorResponse(400, Messages.GroupInvitedExisted);

            var newInvite = new GroupInvite
            {
                AdminAccepted = checkUserRequest.IsAdmin,
                CreatedId = requestId,
                GroupId = request.GroupId,
                UserAccepted = requestId == request.UserId,
                UserId = request.UserId,
            };

            await _unitOfWork.GroupInviteRepository.Add(newInvite);

            var result = await _unitOfWork.CompleteAsync();

            if (!result) return new ErrorResponse(501, Messages.STWrong);

            var response = await _unitOfWork.GroupInviteRepository.GetById(newInvite.Id, new Expression<Func<GroupInvite, object>>[] { x => x.User });
            return new DataResponse<GetGroupInviteResponse>(_mapper.Map<GetGroupInviteResponse>(response), 201, Messages.CreatedSuccessfully);
        }
    }
}
