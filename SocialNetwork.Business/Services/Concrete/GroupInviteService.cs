using AutoMapper;
using LinqKit;
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
    public class GroupInviteService : BaseServices<GroupInviteService>, IGroupInviteService
    {
        public GroupInviteService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupInviteService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> AcceptRequest(string requestId, Guid id)
        {
            var inviteRequest = await _unitOfWork.GroupInviteRepository
                .FindOneByAsync(x => x.Id == id && x.Group.IsDeleted == false, new Expression<Func<GroupInvite, object>>[] {x => x.User}) ?? throw new NotFoundException("Invite id: " + id.ToString());

            if (!await HasPermission(requestId, inviteRequest.GroupId, inviteRequest.UserId)) return new ErrorResponse(400, Messages.GroupAccessDenied);

            if (inviteRequest.UserAccepted && inviteRequest.AdminAccepted)
            {
                var checkMemberJoined = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == inviteRequest.UserId && x.GroupId == inviteRequest.GroupId);
                if (checkMemberJoined == null)
                {
                    return await AddMemberAndDeleteInvite(inviteRequest);
                }
                else
                {
                    await _unitOfWork.GroupInviteRepository.DeleteAsync(inviteRequest.Id);
                    if (!await _unitOfWork.CompleteAsync()) return new ErrorResponse(500, Messages.STWrong);

                    throw new NotFoundException("Invite id: " + id.ToString());
                }
            }

            if (!inviteRequest.UserAccepted && !inviteRequest.AdminAccepted)
            {
                bool isAdmin = await IsAdmin(requestId, inviteRequest.GroupId);
                inviteRequest.UserAccepted = !isAdmin;
                inviteRequest.AdminAccepted = isAdmin;

                await _unitOfWork.GroupInviteRepository.UpdateAsync(inviteRequest);
                if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

                return new DataResponse<GetGroupInviteResponse>(_mapper.Map<GetGroupInviteResponse>(inviteRequest), 200, Messages.AcceptedInvite(isAdmin ? "Admin" : "User"));
            }

            return await AddMemberAndDeleteInvite(inviteRequest);
        }

        public async Task<IResponse> Create(string requestId, CreateGroupInviteRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.GroupId);
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Group id {request.GroupId}"));
            }

            var checkJoined = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == request.GroupId && x.UserId == requestId);
            if (checkJoined != null) return new ErrorResponse(400, Messages.GroupMemberExist);

            var checkUserInvite = await _unitOfWork.GroupInviteRepository.FindOneByAsync(x => x.GroupId == request.GroupId && x.UserId == requestId);

            if (checkUserInvite != null)
            {
                // Admin chưa chấp nhận && user đã chấp nhận => dupli request
                if (!checkUserInvite.AdminAccepted && checkUserInvite.UserAccepted)
                {
                    return new ErrorResponse(400, Messages.GroupJoinRequestExist);
                }
                // Admin đã chấp nhận && user đã chấp nhận -> Bản ghi chưa xóa -> Xóa tạo lại
                else if (checkUserInvite.AdminAccepted && checkUserInvite.UserAccepted)
                {
                    await _unitOfWork.GroupInviteRepository.DeleteAsync(checkUserInvite.Id);
                    await _unitOfWork.CompleteAsync();

                    return await this.Create(requestId, request);
                }
                // Admin chưa chấp nhận && user chưa chấp nhận -> Được người khác mời vào -> Cho user accept
                else if (!checkUserInvite.AdminAccepted && !checkUserInvite.UserAccepted)
                {
                    checkUserInvite.UserAccepted = true;
                    await _unitOfWork.GroupInviteRepository.UpdateAsync(checkUserInvite);

                    if (!await _unitOfWork.CompleteAsync()) return new ErrorResponse(501, Messages.STWrong);

                    return new DataResponse<GetGroupInviteResponse>(_mapper.Map<GetGroupInviteResponse>(checkUserInvite), 200, Messages.GroupAcceptedInviteFromOther);
                }
                // Admin đã chấp nhận && user chưa chấp nhận -> join trực tiếp vào nhóm
                else
                {
                    var newMember = new GroupMember
                    {
                        GroupId = group.Id,
                        UserId = requestId,
                    };

                    await _unitOfWork.GroupInviteRepository.DeleteAsync(checkUserInvite.Id);
                    await _unitOfWork.GroupMemberRepository.AddAsync(newMember);

                    if (!await _unitOfWork.CompleteAsync()) return new ErrorResponse(501, Messages.STWrong);

                    return new DataResponse<GetGroupMemberResponse>(_mapper.Map<GetGroupMemberResponse>(newMember), 201, Messages.GroupMemberJoined);
                }
            } else
            {
                GroupInvite inviteNew = new()
                {
                    GroupId = request.GroupId,
                    UserId = requestId,
                    CreatedId = requestId,
                    UserAccepted = true,
                };

                await _unitOfWork.GroupInviteRepository.AddAsync(inviteNew);

                var result = await _unitOfWork.CompleteAsync();

                if (!result)
                {
                    return new ErrorResponse(501, Messages.AddError);
                }

                var response = _mapper.Map<GetGroupInviteResponse>(inviteNew);

                return new DataResponse<GetGroupInviteResponse>(response, 201, Messages.CreatedRequestJoinGroup);
            }
        }

        public async Task<IResponse> Delete(string requestId, Guid Id)
        {

            var groupInvite = await _unitOfWork.GroupInviteRepository.GetByIdAsync(Id);
            if (groupInvite == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Group invite {Id}"));
            }

            if (requestId != groupInvite.UserId)
            {
                var groupAdminCheck = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == groupInvite.GroupId && x.UserId == requestId && x.IsAdmin == true);
                if (groupAdminCheck == null)
                {
                    return new ErrorResponse(404, Messages.PermissionDenied("Not owner or group admin"));
                }
            }

            await _unitOfWork.GroupInviteRepository.DeleteAsync(Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> DeleteByGroup(string requestId, Guid groupId)
        {
            var invite = await _unitOfWork.GroupInviteRepository.FindOneByAsync(x => x.UserId == requestId && x.GroupId == groupId);

            if (invite == null || invite.UserId != requestId) return new ErrorResponse(400, Messages.NotFound());

            await _unitOfWork.GroupInviteRepository.DeleteAsync(invite.Id);

            if (!await _unitOfWork.CompleteAsync()) return new ErrorResponse(501, Messages.STWrong);

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> GetByGroup(string requestId, string? searchString, int pageSize, int pageNumber, Guid groupId)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupId) ?? throw new NotFoundException("Group id: " + groupId.ToString());

            var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.GroupId == groupId && x.IsAdmin);
            if (checkAdmin == null) return new ErrorResponse(404, Messages.GroupAccessDenied);

            Expression<Func<GroupInvite, bool>> filter = x => x.GroupId == groupId && !x.AdminAccepted;

            int totalItems = await _unitOfWork.GroupInviteRepository.GetCountAsync(filter);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (totalPages != 0 && pageNumber > totalPages) return new ErrorResponse(400, Messages.OutOfPage);

            var intites = await _unitOfWork.GroupInviteRepository.GetPagedAsync(pageSize, pageNumber, new Expression<Func<GroupInvite, object>>[]
            {
                x => x.User
            }, filter, x => x.CreatedDate);

            var response = _mapper.Map<List<GetGroupInviteResponse>>(intites);

            return new PagedResponse<List<GetGroupInviteResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetById(string requestId, Guid id)
        {
            var invite = await _unitOfWork.GroupInviteRepository.GetByIdAsync(id, new Expression<Func<GroupInvite, object>>[] { x => x.User, x => x.Group }) ?? throw new NotFoundException("Member invite");

            if (requestId != invite.UserId)
            {
                var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.IsAdmin);
                if (checkAdmin == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            var response = _mapper.Map<GetGroupInviteResponse>(invite);

            return new DataResponse<GetGroupInviteResponse>(response, 200);
        }

        public async Task<IResponse> GetById(string requestId, string userId, Guid groupId)
        {
            var invite = await _unitOfWork.GroupInviteRepository.FindOneByAsync(
                x => x.UserId == requestId && x.GroupId == groupId
                , new Expression<Func<GroupInvite, object>>[] { x => x.User, x => x.Group }) ?? throw new NotFoundException("Member invite");

            if (requestId != userId)
            {
                var checkAdmin = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == requestId && x.IsAdmin);
                if (checkAdmin == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            var response = _mapper.Map<GetGroupInviteResponse>(invite);

            return new DataResponse<GetGroupInviteResponse>(response, 200);
        }

        public async Task<IResponse> GetCursor(string requestId, Guid groupId, int pageSize, DateTime? cursor, string? searchString, bool getNext = true)
        {
            Expression<Func<GroupInvite, bool>> filter = x => x.GroupId == groupId && x.Group.IsDeleted == false;

            if (cursor != null)
            {
                filter = getNext ? filter.And(x => x.CreatedDate < cursor) : filter.And(x => x.CreatedDate > cursor);
            }

            bool hasNext = true;

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x => x.User.FirstName.Contains(searchString.Trim()) || x.User.LastName.Contains(searchString.Trim()));
            }

            var totalItem = await _unitOfWork.GroupInviteRepository.GetCountAsync(filter);

            var data = (await _unitOfWork.GroupInviteRepository.GetCursorPagedAsync(pageSize + 1, filter, x => x.CreatedDate, new Expression<Func<GroupInvite, object>>[] { x => x.User }, true)).ToList();
            
            if (data.Count <= pageSize)
            {
                hasNext = false;
            } else
            {
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedDate : null;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetGroupInviteResponse>>(data);

            return new CursorResponse<List<GetGroupInviteResponse>>(response, endCursor, hasNext, totalItem);
        }

        private async Task<IResponse> AddMemberAndDeleteInvite(GroupInvite invite)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var newMember = new GroupMember
                {
                    UserId = invite.UserId,
                    GroupId = invite.GroupId,
                };

                await _unitOfWork.GroupRepository.IncreaseMemberAsync(invite.GroupId);
                await _unitOfWork.GroupInviteRepository.DeleteAsync(invite.Id);
                await _unitOfWork.GroupMemberRepository.AddAsync(newMember);

                if (!await _unitOfWork.CommitAsync()) return new ErrorResponse(500, Messages.STWrong);

                var response = await _unitOfWork.GroupMemberRepository.GetByIdAsync(newMember.Id, new Expression<Func<GroupMember, object>>[] { x => x.User });

                return new DataResponse<GetGroupMemberResponse>(_mapper.Map<GetGroupMemberResponse>(response), 201, Messages.GroupMemberJoined);
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("Error AddMemberAndDeleteInvite :" + ex);
                return new ErrorResponse(501, Messages.STWrong);
            }
           

        }

        private async Task<bool> HasPermission(string userId, Guid groupId, string inviteUserId)
        {
            if (userId == inviteUserId) return true;

            return await IsAdmin(userId, groupId);
        }

        private async Task<bool> IsAdmin(string userId, Guid groupId)
        {
            var member = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.UserId == userId && x.GroupId == groupId && x.IsAdmin);
            return member != null;
        }
    }
}
