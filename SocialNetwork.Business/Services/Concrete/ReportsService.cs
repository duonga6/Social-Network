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
using SocialNetwork.DataAccess.Utilities.Enum;
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
            var checkExist = await _unitOfWork.ReportRepository.FindOneBy(x => x.UserId == requestId && x.RelatedId == request.RelationId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.ReportExisted);
            }

            object objectRelation;

            switch (request.ReportType)
            {
                case ReportTypeEnum.USER:
                    objectRelation = _mapper.Map<GetUserResponse>(await _unitOfWork.UserRepository.GetById(request.RelationId) ?? throw new NotFoundException("User id: " + request.RelationId));
                    break;
                case ReportTypeEnum.POST:
                    objectRelation = _mapper.Map<GetPostResponse>(await _unitOfWork.PostRepository.GetById(Guid.Parse(request.RelationId),
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
                    objectRelation = _mapper.Map<GetGroupResponse>( await _unitOfWork.GroupRepository.GetById(Guid.Parse(request.RelationId),
                        new Expression<Func<Group, object>>[]
                        {
                            x => x.CreatedBy
                        }) ?? throw new NotFoundException("Group id: " + request.RelationId));
                        break;
                case ReportTypeEnum.COMMENT:
                    objectRelation = _mapper.Map<GetPostCommentResponse>(await _unitOfWork.PostCommentRepository.GetById(Guid.Parse(request.RelationId),
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

            await _unitOfWork.ReportRepository.Add(newReport);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetReportResponse>(await _unitOfWork.ReportRepository.GetById(newReport.Id));

            return new DataResponse<GetReportResponse>(response, 201);
        }

        public async Task<IResponse> GetReport(string requestId, int pageSize, int pageNumber, string? searchString, ReportTypeEnum? type)
        {
            Expression<Func<ReportViolation, bool>> filter = x => x.Status == 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = x => x.Content.Contains(searchString.Trim());
            }

            if (type != null)
            {
                filter = filter.And(x => x.ReportType == type);
            }

            var totalItems = await _unitOfWork.ReportRepository.GetCount(filter);
            var totalPage = (int)Math.Ceiling((decimal)totalItems / pageSize);
            if (pageNumber > totalPage && totalPage != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var data = await _unitOfWork.ReportRepository.GetPaged(pageSize, pageNumber, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.User,
                x => x.SolvedUser
            }, filter, x => x.CreatedAt);

            var response = _mapper.Map<List<GetReportResponse>>(data);

            return new PagedResponse<List<GetReportResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetReportById(string requestId, Guid Id)
        {
            var report = await _unitOfWork.ReportRepository.GetById(Id, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.User,
                x => x.SolvedUser
            }) ?? throw new NotFoundException("Report id: " + Id.ToString());

            return new DataResponse<GetReportResponse>(_mapper.Map<GetReportResponse>(report), 200);
        }

        public async Task<IResponse> MarkProccessed(string requestId, Guid Id)
        {
            var report = await _unitOfWork.ReportRepository.GetById(Id) ?? throw new NotFoundException("Report id: " + Id.ToString());

            await _unitOfWork.ReportRepository.MarkProccessed(Id, requestId);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetReportResponse>(await _unitOfWork.ReportRepository.GetById(Id, new Expression<Func<ReportViolation, object>>[]
            {
                x => x.User,
                x => x.SolvedUser
            }));

            return new DataResponse<GetReportResponse>(response, 200);
        }

        public async Task<IResponse> GetActionReport(string requestId, Guid Id)
        {
            var report = await _unitOfWork.ReportRepository.GetById(Id) ?? throw new NotFoundException("Report id: " + Id.ToString());

            var reportAction = await _unitOfWork.ActionReportRepository.FindBy(x => x.ReportType == report.ReportType, new Expression<Func<ActionReport, object>>[]
            {
                x => x.ActionReportDids,
            });

            var response = _mapper.Map<List<GetReportActionResponse>>(reportAction);

            return new DataResponse<List<GetReportActionResponse>>(response, 200);
        }

        public async Task<IResponse> CreateActionReport(string requestId, Guid Id, CreateReportActionRequest request)
        {
            var report = await _unitOfWork.ReportRepository.GetById(Id) ?? throw new NotFoundException("Report id: " + Id.ToString());

            var checkAction = await _unitOfWork.ActionReportRepository.GetById(request.ActionId) ?? throw new NotFoundException("Action id: " + request.ActionId);
            if (checkAction.ReportType != report.ReportType)
            {
                return new ErrorResponse(400, Messages.InvalidActionReport);
            }

            var checkExistReportAction = await _unitOfWork.ActionReportDidRepository.FindOneBy(x => x.ReportId == report.Id && x.ActionReportId == request.ActionId);

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
                            var group = await _unitOfWork.GroupRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.GroupRepository.Delete(group.Id);
                            break;
                        }
                    case (int)ReportActionId.REPORT_GROUP_LOCK_USER:
                        {
                            var group = await _unitOfWork.GroupRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDate(group.CreatedId, DateTime.UtcNow.AddYears(999));
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_DELETE_POST:
                        {
                            var post = await _unitOfWork.PostRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.PostRepository.Delete(post.Id);
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_LOCK_USER:
                        {
                            var post = await _unitOfWork.PostRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDate(post.AuthorId, DateTime.UtcNow.AddYears(999));
                            break;
                        }
                    case (int)ReportActionId.REPORT_USER_LOCK_USER:
                        await _unitOfWork.UserRepository.SetLockoutEndDate(report.RelatedId, DateTime.UtcNow.AddYears(999));
                        break;
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_COMMENT:
                        {
                            var commet = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDate(commet.UserId, DateTime.UtcNow.AddYears(999));
                            break;
                        }
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_USER:
                        await _unitOfWork.UserRepository.SetLockoutEndDate(report.RelatedId, DateTime.UtcNow.AddYears(999));
                        break;
                }

                var newReportActionDid = new ActionReportDid
                {
                    ActionReportId = request.ActionId,
                    CreatedById = requestId,
                    ReportId = report.Id,
                };

                await _unitOfWork.ActionReportDidRepository.Add(newReportActionDid);
                if (!await _unitOfWork.CommitAsync()) throw new NoDataChangeException();

                var actionDidAdded = await _unitOfWork.ActionReportDidRepository.GetById(newReportActionDid.Id, new Expression<Func<ActionReportDid, object>>[]
                {
                    x => x.CreatedBy
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
            var actionDid = await _unitOfWork.ActionReportDidRepository.GetById(actionId) ?? throw new NotFoundException("Action id: " + actionId.ToString());
            var report = await _unitOfWork.ReportRepository.GetById(actionDid.ReportId) ?? throw new NotFoundException("Report id: " + actionDid.ReportId.ToString());

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                switch (actionDid.ActionReportId)
                {
                    case (int)ReportActionId.REPORT_GROUP_DELETE_GROUP:
                        {
                            await _unitOfWork.GroupRepository.RestoreEntity(Guid.Parse(report.RelatedId));
                            break;
                        }
                    case (int)ReportActionId.REPORT_GROUP_LOCK_USER:
                        {
                            var group = await _unitOfWork.GroupRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDate(group.CreatedId, null);
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_DELETE_POST:
                        {
                            await _unitOfWork.PostRepository.RestoreEntity(Guid.Parse(report.RelatedId));
                            break;
                        }
                    case (int)ReportActionId.REPORT_POST_LOCK_USER:
                        {
                            var post = await _unitOfWork.PostRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDate(post.AuthorId, null);
                            break;
                        }
                    case (int)ReportActionId.REPORT_USER_LOCK_USER:
                        await _unitOfWork.UserRepository.SetLockoutEndDate(report.RelatedId, null);
                        break;
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_COMMENT:
                        {
                            await _unitOfWork.PostCommentRepository.RestoreEntity(Guid.Parse(report.RelatedId));
                            break;
                        }
                    case (int)ReportActionId.REPORT_COMMENT_DELETE_USER:
                        {
                            var comment = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == Guid.Parse(report.RelatedId)) ?? throw new NotFoundException("Related id: " + report.RelatedId);
                            await _unitOfWork.UserRepository.SetLockoutEndDate(comment.UserId, null);
                            break;
                        }
                }

                await _unitOfWork.ActionReportDidRepository.Delete(actionId);
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
            int totalReport = await _unitOfWork.ReportRepository.GetCount();
            int totalReportNotProcessed = await _unitOfWork.ReportRepository.GetCount(x => x.IsSolved);

            var response = new GetStatsReportResponse
            {
                TotalReport = totalReport,
                TotalNotProcessed = totalReportNotProcessed,
            };

            return new DataResponse<GetStatsReportResponse>(response, 200);
        }
    }
}
