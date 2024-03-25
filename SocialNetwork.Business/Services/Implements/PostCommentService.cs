using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.CommentReactions.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.Services.Implements.Base;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostCommentService : BaseServices<PostCommentService>, IPostCommentService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IFriendshipService _friendshipService;
        private readonly ICommentReactionService _commentReactionService;

        public PostCommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostCommentService> logger, UserManager<User> userManager, INotificationService notificationService, IFriendshipService friendshipService, ICommentReactionService commentReactionService) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _friendshipService = friendshipService;
            _commentReactionService = commentReactionService;
        }

        #region Comment
        public async Task<IResponse> Create(string requestUserId, CreatePostCommentRequest request)
        {

            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            PostComment? parentComment = null;

            if (request.ParentCommentId != null)
            {
                parentComment = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == request.ParentCommentId && x.Status == 1);
                if (parentComment == null)
                {
                    return new ErrorResponse(404, Messages.NotFound("Parent comment"));
                }
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
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

            var response = _mapper.Map<GetPostCommentResponse>(addComment);

            if (addComment.UserId != parentComment?.UserId)
            {
                await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.POST_COMMENT, response);
            }

            return new DataResponse<GetPostCommentResponse>(response, 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            if (!await CheckOwnerComment(requestUserId, comment.UserId))
            {
                return new ErrorResponse(400, Messages.CommentNotOwner);
            }

            await _unitOfWork.PostCommentRepository.Delete(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public async Task<IResponse> GetAll(string requestUserId, string? searchString, int pageSize, int pageNumber, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }    

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            Expression<Func<PostComment, bool>> filter = x => x.Status == 1 && x.PostId == postId && x.ParentCommentId == null;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x => x.Content.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostCommentRepository.Count(filter);
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
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            Expression<Func<PostComment, bool>> filter = x => x.PostId == postId && x.ParentCommentId == parentId && x.Status == 1;

            int totalItems = await _unitOfWork.PostCommentRepository.GetCount(filter);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var comments = await _unitOfWork
                .PostCommentRepository
                .GetCursorPaged(pageSize, filter, getNext);

            bool hasNext = true;

            // Check has next
            var query = _unitOfWork.PostCommentRepository.GetQueryable().AsNoTracking().Where(filter);

            if (getNext)
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            } else
            {
                query = query.OrderBy(x => x.CreatedAt);
            }

            var checkCount = await query.Take(pageSize + 1).CountAsync();

            if (checkCount <= comments.Count)
            {
                hasNext = false;
            }

            var endCursor = comments.LastOrDefault()?.CreatedAt;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetPostCommentResponse>>(comments);

            return new CursorResponse<List<GetPostCommentResponse>>(response, endCursor, hasNext, totalItems);
        }

        public async Task<IResponse> GetById(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            if (!await CheckAccessPost(requestUserId, comment.UserId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(comment), 200);

        }

        public async Task<IResponse> GetCount(string requestUserId, Guid Id)
        {
            var post = await _unitOfWork.PostRepository.GetById(Id);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            int count = await _unitOfWork.PostCommentRepository.GetCount(x => x.PostId == Id && x.Status == 1);

            return new DataResponse<int>(count, 200, Messages.GetSuccessfully);
        }

        public async Task<IResponse> GetCountChild(string requestUserId, Guid commentId)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Comment {commentId}"));
            }

            var post = await _unitOfWork.PostRepository.GetById(comment.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Post of comment ${commentId}"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            int childCount = await _unitOfWork.PostCommentRepository.GetCount(x => x.ParentCommentId == commentId && x.Status == 1);

            return new DataResponse<int>(childCount, 200);
        }

        public async Task<IResponse> GetChild(string requestUserId, string? searchString, int pageSize, int pageNumber, Guid Id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(Id);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Comment"));
            }

            var post = await _unitOfWork.PostRepository.GetById(comment.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

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
            var comment = await _unitOfWork.PostCommentRepository.GetById(id, false);

            if (comment == null) 
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (!await CheckOwnerComment(requestUserId, comment.UserId))
            {
                return new ErrorResponse(400, Messages.CommentNotOwner);
            }

            _mapper.Map(request, comment);

            var result = await _unitOfWork.CompleteAsync();
            
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(comment), 204, Messages.UpdatedSuccessfully);

        }
        
        public async Task<IResponse> GetOverviewReaction(string requestUserId, Guid commentId)
        {
            return await _commentReactionService.GetOverview(requestUserId, commentId);
        }
        
        private async Task<bool> CheckAccessPost(string requestUserId, string targetUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(targetUserId);
            var targetUser = await _userManager.FindByIdAsync(requestUserId);

            if (requestUser == null || targetUser == null) return false;

            // Is owner
            if (requestUserId == targetUserId)
            {
                return true;
            }


            // Is friend
            if (await _friendshipService.IsFriend(requestUserId, targetUserId))
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(targetUser, RoleName.Administrator);
        }
        
        private async Task<bool> CheckOwnerComment(string requestUserId, string authorCommentId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            if (requestUser == null) return false;

            // Is owner comment
            if (requestUserId == authorCommentId)
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
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            var post = await _unitOfWork.PostRepository.GetById(comment.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post of comment"));
            }    

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(404, Messages.NotFriend);
            }

            Expression<Func<CommentReaction, bool>> filter = x => x.CommentId == commentId;

            int totalItems = await _unitOfWork.CommentReactionRepository.Count(filter);
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
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Comment"));
            }    

            if (await CheckExitCommentReaction(commentId, requestUserId))
            {
                return new ErrorResponse(400, Messages.CommentReactionExist);
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

            return new DataResponse<GetCommentReactionResponse>(response, 204, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> UpdateReaction(string requestUserId, Guid commentId, Guid commentReactionId, CreateCommentReactionRequest request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId, false);
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

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(reaction), 204, Messages.UpdatedSuccessfully);
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

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);

        }

        private async Task<bool> CheckExitCommentReaction(Guid commentId, string userId)
        {
            var comment = await _unitOfWork.CommentReactionRepository.FindOneBy(x => x.CommentId == commentId && x.UserId == userId);

            return comment != null;
        }

        #endregion

    }

}
