using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Utilities.Enum;
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
            var memberDelete = await _unitOfWork.GroupMemberRepository.GetByIdAsync(id) ?? throw new NotFoundException("Member id: " + id.ToString());

            var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.IsAdmin && x.GroupId == memberDelete.GroupId);

            if ((memberDelete.UserId != requestId && checkAdmin == null) || (memberDelete.IsAdmin && !checkAdmin.IsSuperAdmin))
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.GroupMemberRepository.DeleteAsync(id);
                await _unitOfWork.GroupRepository.ReduceMemberAsync(memberDelete.GroupId);


                if (!await _unitOfWork.CommitAsync())
                {
                    return new ErrorResponse(501, Messages.DeleteError);
                }

                return new SuccessResponse(Messages.DeletedSuccessfully, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error service GroupMember/Delete" + ex);
                await _unitOfWork.RollbackAsync();
                return new ErrorResponse(501, Messages.STWrong);
            }

            
        }

        public async Task<IResponse> Delete(string requestId, Guid groupId, string userId)
        {
            var memberDelete = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == userId && x.GroupId == groupId);
            if (memberDelete == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Member"));
            }

            var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.IsAdmin && x.GroupId == groupId);

            if (memberDelete.UserId != requestId && checkAdmin == null)
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            if (memberDelete.IsAdmin && !checkAdmin.IsSuperAdmin)
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _unitOfWork.GroupRepository.ReduceMemberAsync(groupId);
                await _unitOfWork.GroupMemberRepository.DeleteAsync(memberDelete.Id);

                if (!await _unitOfWork.CommitAsync())
                {
                    return new ErrorResponse(501, Messages.DeleteError);
                }

                return new SuccessResponse(Messages.DeletedSuccessfully, 200);
            } 
            catch(Exception ex)
            {
                _logger.LogError("Error GroupMemberService/Delete by userId:" + ex);
                await _unitOfWork.RollbackAsync();
                return new ErrorResponse(501, Messages.DeleteError);
            }
        }

        public async Task<IResponse> GetAll(string requestId, int pageSize, int pageNumber, string? searchString, Guid groupId, MemberType memberType)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupId);

            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group"));

            if (!group.IsPublic && (await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.GroupId == groupId) == null)) {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<GroupMember, bool>> filter = x => x.GroupId == groupId;

            if (searchString != null)
            {
                filter = filter.And(x => (x.User.FirstName + " " + x.User.LastName).Contains(searchString.Trim()));
            }

            switch (memberType)
            {
                case MemberType.SUPER_ADMIN:
                    filter = filter.And(x => x.IsSuperAdmin);
                    break;
                case MemberType.ADMIN:
                    filter = filter.And(x => x.IsAdmin && !x.IsSuperAdmin);
                    break;
                case MemberType.NORMAL:
                    filter = filter.And(x => !x.IsAdmin && !x.IsSuperAdmin);
                    break;
            }

            int totalItems = await _unitOfWork.GroupMemberRepository.GetCountAsync(filter);
            int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);

            if (totalPage != 0 && pageNumber > totalPage) return new ErrorResponse(400, Messages.OutOfPage);

            var members = await _unitOfWork.GroupMemberRepository.GetPagedAsync(pageSize, pageNumber,
                    new Expression<Func<GroupMember, object>>[]
                    {
                        x => x.User,
                    },
                    filter,
                    x => x.CreatedDate
                );

            var result = _mapper.Map<List<GetGroupMemberResponse>>(members);

            return new PagedResponse<List<GetGroupMemberResponse>>(result, totalItems, 200);
        }

        public async Task<IResponse> GetById(string requestId, Guid id)
        {
            var member = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.Id == id && x.Group.IsDeleted == false,
                new Expression<Func<GroupMember, object>>[] {x => x.User, x => x.Group}
                ) ?? throw new NotFoundException("Member");

            if (!member.Group.IsPublic)
            {
                var memberCheck = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == member.Group.Id && x.UserId == requestId);
                if (memberCheck == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }


            var response = _mapper.Map<GetGroupMemberResponse>(member);

            return new DataResponse<GetGroupMemberResponse>(response, 200);
        }

        public async Task<IResponse> GetById(string requestId, Guid groupId, string userId)
        {
            var member = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == groupId && x.UserId == userId && x.Group.IsDeleted == false, 
                new Expression<Func<GroupMember, object>>[] { x => x.User, x => x.Group }) ?? throw new NotFoundException("Member");

            if (!member.Group.IsPublic)
            {
                var memberCheck = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == member.Group.Id && x.UserId == requestId);
                if (memberCheck == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            var response = _mapper.Map<GetGroupMemberResponse>(member);

            return new DataResponse<GetGroupMemberResponse>(response, 200);
        }

        public async Task<IResponse> InviteUser(string requestId, CreateGroupMemberRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.GroupId) ?? throw new NotFoundException("Group id: " + request.GroupId.ToString());
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId) ?? throw new NotFoundException("User id: " + request.UserId);

            var checkUserRequest = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == request.GroupId && x.UserId == requestId);
            if (checkUserRequest == null) return new ErrorResponse(400, Messages.GroupAccessDenied);

            var checkUserInvite = await _unitOfWork.GroupInviteRepository.FindOneByAsync(x => x.GroupId == request.GroupId && x.UserId == request.UserId && x.CreatedId == requestId);
            if (checkUserInvite != null) return new ErrorResponse(400, Messages.GroupJoinRequestExist);

            var checkUserJoined = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == request.GroupId && x.UserId == request.UserId);
            if (checkUserJoined != null) return new ErrorResponse(400, Messages.GroupJoinRequestExist);

            var newInvite = new GroupInvite
            {
                AdminAccepted = checkUserRequest.IsAdmin,
                CreatedId = requestId,
                GroupId = request.GroupId,
                UserAccepted = requestId == request.UserId,
                UserId = request.UserId,
            };

            await _unitOfWork.GroupInviteRepository.AddAsync(newInvite);

            var result = await _unitOfWork.CompleteAsync();

            if (!result) return new ErrorResponse(501, Messages.STWrong);

            var response = await _unitOfWork.GroupInviteRepository.GetByIdAsync(newInvite.Id, new Expression<Func<GroupInvite, object>>[] { x => x.User });
            return new DataResponse<GetGroupInviteResponse>(_mapper.Map<GetGroupInviteResponse>(response), 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> GetCursor(string requestId, int pageSize, DateTime? cursor, string? searchString, Guid groupId) 
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupId) ?? throw new NotFoundException("Group id: " + groupId.ToString());
            if (!group.IsPublic && await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.GroupId == groupId) == null) return new ErrorResponse(400, Messages.GroupAccessDenied);

            Expression<Func<GroupMember, bool>> filter = x => x.GroupId == groupId;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And(x => x.User.FirstName.Contains(searchString) || x.User.LastName.Contains(searchString));
            }

            int totalItems = await _unitOfWork.GroupMemberRepository.GetCountAsync(filter);

            if (cursor != null) filter = filter.And(x => x.CreatedDate < cursor);

            var data = await _unitOfWork.GroupMemberRepository.GetQueryable().AsNoTracking()
                .Where(filter)
                .Include(x => x.User)
                .OrderByDescending(x => x.IsSuperAdmin)
                .ThenByDescending(x => x.IsAdmin)
                .ThenByDescending(x => x.CreatedDate)
                .Take(pageSize + 1)
                .ToListAsync();

            bool hasNext = false;

            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedDate : null;

            var response = _mapper.Map<List<GetGroupMemberResponse>>(data);

            return new CursorResponse<List<GetGroupMemberResponse>>(response, endCursor, hasNext, totalItems);
        }


        public async Task<IResponse> CreateAdmin(string requestId, CreateGroupAdminRequest request)
        {
            if (!await IsSuperAdmin(requestId, request.GroupId)) return new ErrorResponse(400, Messages.GroupAccessDenied);

            var checkUserJoined = await _unitOfWork.GroupMemberRepository
                .FindOneByAsync(x => x.UserId == requestId && x.GroupId == request.GroupId && !x.IsAdmin,
                new Expression<Func<GroupMember, object>>[] { x => x.User }) ?? throw new NotFoundException("Member id: " + request.UserId);

            checkUserJoined.IsAdmin = true;
            await _unitOfWork.GroupMemberRepository.UpdateAsync(checkUserJoined);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetGroupMemberResponse>(checkUserJoined);

            return new DataResponse<GetGroupMemberResponse>(response, 200, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> DeleteAdmin(string requestId, Guid groupId, string userId)
        {
            if (!await IsSuperAdmin(requestId, groupId)) return new ErrorResponse(400, Messages.GroupAccessDenied);

            var checkUserJoined = await _unitOfWork.GroupMemberRepository
                .FindOneByAsync(x => x.UserId == requestId && x.GroupId == groupId && !x.IsAdmin,
                new Expression<Func<GroupMember, object>>[] { x => x.User }) ?? throw new NotFoundException("Member id: " + userId);

            checkUserJoined.IsAdmin = false;
            await _unitOfWork.GroupMemberRepository.UpdateAsync(checkUserJoined);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetGroupMemberResponse>(checkUserJoined);

            return new DataResponse<GetGroupMemberResponse>(response, 200, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> DeleteAdmin(string requestId, Guid memberId)
        {
            var member = await _unitOfWork.GroupMemberRepository
                .FindOneByAsync(x => x.Id == memberId, new Expression<Func<GroupMember, object>>[] { x => x.User }) ?? throw new NotFoundException("Member id: " + memberId.ToString());

            if (!await IsSuperAdmin(requestId, member.GroupId)) return new ErrorResponse(400, Messages.GroupAccessDenied);

            member.IsAdmin = false;
            await _unitOfWork.GroupMemberRepository.UpdateAsync(member);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetGroupMemberResponse>(member);

            return new DataResponse<GetGroupMemberResponse>(response, 201, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> CreateAdmin(string requestId, Guid memberId)
        {
            var member = await _unitOfWork.GroupMemberRepository
                .FindOneByAsync(x => x.Id == memberId, new Expression<Func<GroupMember, object>>[] { x => x.User }) ?? throw new NotFoundException("Member id: " + memberId.ToString());

            if (!await IsSuperAdmin(requestId, member.GroupId)) return new ErrorResponse(400, Messages.GroupAccessDenied);

            member.IsAdmin = true;
            await _unitOfWork.GroupMemberRepository.UpdateAsync(member);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetGroupMemberResponse>(member);

            return new DataResponse<GetGroupMemberResponse>(response, 201, Messages.UpdatedSuccessfully);
        }

        private async Task<bool> IsSuperAdmin(string userId, Guid groupId)
        {
            return (await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == userId && x.GroupId == groupId && x.IsSuperAdmin) != null);
        }

    }
}
