using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class GroupService : BaseServices<GroupService>, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> Create(string requestId, CreateGroupRequest request)
        {
            var newGroup = _mapper.Map<Group>(request);
            newGroup.CreatedId = requestId;

            await _unitOfWork.GroupRepository.Add(newGroup);

            var newGroupMember = new GroupMember()
            {
                UserId = requestId,
                GroupId = newGroup.Id,
                IsAdmin = true,
                IsSuperAdmin = true,
            };

            await _unitOfWork.GroupMemberRepository.Add(newGroupMember);
            newGroup.TotalMember = 1;
            newGroup.CoverImage ??= DefaultImage.DefaultGroupImage;
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<GetGroupResponse>(await _unitOfWork.GroupRepository.GetById(newGroup.Id, 
                new Expression<Func<Group, object>>[]
                {
                    x => x.CreatedBy,
                }
                ));

            return new DataResponse<GetGroupResponse>(response, 201, Messages.CreatedSuccessfully);
            
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

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> Get(string requestId, string? searchString, int pageSize, int pageNumber, GroupType type)
        {
            int totalItems, pageCount;
            List<Group> data;

            switch (type)
            {
                case GroupType.ALL:
                    Expression<Func<Group, bool>> filter = x => x.Status == 1;
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        filter = filter.And(x => x.Name.Contains(searchString.Trim()) || x.Description.Contains(searchString.Trim()));
                    }

                    totalItems = await _unitOfWork.GroupRepository.GetCount(filter);
                    pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                    if (pageNumber > pageCount && pageCount != 0)
                    {
                        return new ErrorResponse(400, Messages.OutOfPage);
                    }

                    data = (await _unitOfWork.GroupRepository.GetPaged(pageSize, pageNumber,
                        new Expression<Func<Group, object>>[] {
                            x => x.CreatedBy,
                            x => x.GroupMembers.Where(gm => gm.UserId == requestId),
                            x => x.GroupInvites.Where(gi => gi.UserId == requestId && !gi.AdminAccepted)
                        },
                        filter,
                        x => x.CreatedAt)
                        ).ToList();

                    break;

                case GroupType.JOINED_GROUP:
                    {
                        var query = _unitOfWork.GroupRepository.GetQueryable()
                            .Where(
                                g => g.Status == 1 && 
                                g.GroupMembers.Any(gm => gm.UserId == requestId && !gm.IsAdmin)
                            );

                        totalItems = await query.CountAsync();
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = await query.Include(x => x.CreatedBy).Skip(pageNumber - 1).Take(pageSize).ToListAsync();

                        break;
                    }
                case GroupType.MANAGED_BY_ME:
                    {
                        var query = _unitOfWork.GroupRepository.GetQueryable()
                            .Where(x => x.Status == 1 && x.GroupMembers.Any(ga => ga.UserId == requestId && ga.IsAdmin));

                        totalItems = await query.CountAsync();
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = await query
                            .Include(x => x.CreatedBy)
                            .Include(x => x.GroupMembers.Where(gm => gm.UserId == requestId))
                            .Skip(pageNumber - 1)
                            .Take(pageSize)
                            .ToListAsync();

                        break;
                    }
                case GroupType.BOTH_JOINED_MANAGED:
                    {
                        var query = _unitOfWork.GroupRepository.GetQueryable()
                            .Where(x => x.Status == 1 && x.GroupMembers.Any(gm => gm.UserId == requestId));

                        totalItems = await query.CountAsync();
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = await query.Include(x => x.CreatedBy).Skip(pageNumber - 1).Take(pageSize).ToListAsync();
                        break;
                    }
                default:
                    totalItems = 0;
                    data = new();
                    break;
            }


            var response = _mapper.Map<List<GetGroupResponse>>(data);
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

            return new DataResponse<GetGroupResponse>(response, 200, Messages.UpdatedSuccessfully);
        }
    
        
    }
}
