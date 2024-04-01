using AutoMapper;
using LinqKit;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Groups.Request;
using SocialNetwork.Business.DTOs.Groups.Responses;
using SocialNetwork.Business.Services.Implements.Base;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    internal class GroupService : BaseServices<GroupService>, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> Create(string requestId, CreateGroupRequest request)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var newGroup = _mapper.Map<Group>(request);
                newGroup.CreatedId = requestId;

                await _unitOfWork.GroupRepository.Add(newGroup);
                await _unitOfWork.CompleteAsync();

                var superGroupAdmin = new GroupAdministrator()
                {
                    GroupId = newGroup.Id,
                    IsSuperAdmin = true,
                    UserId = requestId,
                };

                var newGroupMember = new GroupMember()
                {
                    UserId = requestId,
                    GroupId = newGroup.Id,
                };

                await _unitOfWork.GroupAdminRepository.Add(superGroupAdmin);
                await _unitOfWork.GroupMemberRepository.Add(newGroupMember);
                newGroup.TotalMember = 1;
                await _unitOfWork.Commit();

                var response = _mapper.Map<GetGroupResponse>(newGroup);

                return new DataResponse<GetGroupResponse>(response, 200);
            } catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                _logger.LogError("{Group service.Create error: }" + ex.Message);
                return new ErrorResponse(501, Messages.STWrong);
            }
            
        }

        public async Task<IResponse> Delete(string requestId, Guid Id)
        {
            var group = await _unitOfWork.GroupRepository.GetById(Id);
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Group id " + Id.ToString()));
            }

            if (requestId != group.CreatedId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            await _unitOfWork.GroupRepository.Delete(Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public async Task<IResponse> Get(string requestId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Group, bool>> filter = x => x.Status == 1;

            if (searchString != null)
            {
                filter = filter.And(x => x.Name.Contains(searchString.Trim()) || x.Description.Contains(searchString.Trim()));
            }

            int totalItems = await _unitOfWork.GroupRepository.GetCount(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var groups = await _unitOfWork.GroupRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);

            var response = _mapper.Map<List<GetGroupResponse>>(groups);

            return new PagedResponse<List<GetGroupResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetById(string requestId, Guid Id)
        {
            var group = await _unitOfWork.GroupRepository.GetById(Id);
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Group id " + Id.ToString()));
            }

            var response = _mapper.Map<GetGroupResponse>(group);

            return new DataResponse<GetGroupResponse>(response, 200);
        }

        public async Task<IResponse> Update(string requestId, Guid Id, UpdateGroupRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetById(Id);
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Group id " + Id.ToString()));
            }

            if (requestId != group.CreatedId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var updateGroup = _mapper.Map<Group>(request);
            updateGroup.Id = Id;

            await _unitOfWork.GroupRepository.Update(updateGroup);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(404, Messages.UpdateError);
            }

            var response = _mapper.Map<GetGroupResponse>(updateGroup);

            return new DataResponse<GetGroupResponse>(response, 204, Messages.UpdatedSuccessfully);
        }
    }
}
