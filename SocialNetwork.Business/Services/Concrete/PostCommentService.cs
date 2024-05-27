using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class PostCommentService : BaseServices<PostCommentService>, IPostCommentService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IFriendshipService _friendshipService;
        private readonly ICommentReactionService _commentReactionService;
        private readonly TimeLimitService _timeLimitService;

        public PostCommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostCommentService> logger, UserManager<User> userManager, INotificationService notificationService, IFriendshipService friendshipService, ICommentReactionService commentReactionService, TimeLimitService timeLimitService) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _friendshipService = friendshipService;
            _commentReactionService = commentReactionService;
            _timeLimitService = timeLimitService;
        }

        #region Comment
        public async Task<IResponse> Create(string requestUserId, CreatePostCommentRequest request)
        {
            if (!_timeLimitService.CheckLimitCreateComment(requestUserId, request.PostId))
            {
                return new ErrorResponse(400, Messages.LimitTimeComment(_timeLimitService.TimeLimitComment));
            }

            if (!await CheckPermission(requestUserId, request.PostId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            var post = await _unitOfWork.PostRepository.GetById(request.PostId);

            PostComment? parentComment = null;

            if (request.ParentCommentId != null)
            {
                parentComment = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == request.ParentCommentId && x.Status == 1);
                if (parentComment == null)
                {
                    return new ErrorResponse(404, Messages.NotFound("Parent comment"));
                }
            }

            var addComment = _mapper.Map<PostComment>(request);
            addComment.Id = Guid.NewGuid();
            addComment.UserId = requestUserId;
            addComment.Path = parentComment == null ? addComment.Id.ToString() : parentComment.Path + $";{addComment.Id}";

            await _unitOfWork.PostCommentRepository.Add(addComment);

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var response = _mapper.Map<GetPostCommentResponse>(await _unitOfWork.PostCommentRepository.GetById(addComment.Id, new Expression<Func<PostComment, object>>[]
            {
                x => x.User,
            }));

            if (addComment.UserId != parentComment?.UserId)
            {
                await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.POST_COMMENT, response);
            }

            _timeLimitService.SetTimeCreateComment(requestUserId, request.PostId);

            return new DataResponse<GetPostCommentResponse>(response, 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id) ?? throw new NotFoundException("Comment id: " + id.ToString());

            if (!await CheckOwnerComment(requestUserId, comment.UserId) && !await _unitOfWork.PostRepository.IsOwnerPost(requestUserId, comment.PostId))
            {
                return new ErrorResponse(400, Messages.CommentNotOwner);
            }

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.PostCommentRepository.Delete(id);

                if (!await _unitOfWork.CommitAsync())
                {
                    return new ErrorResponse(400, Messages.DeleteError);
                }

                return new SuccessResponse(Messages.DeletedSuccessfully, 200);
            } catch (Exception err)
            {
                _logger.LogError("Error PostCommentService/Delete" + err);
                await _unitOfWork.RollbackAsync();

                throw new NoDataChangeException();
            }
        }

        public async Task<IResponse> GetAll(string requestUserId, string? searchString, int pageSize, int pageNumber, Guid postId)
        {
            if (!await CheckPermission(requestUserId, postId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            Expression<Func<PostComment, bool>> filter = x => x.Status == 1 && x.PostId == postId && x.ParentCommentId == null;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x => x.Content.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostCommentRepository.GetCount(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var comments = await _unitOfWork.PostCommentRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            var commentsResponse = _mapper.Map<List<GetPostCommentResponse>>(comments);

            return new PagedResponse<List<GetPostCommentResponse>>(commentsResponse, totalItems, 200);
        }

        public async Task<IResponse> GetCursor(string requestUserId, int pageSize, DateTime? cursor, bool getNext, Guid postId, Guid? parentId)
        {
            if (!await CheckPermission(requestUserId, postId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            Expression<Func<PostComment, bool>> filter = x => x.PostId == postId && x.ParentCommentId == parentId && x.Status == 1;

            int totalItems = await _unitOfWork.PostCommentRepository.GetCount(filter);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var comments = (await _unitOfWork
                .PostCommentRepository
                .GetCursorPaged(pageSize + 1, filter, getNext)).ToList();

            bool hasNext = false;

            if (comments.Count > pageSize)
            {
                hasNext = true;
                comments.RemoveAt(comments.Count - 1);
            }

            var endCursor = hasNext ? comments.LastOrDefault()?.CreatedAt : null;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetPostCommentResponse>>(comments);

            return new CursorResponse<List<GetPostCommentResponse>>(response, endCursor, hasNext, totalItems);
        }

        public async Task<IResponse> GetById(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id) ?? throw new NotFoundException("Comment id: " + id.ToString());

            if (!await CheckPermission(requestUserId, comment.PostId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(comment), 200);

        }

        public async Task<IResponse> GetCount(string requestUserId, Guid Id)
        {
            if (!await CheckPermission(requestUserId, Id)) return new ErrorResponse(400, Messages.PostAccessDenied());

            int count = await _unitOfWork.PostCommentRepository.GetCount(x => x.PostId == Id && x.Status == 1);

            return new DataResponse<int>(count, 200, Messages.GetSuccessfully);
        }

        public async Task<IResponse> GetCountChild(string requestUserId, Guid commentId)
        {
            var comment = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == commentId && x.Post.Status == 1) ?? throw new NotFoundException("Comment id: " + commentId.ToString());

            if (!await CheckPermission(requestUserId, comment.PostId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            int childCount = await _unitOfWork.PostCommentRepository.GetCount(x => x.ParentCommentId == commentId && x.Status == 1);

            return new DataResponse<int>(childCount, 200);
        }

        public async Task<IResponse> GetChild(string requestUserId, string? searchString, int pageSize, int pageNumber, Guid Id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(Id) ?? throw new NotFoundException("Comment id: " + Id.ToString());

            if (!await CheckPermission(requestUserId, comment.PostId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            Expression<Func<PostComment, bool>> filter = x => x.Status == 1 && x.ParentCommentId == comment.Id;

            if (searchString != null)
            {
                filter.And(x => x.Content.Contains(searchString));
            }

            int total = await _unitOfWork.PostCommentRepository.GetCount(filter);
            var comments = await _unitOfWork.PostCommentRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);

            var response = _mapper.Map<List<GetPostCommentResponse>>(comments);
            return new PagedResponse<List<GetPostCommentResponse>>(response, total, 200);
        }
        
        public async Task<IResponse> Update(string requestUserId, Guid id, UpdatePostCommentRequest request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id) ?? throw new NotFoundException("comment id:" + id.ToString());

            if (!await CheckOwnerComment(requestUserId, comment.UserId))
            {
                return new ErrorResponse(400, Messages.CommentNotOwner);
            }

            _mapper.Map(request, comment);
            await _unitOfWork.PostCommentRepository.Update(comment);
            
            if (!await _unitOfWork.CompleteAsync())
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var commentUpdated = await _unitOfWork.PostCommentRepository.GetById(id, new Expression<Func<PostComment, object>>[]
            {
                x => x.User,
            });

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(commentUpdated), 200, Messages.UpdatedSuccessfully);

        }
        
        public async Task<IResponse> GetOverviewReaction(string requestUserId, Guid commentId)
        {
            return await _commentReactionService.GetOverview(requestUserId, commentId);
        }
        
        private async Task<bool> CheckOwnerComment(string requestUserId, string authorId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            if (requestUser == null) return false;

            // Is owner comment
            if (requestUserId == authorId)
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }


        #endregion

        #region Comment Reaction

        public async Task<IResponse> GetReactions(string requestUserId, Guid commentId, int pageSize, int pageNumber)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId) ?? throw new NotFoundException("comment id: " + commentId.ToString());

            if (!await CheckPermission(requestUserId, comment.PostId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            Expression<Func<CommentReaction, bool>> filter = x => x.CommentId == commentId;

            int totalItems = await _unitOfWork.CommentReactionRepository.GetCount(filter);
            int pageCount = (int)Math.Ceiling((double) totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var commentReactions = await _unitOfWork.CommentReactionRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            var commentReactionsResult = _mapper.Map<List<GetCommentReactionResponse>>(commentReactions);

            return new PagedResponse<List<GetCommentReactionResponse>>(commentReactionsResult, totalItems, 200);
        }

        public async Task<IResponse> GetReactionById(string requestUserId, Guid commentId, int reactionId)
        {
            var entity = await _unitOfWork.CommentReactionRepository.GetById(commentId, requestUserId, reactionId);
            
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(entity), 200);

        }

        public async Task<IResponse> CreateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId) ?? throw new NotFoundException("Comment id: " + commentId.ToString());

            var checkExist = await _unitOfWork.CommentReactionRepository.FindOneBy(x => x.CommentId == commentId && x.UserId == requestUserId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.ReactionExist);
            }

            var addEntity = _mapper.Map<CommentReaction>(request);
            addEntity.CommentId = commentId;
            addEntity.UserId = requestUserId;

            await _unitOfWork.CommentReactionRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var addedEntity = await _unitOfWork.CommentReactionRepository.GetById(commentId, requestUserId, addEntity.ReactionId);

            var response = _mapper.Map<GetCommentReactionResponse>(addedEntity);

            await _notificationService.CreateNotification(requestUserId, comment.UserId, NotificationEnum.COMMENT_REACTION, response);

            return new DataResponse<GetCommentReactionResponse>(response, 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> UpdateReaction(string requestUserId, Guid commentId, Guid commentReactionId, CreateCommentReactionRequest request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Comment"));
            }
            var reaction = await _unitOfWork.CommentReactionRepository.GetById(commentReactionId);

            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Reaction"));
            }

            _mapper.Map(request, reaction);

            await _unitOfWork.CommentReactionRepository.Update(reaction);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(reaction), 200, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> DeleteReaction(string requestUserId, Guid commentId, Guid commentReactionId)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Comment"));
            }

            var reaction = await _unitOfWork.CommentReactionRepository.GetById(commentId);
            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.CommentReactionRepository.Delete(commentReactionId);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);

        }

        private async Task<bool> CheckPermission(string userId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId, new Expression<Func<Post, object>>[]
            {
                x => x.Group
            }) ?? throw new NotFoundException("Post");

            if (userId == post.AuthorId) return true;

            switch (post.Access)
            {
                case PostAccess.ONLY_ME:
                    return post.AuthorId == userId;
                case PostAccess.ONLY_FRIEND:
                    return await _unitOfWork.FriendshipRepository.ExistFriendShip(userId, post.AuthorId);
                case PostAccess.PUBLIC:
                    return true;
                case PostAccess.GROUP:
                    if (post.Group.IsPublic) return true;
                    return await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == post.GroupId && x.UserId == userId) != null;
                default:
                    return false;
            }
        }

        public async Task<IResponse> StatsReport(string requestId)
        {
            //var user = await _userManager.FindByIdAsync(requestId) ?? throw new NotFoundException("User id: " + requestId);

            //if (!await _userManager.IsInRoleAsync(user, RoleName.Administrator)) return new ErrorResponse(401, Messages.UnAuthorized);

            var totalComment = await _unitOfWork.PostCommentRepository.GetCount(x => x.Status == 1);

            var response = new StatsCommentResponse
            {
                TotalComment = totalComment,
            };

            return new DataResponse<StatsCommentResponse>(response, 200);
        }

        #endregion

    }

}
