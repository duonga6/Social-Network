using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.CommentReaction.Responses;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.DTOs.PostComment.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostCommentService : BaseServices<PostCommentService>, IPostCommentService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public PostCommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostCommentService> logger, UserManager<User> userManager, INotificationService notificationService) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        #region Comment
        public async Task<IResponse> Create(string requestUserId, CreatePostCommentRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null) 
            { 
                return new ErrorResponse(404, Messages.NotFounb("Post")); 
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            var addComment = _mapper.Map<PostComment>(request);
            addComment.UserId = requestUserId;

            await _unitOfWork.PostCommentRepository.Add(addComment);

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            await _notificationService.CreateNotification(requestUserId, post.AuthorId, TypeNotification.PostComment);

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(addComment), 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
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
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }    

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            Expression<Func<PostComment, bool>> filter = x => x.Status == 1 && x.PostId == postId;
            
            if (searchString != null)
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

            return new PagedResponse<List<GetPostCommentResponse>>(commentsResponse, 200, totalItems);
        }

        public async Task<IResponse> GetById(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            if (!await CheckAccessPost(requestUserId, comment.UserId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(comment), 200);

        }

        public async Task<IResponse> Update(string requestUserId, Guid id, UpdatePostCommentRequest request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id, false);

            if (comment == null) 
            {
                return new ErrorResponse(404, Messages.NotFound);
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

        private async Task<bool> CheckAccessPost(string requestUserId, string targetUserId)
        {
            var requestUser = await _unitOfWork.UserRepository.FindById(targetUserId);
            var targetUser = await _unitOfWork.UserRepository.FindById(requestUserId);

            if (requestUser == null || targetUser == null) return false;

            // Is owner
            if (requestUserId == targetUserId)
            {
                return true;
            }


            // Is friend
            if ( await _unitOfWork.FriendshipRepository.IsFriend(requestUserId, targetUserId))
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(targetUser, RoleName.Administrator);

        }
        
        private async Task<bool> CheckOwnerComment(string requestUserId, string authorCommentId)
        {
            var requestUser = await _unitOfWork.UserRepository.FindById(requestUserId);
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
                return new ErrorResponse(404, Messages.NotFound);
            }

            var post = await _unitOfWork.PostRepository.GetById(comment.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post of comment"));
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
                return new ErrorResponse(404, Messages.NotFound);
            }    

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(entity), 200);

        }

        public async Task<IResponse> CreateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Comment"));
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

            await _notificationService.CreateNotification(requestUserId, comment.UserId, TypeNotification.PostCommentReaction);

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(addedEntity), 204, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> UpdateReaction(string requestUserId, Guid commentId, CreateCommentReactionRequest request)
        {
            var reaction = await _unitOfWork.CommentReactionRepository.GetById(commentId, requestUserId, request.ReactionId);
            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            _mapper.Map(request, reaction);

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(reaction), 204, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> DeleteReaction(string requestUserId, Guid commentId, int reactionId)
        {
            var reaction = await _unitOfWork.CommentReactionRepository.GetById(commentId, requestUserId, reactionId);
            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            await _unitOfWork.CommentReactionRepository.Delete(commentId, requestUserId, reaction.ReactionId);
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
