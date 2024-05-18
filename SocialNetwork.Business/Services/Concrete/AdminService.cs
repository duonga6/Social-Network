using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.Services.Concrete
{
    public class AdminService : BaseServices<AdminService>, IAdminService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AdminService> logger, RoleManager<IdentityRole> roleManager, UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<IResponse> GetComment(int pageSize, int pageNumber, string? searchString)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetGroup(int pageSize, int pageNumber, string? searchString, OrderByEnum orderBy, bool isDescending)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse> GetPost(int pageSize, int pageNumber, string? searchString)
        {
            var query = _unitOfWork.PostRepository.GetQueryable()
                .AsNoTracking()
                .Where(x => x.Status == 1);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => x.Content.Contains(searchString.Trim()));
            }

            int totalItems = await query.CountAsync();
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);
            if (pageNumber > pageCount && pageCount > 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var data = await query
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(x => new GetPostByAdminResponse
                {
                    Id = x.Id,
                    Access = (int)x.Access,
                    Content = x.Content,
                    CreatedAt = DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc),
                    Group = x.GroupId == null ? null : new GetGroupBasicResponse
                    {
                        Id = x.Group.Id,
                        CoverImage = x.Group.CoverImage,
                        IsPublic = x.Group.IsPublic,
                        Name = x.Group.Name,
                    },
                    TotalComment = x.Comments.Where(c => c.Status == 1).Count(),
                    TotalReaction = x.Reactions.Count,
                    User = new BasicUserResponse
                    {
                        Id = x.Author.Id,
                        AvatarUrl = x.Author.AvatarUrl,
                        FirstName = x.Author.FirstName,
                        LastName = x.Author.LastName,
                    }
                }).ToListAsync();

            return new PagedResponse<List<GetPostByAdminResponse>>(data, totalItems, 200 );
        }

        public async Task<IResponse> GetUser(int pageSize, int pageNumber, string? searchString, OrderByEnum orderBy, bool isDescending)
        {
            var query = _unitOfWork.UserRepository.GetQueryable()
                .AsNoTracking()
                .Where(x => x.Status == 1);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(searchString.Trim()));
            }

            switch (orderBy)
            {
                case OrderByEnum.CreatedAt:
                    query = isDescending ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                    break;
                case OrderByEnum.Name:
                    query = isDescending ? query.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName) : query.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
                    break;
            }

            int totalItems = await query.CountAsync();
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);
            if (pageNumber > pageCount && pageCount > 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var users = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => new GetUserByAdminResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                AvatarUrl = x.AvatarUrl,
                Address = x.Address,
                Email = x.Email,
                Gender = x.Gender,
                TotalFriend = x.Friendships1.Where(f => f.FriendshipTypeId == (int)FriendshipEnum.Accepted).Count(),
                TotalPost = x.Posts.Where(p => p.Status == 1).Count(),
            }).ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(new User
                {
                    Id = user.Id
                });

                user.Roles = roles.ToArray();
            }

            return new PagedResponse<List<GetUserByAdminResponse>>(users, totalItems, 200);
        }
    }
}
