using AutoMapper;
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

namespace SocialNetwork.Business.Services.Concrete
{
    public class CommentReactionService : BaseServices<CommentReactionService>, ICommentReactionService
    {
        private readonly IFriendshipService _friendshipService;
        private readonly INotificationService _notificationService;
        public CommentReactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CommentReactionService> logger, IFriendshipService friendshipService, INotificationService notificationService) : base(unitOfWork, mapper, logger)
        {
            _friendshipService = friendshipService;
            _notificationService = notificationService;
        }

        public async Task<IResponse> Create(string requestUserId, CreateCommentReactionRequests request)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(request.CommentId);
            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Comment {request.CommentId}"));
            }

            var post = await _unitOfWork.PostRepository.GetById(comment.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound($"Post of this comment"));
            }

            if (!(await CheckAccess(requestUserId, post.AuthorId)))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var checkExist = await _unitOfWork.CommentReactionRepository.GetById(request.CommentId, requestUserId, request.ReactionId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.CommentReactionExist);
            }

            var reactionAdd = _mapper.Map<CommentReaction>(request);
            reactionAdd.UserId = requestUserId;

            await _unitOfWork.CommentReactionRepository.Add(reactionAdd);
            var result = await _unitOfWork.CompleteAsync();


            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            var reactionAdded = await _unitOfWork.CommentReactionRepository.GetById(reactionAdd.Id);
            var response = _mapper.Map<GetCommentReactionResponse>(reactionAdded);

            await _notificationService.CreateNotification(requestUserId, comment.UserId, NotificationEnum.COMMENT_REACTION, response);

            return new DataResponse<GetCommentReactionResponse>(response, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid id)
        {
            var commentReaction = await _unitOfWork.CommentReactionRepository.GetById(id);
            if (commentReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Reaction of comment"));
            }

            if (requestUserId != commentReaction.UserId)
            {
                return new ErrorResponse(400, Messages.NotOwnerCommentReaction);
            }

            await _unitOfWork.CommentReactionRepository.Delete(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> GetById(string requestUserId, Guid id)
        {
            var entity = await _unitOfWork.CommentReactionRepository.GetById(id);

            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            var response = _mapper.Map<GetCommentReactionResponse>(entity);

            return new DataResponse<GetCommentReactionResponse>(response, 200);
        }

        public async Task<IResponse> Update(string requestUserId, Guid id, UpdateCommentReactionRequest request)
        {
            var commentReaction = await _unitOfWork.CommentReactionRepository.GetById(id);
            if (commentReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Comment reaction"));
            }

            if (commentReaction.UserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotOwnerCommentReaction);
            }

            commentReaction.ReactionId = request.ReactionId;
            await _unitOfWork.CommentReactionRepository.Update(commentReaction);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new DataResponse<GetCommentReactionResponse>(_mapper.Map<GetCommentReactionResponse>(commentReaction), 203, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> GetOverview(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == id && x.Post.Status == 1) ?? throw new NotFoundException("Comment id: " + id.ToString());

            var userReacted = await _unitOfWork.CommentReactionRepository.FindOneBy(x => x.CommentId == id && x.UserId == requestUserId);

            var listReactionWithCount = new List<ReactionWithCount>();

            foreach(ReactionEnum reaction in Enum.GetValues(typeof(ReactionEnum)))
            {
                var reactionCount = await _unitOfWork.CommentReactionRepository.GetCount(x => x.CommentId == id && x.ReactionId == (int)reaction);
                
                if (reactionCount > 0)
                {
                    listReactionWithCount.Add(new()
                    {
                        ReactionId = (int)reaction,
                        Total = reactionCount,
                    });
                }
                
            }

            var result = new GetOverviewReactionResponse()
            {
               Reactions = listReactionWithCount,
               UserReacted = _mapper.Map<UserReacted>(userReacted),
            };

            return new DataResponse<GetOverviewReactionResponse>(result, 200);
        }
    
        private async Task<bool> CheckAccess(string userId1, string userId2)
        {
            if (await _friendshipService.IsFriend(userId1, userId2))
            {
                return true;
            }

            return false;
        }
    }
}
