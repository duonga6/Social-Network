using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class GroupService : BaseServices<GroupService>, IGroupService
    {
        private readonly UserManager<User> _userManager;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GroupService> logger, UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
        }

        public async Task<IResponse> Create(string requestId, CreateGroupRequest request)
        {
            var newGroup = _mapper.Map<Group>(request);
            newGroup.CreatedId = requestId;

            await _unitOfWork.GroupRepository.AddAsync(newGroup);

            var newGroupMember = new GroupMember()
            {
                UserId = requestId,
                GroupId = newGroup.Id,
                IsAdmin = true,
                IsSuperAdmin = true,
            };

            await _unitOfWork.GroupMemberRepository.AddAsync(newGroupMember);
            newGroup.TotalMember = 1;
            newGroup.CoverImage ??= DefaultImage.DefaultGroupImage;
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<GetGroupResponse>(await _unitOfWork.GroupRepository.GetByIdAsync(newGroup.Id, 
                new Expression<Func<Group, object>>[]
                {
                    x => x.CreatedUser,
                }
                ));

            return new DataResponse<GetGroupResponse>(response, 201, Messages.CreatedSuccessfully);
            
        }

        public async Task<IResponse> Delete(string requestId, Guid Id)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(Id) ?? throw new NotFoundException("Group id " + Id.ToString());

            if (!await CheckPermissionGroup(requestId, group.CreatedId))
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            await _unitOfWork.GroupRepository.DeleteAsync(Id);

            if (!await _unitOfWork.CompleteAsync())
            {
                return new ErrorResponse(501, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> Get(string requestId, string? searchString, int pageSize, int pageNumber, GroupType type)
        {
            int totalItems, pageCount;
            List<Group> data;
            Expression<Func<Group, bool>> filter = x => x.IsDeleted == false;
            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x => x.Name.Contains(searchString.Trim()) || x.Description.Contains(searchString.Trim()));
            }

            switch (type)
            {
                case GroupType.ALL:
                    {
                        totalItems = await _unitOfWork.GroupRepository.GetCountAsync(filter);
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = (await _unitOfWork.GroupRepository.GetPagedAsync(pageSize, pageNumber,
                            new Expression<Func<Group, object>>[] {
                            x => x.CreatedUser,
                            x => x.GroupMembers.Where(gm => gm.UserId == requestId),
                            x => x.GroupInvites.Where(gi => gi.UserId == requestId && !gi.AdminAccepted)
                            },
                            filter,
                            x => x.CreatedDate)
                            ).ToList();

                        break;
                    }

                case GroupType.JOINED_GROUP:
                    {
                        filter = filter.And(x => x.GroupMembers.Any(gm => gm.UserId == requestId && !gm.IsAdmin));


                        totalItems = await _unitOfWork.GroupRepository.GetCountAsync(filter);
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = (await _unitOfWork.GroupRepository.GetPagedAsync(pageSize, pageNumber,
                            new Expression<Func<Group, object>>[] {
                            x => x.CreatedUser,
                            x => x.GroupMembers.Where(gm => gm.UserId == requestId),
                            },
                            filter,
                            x => x.CreatedDate)
                            ).ToList();

                        break;
                    }
                case GroupType.MANAGED_BY_ME:
                    {
                        filter = filter.And(x => x.GroupMembers.Any(gm => gm.UserId == requestId && gm.IsAdmin));

                        totalItems = await _unitOfWork.GroupRepository.GetCountAsync(filter);
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = (await _unitOfWork.GroupRepository.GetPagedAsync(pageSize, pageNumber,
                            new Expression<Func<Group, object>>[] {
                            x => x.CreatedUser,
                            x => x.GroupMembers.Where(gm => gm.UserId == requestId),
                            },
                            filter,
                            x => x.TotalMember)
                            ).ToList();

                        break;
                    }
                case GroupType.BOTH_JOINED_MANAGED:
                    {
                        filter = filter.And(x => x.GroupMembers.Any(gm => gm.UserId == requestId));

                        totalItems = await _unitOfWork.GroupRepository.GetCountAsync(filter);
                        pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

                        if (pageNumber > pageCount && pageCount != 0)
                        {
                            return new ErrorResponse(400, Messages.OutOfPage);
                        }

                        data = (await _unitOfWork.GroupRepository.GetPagedAsync(pageSize, pageNumber,
                            new Expression<Func<Group, object>>[] {
                            x => x.CreatedUser,
                            x => x.GroupMembers.Where(gm => gm.UserId == requestId),
                            },
                            filter,
                            x => x.CreatedDate)
                            ).ToList();
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
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(Id, new Expression<Func<Group, object>>[] {
                x => x.CreatedUser, 
            });
            if (group == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Group id " + Id.ToString()));
            }

            var response = _mapper.Map<GetGroupResponse>(group);

            return new DataResponse<GetGroupResponse>(response, 200);
        }

        public async Task<IResponse> Update(string requestId, Guid Id, UpdateGroupRequest request)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(Id, new Expression<Func<Group, object>>[] {
                x => x.CreatedUser,
            }) ?? throw new NotFoundException("Group id " + Id.ToString());

            if (requestId != group.CreatedId)
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            _mapper.Map(request, group);

            await _unitOfWork.GroupRepository.UpdateAsync(group);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.UpdateError);
            }

            var response = _mapper.Map<GetGroupResponse>(group);

            return new DataResponse<GetGroupResponse>(response, 200, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> GetMedia(string requestId, Guid groupId, int pageSize, int pageNumber)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupId);
            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group"));

            if (!group.IsPublic)
            {
                var checkMember = await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == groupId && x.UserId == requestId);
                if (checkMember == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<PostMedia, bool>> filter = x => x.IsDeleted == false && x.Post.IsDeleted == false && x.Post.GroupId == groupId && x.Post.IsDeleted == false;

            int totalItems = await _unitOfWork.PostMediaRepository.GetCountAsync(filter);
            int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);
            if (pageNumber > totalPage && totalPage != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var postImages = await _unitOfWork.PostMediaRepository.GetPagedAsync(pageSize, pageNumber, filter, x => x.CreatedDate);

            var response = _mapper.Map<List<GetPostMediaResponse>>(postImages);

            return new PagedResponse<List<GetPostMediaResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetFeed(string requestId, int pageSize, DateTime? cursor)
        {
            Expression<Func<Post, bool>> filter = x => x.IsDeleted == false && x.GroupId != null && x.Group.IsDeleted == false && x.Group.GroupMembers.Any(x => x.UserId == requestId);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedDate < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPagedAsync(pageSize + 1, filter, x => x.CreatedDate, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                    x => x.PostMedias,
                    x => x.Group,
                    x => x.SharePost.Author,
                    x => x.SharePost.PostMedias,
                    x => x.SharePost.Group,
            }, true)).ToList();

            bool hasNext = false;

            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedDate : null;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new CursorResponse<List<GetPostResponse>>(response, endCursor, hasNext, 0);
        }

        public async Task<IResponse> GetPost(string requestId, Guid groupId, int pageSize, int pageNumber, string? searchString)
        {
            if (!await CheckAccessGroup(requestId, groupId))
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<Post, bool>> filter = x => x.IsDeleted == false && x.GroupId == groupId && x.Group.IsDeleted == false;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And(x => x.Content.Contains(searchString) || x.Author.FirstName.Contains(searchString) || x.Author.LastName.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostRepository.GetCountAsync(filter);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > totalPages && totalPages != 0) return new ErrorResponse(400, Messages.OutOfPage);

            var data = await _unitOfWork.PostRepository.GetPagedAsync(pageSize, pageNumber, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias.Where(x => x.IsDeleted == false),
                x => x.Group,
                x => x.SharePost.Author,
                x => x.SharePost.Group,
                x => x.SharePost.PostMedias.Where(x => x.IsDeleted == false)
            }, filter, x => x.CreatedDate);

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new PagedResponse<List<GetPostResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetPost(string requestId, Guid groupId, int pageSize, DateTime? cursor, string? searchString, bool getNext = true)
        {
            if (!await CheckAccessGroup(requestId, groupId))
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<Post, bool>> filter = x => x.IsDeleted == false && x.GroupId == groupId && x.Group.IsDeleted == false;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And(x => x.Content.Contains(searchString) || x.Author.FirstName.Contains(searchString) || x.Author.LastName.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostRepository.GetCountAsync(filter);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedDate < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPagedAsync(pageSize + 1, filter, x => x.CreatedDate, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias,
                x => x.Group,
                x => x.SharePost.Author,
                x => x.SharePost.Group,
                x => x.SharePost.PostMedias
            })).ToList();

            bool hasNext = false;

            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedDate : null;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new CursorResponse<List<GetPostResponse>>(response, endCursor, hasNext, totalItems);
        }

        private async Task<bool> CheckAccessGroup(string userId, Guid groupId)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupId) ?? throw new NotFoundException("Group id: " + groupId.ToString());
            return !(!group.IsPublic && await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == groupId && x.UserId == userId) == null);
        }

        private async Task<bool> CheckPermissionGroup(string userId, string authorId)
        {
            if (userId == authorId) return true;


            return await _userManager.IsInRoleAsync(new User
            {
                Id = userId,
            }, RoleName.Administrator);
        }

        public async Task<IResponse> StatsGroupResponse(string requestId)
        {
            //var user = await _userManager.FindByIdAsync(requestId) ?? throw new NotFoundException("User id: " + requestId);

            //if (!await _userManager.IsInRoleAsync(user, RoleName.Administrator)) return new ErrorResponse(401, Messages.UnAuthorized);

            var totalGroup = await _unitOfWork.GroupRepository.GetCountAsync(x => x.IsDeleted == false);
            var privateGroup = await _unitOfWork.GroupRepository.GetCountAsync(x => x.IsDeleted == false && !x.IsPublic);

            var response = new StatsGroupResponse
            {
                TotalGroup = totalGroup,
                PrivateGroup = privateGroup,
                PublicGroup = totalGroup - privateGroup,
            };

            return new DataResponse<StatsGroupResponse>(response, 200);
        }
    }
}
