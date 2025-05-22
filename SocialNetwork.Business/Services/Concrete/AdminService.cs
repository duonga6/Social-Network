using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Enums;
using System.Linq.Expressions;

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

        public Task<IResponse> GetActionDid(string requestId, Guid reportId)
        {
            throw new NotImplementedException();
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
                .Where(x => x.IsDeleted == false);

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
                    CreatedDate = DateTime.SpecifyKind(x.CreatedDate, DateTimeKind.Utc),
                    Group = x.GroupId == null ? null : new GetGroupBasicResponse
                    {
                        Id = x.Group.Id,
                        CoverImage = x.Group.CoverImage,
                        IsPublic = x.Group.IsPublic,
                        Name = x.Group.Name,
                    },
                    TotalComment = x.Comments.Where(c => c.IsDeleted == false).Count(),
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
                .Where(x => x.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(searchString.Trim()));
            }

            switch (orderBy)
            {
                case OrderByEnum.CreatedDate:
                    query = isDescending ? query.OrderByDescending(x => x.CreatedDate) : query.OrderBy(x => x.CreatedDate);
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
                TotalPost = x.Posts.Where(p => p.IsDeleted == false).Count(),
            }).ToListAsync();

            foreach (var user in users)
            {
                var userRaw = await _userManager.FindByIdAsync(user.Id);
                var roles = await _userManager.GetRolesAsync(userRaw);

                user.Roles = roles.ToArray();

                user.IsLocked = await _userManager.IsLockedOutAsync(userRaw);
            }

            return new PagedResponse<List<GetUserByAdminResponse>>(users, totalItems, 200);
        }

        public async Task<IResponse> LockUserReport(string requestId, Guid reportId)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(reportId, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.ActionReportDids
            }) ?? throw new NotFoundException("Report id: " + reportId.ToString());

            if (report.IsSolved)
            {
                return new ErrorResponse(400, Messages.ReportSolved);
            }

            if (report.ActionReportDids.Any(x => x.ActionReportId == (int)ReportActionId.REPORT_GROUP_LOCK_USER
                || x.ActionReportId == (int)ReportActionId.REPORT_POST_LOCK_USER
                || x.ActionReportId == (int)ReportActionId.REPORT_USER_LOCK_USER

            ))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            string userId;
            switch (report.ReportType)
            {
                case ReportTypeEnum.POST:
                    var post = await _unitOfWork.PostRepository.GetByIdAsync(Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Post report");
                    userId = post.AuthorId;
                    break;
                case ReportTypeEnum.GROUP:
                    var group = await _unitOfWork.GroupRepository.GetByIdAsync(Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Group report");
                    userId = group.CreatedId;
                    break;
                case ReportTypeEnum.COMMENT:
                    var comment = await _unitOfWork.PostCommentRepository.GetByIdAsync(Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Group report");
                    userId = comment.UserId;
                    break;
                case ReportTypeEnum.USER:
                    var userReport = await _userManager.FindByIdAsync(report.RelatedId) ?? throw new NotFoundException("User report");
                    userId = userReport.Id;
                    break;
                default:
                    userId = "";
                    break;
            }

            var user = await _userManager.FindByIdAsync(userId) ?? throw new NotFoundException("User report");
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddDays(999));

            return new SuccessResponse(Messages.UserLocked, 200);
        }
       
        public async Task<IResponse> UnLockUserReport(string requestId, Guid reportId)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(reportId, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.ActionReportDids
            }) ?? throw new NotFoundException("Report id: " + reportId.ToString());

            if (report.IsSolved)
            {
                return new ErrorResponse(400, Messages.ReportSolved);
            }

            if (!report.ActionReportDids.Any(x => x.ActionReportId == (int)ReportActionId.REPORT_GROUP_LOCK_USER
                || x.ActionReportId == (int)ReportActionId.REPORT_POST_LOCK_USER
                || x.ActionReportId == (int)ReportActionId.REPORT_USER_LOCK_USER

            ))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            string userId;
            switch (report.ReportType)
            {
                case ReportTypeEnum.POST:
                    var post = await _unitOfWork.PostRepository.GetByIdAsync(Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Post report");
                    userId = post.AuthorId;
                    break;
                case ReportTypeEnum.GROUP:
                    var group = await _unitOfWork.GroupRepository.GetByIdAsync(Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Group report");
                    userId = group.CreatedId;
                    break;
                case ReportTypeEnum.COMMENT:
                    var comment = await _unitOfWork.PostCommentRepository.GetByIdAsync(Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Group report");
                    userId = comment.UserId;
                    break;
                case ReportTypeEnum.USER:
                    var userReport = await _userManager.FindByIdAsync(report.RelatedId) ?? throw new NotFoundException("User report");
                    userId = userReport.Id;
                    break;
                default:
                    userId = "";
                    break;
            }

            var user = await _userManager.FindByIdAsync(userId) ?? throw new NotFoundException("User report");
            await _userManager.SetLockoutEndDateAsync(user, null);

            return new SuccessResponse(Messages.UserLocked, 200);
        }

        public async Task<IResponse> UnDeleteRelatedReport(string requestId, Guid reportId)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(reportId, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.ActionReportDids
            }) ?? throw new NotFoundException("Report id: " + reportId.ToString());

            if (report.IsSolved)
            {
                return new ErrorResponse(400, Messages.ReportSolved);
            }

            if (!report.ActionReportDids.Any(x => x.ActionReportId == (int)ReportActionId.REPORT_GROUP_DELETE_GROUP
                || x.ActionReportId == (int)ReportActionId.REPORT_POST_DELETE_POST

            ))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            switch (report.ReportType)
            {
                case ReportTypeEnum.POST:
                    await _unitOfWork.PostRepository.RestoreEntityAsync(Guid.Parse(report.RelatedId));
                    break;
                case ReportTypeEnum.GROUP:
                    await _unitOfWork.GroupRepository.RestoreEntityAsync(Guid.Parse(report.RelatedId));
                    break;
                case ReportTypeEnum.COMMENT:
                    await _unitOfWork.PostCommentRepository.RestoreEntityAsync(Guid.Parse(report.RelatedId));
                    break;
                default:
                    break;
            }

            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            return new SuccessResponse("Restore success", 200);
        }

        public async Task<IResponse> DeleteRelatedReport(string requestId, Guid reportId)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(reportId, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.ActionReportDids
            }) ?? throw new NotFoundException("Report id: " + reportId.ToString());

            if (report.IsSolved)
            {
                return new ErrorResponse(400, Messages.ReportSolved);
            }

            if (report.ActionReportDids.Any(x => x.ActionReportId == (int)ReportActionId.REPORT_GROUP_DELETE_GROUP
                || x.ActionReportId == (int)ReportActionId.REPORT_POST_DELETE_POST

            ))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            switch (report.ReportType)
            {
                case ReportTypeEnum.POST:
                    await _unitOfWork.PostRepository.DeleteAsync(Guid.Parse(report.RelatedId));
                    break;
                case ReportTypeEnum.GROUP:
                    await _unitOfWork.GroupRepository.DeleteAsync(Guid.Parse(report.RelatedId));
                    break;
                case ReportTypeEnum.COMMENT:
                    await _unitOfWork.PostCommentRepository.DeleteAsync(Guid.Parse(report.RelatedId));
                    break;
                default:
                    break;
            }

            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            return new SuccessResponse("Delete success", 200);
        }
    }
}
