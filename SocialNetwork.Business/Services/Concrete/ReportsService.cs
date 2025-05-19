using AutoMapper;
using LinqKit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Asn1.Ocsp;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Enums;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class ReportsService : BaseServices<ReportsService>, IReportsService
    {
        public ReportsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReportsService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> CreateReport(string requestId, CreateReportRequest request)
        {
            var checkExist = await _unitOfWork.ReportRepository.FindOneByAsync(x => x.UserId == requestId && x.RelatedId == request.RelationId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.ReportExisted);
            }

            object objectRelation;

            switch (request.ReportType)
            {
                case ReportTypeEnum.USER:
                    objectRelation = _mapper.Map<GetUserResponse>(await _unitOfWork.UserRepository.GetByIdAsync(request.RelationId) ?? throw new NotFoundException("User id: " + request.RelationId));
                    break;
                case ReportTypeEnum.POST:
                    objectRelation = _mapper.Map<GetPostResponse>(await _unitOfWork.PostRepository.GetByIdAsync(Guid.Parse(request.RelationId),
                        new Expression<Func<Post, object>>[]
                        {
                            x => x.PostMedias,
                            x => x.SharePost,
                            x => x.SharePost.Author,
                            x => x.SharePost.Group,
                            x => x.SharePost.PostMedias,
                            x => x.Author,
                            x => x.Group
                        }) ?? throw new NotFoundException("User id: " + request.RelationId));
                    break;
                case ReportTypeEnum.GROUP:
                    objectRelation = _mapper.Map<GetGroupResponse>( await _unitOfWork.GroupRepository.GetByIdAsync(Guid.Parse(request.RelationId),
                        new Expression<Func<Group, object>>[]
                        {
                            x => x.CreatedUser
                        }) ?? throw new NotFoundException("Group id: " + request.RelationId));
                        break;
                case ReportTypeEnum.COMMENT:
                    objectRelation = _mapper.Map<GetPostCommentResponse>(await _unitOfWork.PostCommentRepository.GetByIdAsync(Guid.Parse(request.RelationId),
                        new Expression<Func<PostComment, object>>[]
                        {
                            x => x.User
                        }) ?? throw new NotFoundException("Comment id: " + request.RelationId));
                    break;
                default:
                    objectRelation = "";
                    break;
            };

            string jsonDetail = JsonConvert.SerializeObject(objectRelation, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            var newReport = new ReportViolation
            {
                RelatedId = request.RelationId,
                JsonDetails = jsonDetail,
                Content = request.Content,
                ReportType = request.ReportType,
                UserId = requestId,
            };

            await _unitOfWork.ReportRepository.AddAsync(newReport);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetReportResponse>(await _unitOfWork.ReportRepository.GetByIdAsync(newReport.Id));

            return new DataResponse<GetReportResponse>(response, 201);
        }

        public async Task<IResponse> GetReport(string requestId, int pageSize, int pageNumber, string? searchString, ReportTypeEnum? type)
        {
            Expression<Func<ReportViolation, bool>> filter = x => x.IsDeleted == false;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = x => x.Content.Contains(searchString.Trim());
            }

            if (type != null)
            {
                filter = filter.And(x => x.ReportType == type);
            }

            var totalItems = await _unitOfWork.ReportRepository.GetCountAsync(filter);
            var totalPage = (int)Math.Ceiling((decimal)totalItems / pageSize);
            if (pageNumber > totalPage && totalPage != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var data = await _unitOfWork.ReportRepository.GetPagedAsync(pageSize, pageNumber, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.User,
                x => x.SolvedUser
            }, filter, x => x.CreatedDate);

            var response = _mapper.Map<List<GetReportResponse>>(data);

            return new PagedResponse<List<GetReportResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetReportById(string requestId, Guid Id)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(Id, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.User,
                x => x.SolvedUser
            }) ?? throw new NotFoundException("Report id: " + Id.ToString());

            return new DataResponse<GetReportResponse>(_mapper.Map<GetReportResponse>(report), 200);
        }

        public async Task<IResponse> MarkProccessed(string requestId, Guid Id)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(Id) ?? throw new NotFoundException("Report id: " + Id.ToString());

            await _unitOfWork.ReportRepository.MarkProccessedAsync(Id, requestId);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetReportResponse>(await _unitOfWork.ReportRepository.GetByIdAsync(Id, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.User,
                x => x.SolvedUser
            }));

            return new DataResponse<GetReportResponse>(response, 200);
        }

        public async Task<IResponse> GetActionReport(string requestId, Guid Id)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(Id) ?? throw new NotFoundException("Report id: " + Id.ToString());

            var reportAction = await _unitOfWork.ActionReportRepository.FindByAsync(x => x.ReportType == report.ReportType, new Expression<Func<ActionReport, object>>[]
            {
                x => x.ActionReportDids,
            });

            var response = _mapper.Map<List<GetReportActionResponse>>(reportAction);

            return new DataResponse<List<GetReportActionResponse>>(response, 200);
        }

        public async Task<IResponse> CreateActionReport(string requestId, Guid Id, CreateReportActionRequest request)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(Id) ?? throw new NotFoundException("Report id: " + Id.ToString());

            var checkAction = await _unitOfWork.ActionReportRepository.GetByIdAsync(request.ActionId) ?? throw new NotFoundException("Action id: " + request.ActionId);
            if (checkAction.ReportType != report.ReportType)
            {
                return new ErrorResponse(400, Messages.InvalidActionReport);
            }

            var checkExistReportAction = await _unitOfWork.ActionReportDidRepository.FindOneByAsync(x => x.ReportId == report.Id && x.ActionReportId == request.ActionId);

            if (checkExistReportAction != null)
            {
                return new ErrorResponse(400, Messages.ReportActionDidExist);
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                switch (request.ActionId)
                {
                    case (int)ReportActionId.REPORT_GROUP_DELETE_GROUP:
                        {
                            var group = await _unitOfWork.GroupRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.GroupRepository.DeleteAsync(group.Id);
                            break;
                        }
                    case (int)ReportActionId.REPORT_GROUP_LOCK_USER:
                        {
                            var group = await _unitOfWork.GroupRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDateAsync(group.CreatedId, DateTime.UtcNow.AddYears(999));
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_DELETE_POST:
                        {
                            var post = await _unitOfWork.PostRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.PostRepository.DeleteAsync(post.Id);
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_LOCK_USER:
                        {
                            var post = await _unitOfWork.PostRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDateAsync(post.AuthorId, DateTime.UtcNow.AddYears(999));
                            break;
                        }
                    case (int)ReportActionId.REPORT_USER_LOCK_USER:
                        await _unitOfWork.UserRepository.SetLockoutEndDateAsync(report.RelatedId, DateTime.UtcNow.AddYears(999));
                        break;
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_COMMENT:
                        {
                            var commet = await _unitOfWork.PostCommentRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDateAsync(commet.UserId, DateTime.UtcNow.AddYears(999));
                            break;
                        }
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_USER:
                        await _unitOfWork.UserRepository.SetLockoutEndDateAsync(report.RelatedId, DateTime.UtcNow.AddYears(999));
                        break;
                }

                var newReportActionDid = new ActionReportDid
                {
                    ActionReportId = request.ActionId,
                    CreatedById = requestId,
                    ReportId = report.Id,
                };

                await _unitOfWork.ActionReportDidRepository.AddAsync(newReportActionDid);
                if (!await _unitOfWork.CommitAsync()) throw new NoDataChangeException();

                var actionDidAdded = await _unitOfWork.ActionReportDidRepository.GetByIdAsync(newReportActionDid.Id, new Expression<Func<ActionReportDid, object>>[]
                {
                    x => x.CreatedUser
                });

                var response = _mapper.Map<GetReportActionDidResponse>(actionDidAdded);

                return new DataResponse<GetReportActionDidResponse>(response, 201, Messages.CreatedSuccessfully);
            } 
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("Error ReportService/CreateActionReport: " + ex);
                throw new NoDataChangeException();
            }
        }

        public async Task<IResponse> DeleteActionReport(string requestId, Guid Id, Guid actionId)
        {
            var actionDid = await _unitOfWork.ActionReportDidRepository.GetByIdAsync(actionId) ?? throw new NotFoundException("Action id: " + actionId.ToString());
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(actionDid.ReportId) ?? throw new NotFoundException("Report id: " + actionDid.ReportId.ToString());

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                switch (actionDid.ActionReportId)
                {
                    case (int)ReportActionId.REPORT_GROUP_DELETE_GROUP:
                        {
                            await _unitOfWork.GroupRepository.RestoreEntityAsync(Guid.Parse(report.RelatedId));
                            break;
                        }
                    case (int)ReportActionId.REPORT_GROUP_LOCK_USER:
                        {
                            var group = await _unitOfWork.GroupRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDateAsync(group.CreatedId, null);
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_DELETE_POST:
                        {
                            await _unitOfWork.PostRepository.RestoreEntityAsync(Guid.Parse(report.RelatedId));
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_LOCK_USER:
                        {
                            var post = await _unitOfWork.PostRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDateAsync(post.AuthorId, null);
                            break;
                        }
                    case (int)ReportActionId.REPORT_USER_LOCK_USER:
                        await _unitOfWork.UserRepository.SetLockoutEndDateAsync(report.RelatedId, null);
                        break;
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_COMMENT:
                        {
                            await _unitOfWork.PostCommentRepository.RestoreEntityAsync(Guid.Parse(report.RelatedId));
                            break;
                        }
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_USER:
                        {
                            var comment = await _unitOfWork.PostCommentRepository.FindOneByAsync(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDateAsync(comment.UserId, null);
                            break;
                        }
                }

                await _unitOfWork.ActionReportDidRepository.DeleteAsync(actionId);
                if (!await _unitOfWork.CommitAsync()) throw new NoDataChangeException();

                return new SuccessResponse(Messages.DeletedSuccessfully, 200);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("Error ReportService/CreateActionReport: " + ex);
                throw new NoDataChangeException();
            }
        }

        public async Task<IResponse> GetStats(string requestId)
        {
            int totalReport = await _unitOfWork.ReportRepository.GetCountAsync();
            int totalReportNotProcessed = await _unitOfWork.ReportRepository.GetCountAsync(x => x.IsSolved);

            var response = new GetStatsReportResponse
            {
                TotalReport = totalReport,
                TotalNotProcessed = totalReportNotProcessed,
            };

            return new DataResponse<GetStatsReportResponse>(response, 200);
        }
    }
}
