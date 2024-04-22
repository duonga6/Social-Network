using AutoMapper;
using LinqKit;
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
            Expression<Func<Group, bool>> filter = x => x.Status == 1;
            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x => x.Name.Contains(searchString.Trim()) || x.Description.Contains(searchString.Trim()));
            }

            switch (type)
            {
                case GroupType.ALL:
                    {
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
                    }

                case GroupType.JOINED_GROUP:
                    {
                        filter = filter.And(x => x.GroupMembers.Any(gm => gm.UserId == requestId && !gm.IsAdmin));


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
                            },
                            filter,
                            x => x.CreatedAt)
                            ).ToList();

                        break;
                    }
                case GroupType.MANAGED_BY_ME:
                    {
                        filter = filter.And(x => x.GroupMembers.Any(gm => gm.UserId == requestId && gm.IsAdmin));

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
                            },
                            filter,
                            x => x.TotalMember)
                            ).ToList();

                        break;
                    }
                case GroupType.BOTH_JOINED_MANAGED:
                    {
                        filter = filter.And(x => x.GroupMembers.Any(gm => gm.UserId == requestId));

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
                            },
                            filter,
                            x => x.CreatedAt)
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
            var group = await _unitOfWork.GroupRepository.GetById(Id, new Expression<Func<Group, object>>[] {
                x => x.CreatedBy, 
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
            var group = await _unitOfWork.GroupRepository.GetById(Id, new Expression<Func<Group, object>>[] {
                x => x.CreatedBy,
            }) ?? throw new NotFoundException("Group id " + Id.ToString());

            if (requestId != group.CreatedId)
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            _mapper.Map(request, group);

            await _unitOfWork.GroupRepository.Update(group);
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
            var group = await _unitOfWork.GroupRepository.GetById(groupId);
            if (group == null) return new ErrorResponse(404, Messages.NotFound("Group"));

            if (!group.IsPublic)
            {
                var checkMember = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == groupId && x.UserId == requestId);
                if (checkMember == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<PostMedia, bool>> filter = x => x.Status == 1 && x.Post.Status == 1 && x.Post.GroupId == groupId && x.Post.Status == 1;

            int totalItems = await _unitOfWork.PostMediaRepository.GetCount(filter);
            int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);
            if (pageNumber > totalPage && totalPage != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var postImages = await _unitOfWork.PostMediaRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);

            var response = _mapper.Map<List<GetPostMediaResponse>>(postImages);

            return new PagedResponse<List<GetPostMediaResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetFeed(string requestId, int pageSize, DateTime? cursor)
        {
            Expression<Func<Post, bool>> filter = x => x.Status == 1 && x.GroupId != null && x.Group.Status == 1 && x.Group.GroupMembers.Any(x => x.UserId == requestId);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.Group,
                x => x.PostMedias.Where(pm => pm.Status == 1)
            }, true)).ToList();

            bool hasNext = false;

            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedAt : null;

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new CursorResponse<List<GetPostResponse>>(response, endCursor, hasNext, 0);
        }

        public async Task<IResponse> GetPost(string requestId, Guid groupId, int pageSize, int pageNumber, string? searchString)
        {
            if (!await CheckAccessGroup(requestId, groupId))
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<Post, bool>> filter = x => x.Status == 1 && x.GroupId == groupId && x.Group.Status == 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And(x => x.Content.Contains(searchString) || x.Author.FirstName.Contains(searchString) || x.Author.LastName.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostRepository.GetCount(filter);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > totalPages && totalPages != 0) return new ErrorResponse(400, Messages.OutOfPage);

            var data = await _unitOfWork.PostRepository.GetPaged(pageSize, pageNumber, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias.Where(x => x.Status == 1)
            }, filter, x => x.CreatedAt);

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new PagedResponse<List<GetPostResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetPost(string requestId, Guid groupId, int pageSize, DateTime? cursor, string? searchString, bool getNext = true)
        {
            if (!await CheckAccessGroup(requestId, groupId))
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            Expression<Func<Post, bool>> filter = x => x.Status == 1 && x.GroupId == groupId && x.Group.Status == 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And(x => x.Content.Contains(searchString) || x.Author.FirstName.Contains(searchString) || x.Author.LastName.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostRepository.GetCount(filter);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias.Where(x => x.Status == 1)
            })).ToList();

            bool hasNext = false;

            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedAt : null;

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new CursorResponse<List<GetPostResponse>>(response, endCursor, hasNext, totalItems);
        }

        private async Task<bool> CheckAccessGroup(string userId, Guid groupId)
        {
            var group = await _unitOfWork.GroupRepository.GetById(groupId) ?? throw new NotFoundException("Group id: " + groupId.ToString());
            return !(!group.IsPublic && await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == groupId && x.UserId == userId) == null);
        }
    }
}
