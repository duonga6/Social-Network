using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
using SocialNetwork.DataAccess.Enums;
using SocialNetwork.DataAccess.Utilities;

namespace SocialNetwork.Business.Services.Concrete
{
    public class PostReactionService : BaseServices<PostReactionService>, IPostReactionService
    {
        private readonly IFriendshipService _friendshipService;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public PostReactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostReactionService> logger, IFriendshipService friendshipService, UserManager<User> userManager, INotificationService notificationService) : base(unitOfWork, mapper, logger)
        {
            _friendshipService = friendshipService;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public async Task<IResponse> GetCount(string requestUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            int count = await _unitOfWork.PostReactionRepository.GetCountAsync(x => x.PostId == postId);

            return new DataResponse<int>(count, 200);
        }

        public async Task<IResponse> GetByUser(string requestUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var postReaction = await _unitOfWork.PostReactionRepository.FindOneByAsync(x => x.UserId == requestUserId && x.PostId == postId);

            if (postReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(postReaction.Reaction), 200);
        }

        public async Task<IResponse> GetByPost(string requestUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            // obj return
            var postReactions = new GetPostReactionResponses();
            
            // get reaction of this post by each ReactionEnum
            foreach (ReactionEnum react in Enum.GetValues(typeof(ReactionEnum)))
            {
                var item = await GetPostReactionByReaction(requestUserId, postId, (int)react);

                if (item != null)
                {
                    postReactions.Reactions.Add(item);
                } 
                    
            }

            return new DataResponse<GetPostReactionResponses>(postReactions, 200);
        }

        public async Task<IResponse> GetOverview(string requestUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId) ?? throw new NotFoundException("Post id: " + postId.ToString());

            var listReactionWithCount = new List<ReactionWithCount>();

            foreach (ReactionEnum reaction in Enum.GetValues(typeof(ReactionEnum)))
            {
                int reactionCount = await _unitOfWork.PostReactionRepository.GetCountAsync(x => x.PostId == postId && x.ReactionId == (int)reaction);
                if (reactionCount > 0)
                {
                    listReactionWithCount.Add(new()
                    {
                        ReactionId = (int)reaction,
                        Total = reactionCount
                    });
                }
            }

            var userReactedInPost = await _unitOfWork.PostReactionRepository.FindOneByAsync(x => x.PostId == postId && x.UserId == requestUserId);

            var response = new GetOverviewReactionResponse()
            {
                Reactions = listReactionWithCount,
                UserReacted = _mapper.Map<UserReacted>(userReactedInPost),
            };

            return new DataResponse<GetOverviewReactionResponse>(response, 200);
        }

        public async Task<IResponse> Create(string requestUserId, CreatePostReactionsRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(request.PostId);

            if (!await CheckAccessPost(requestUserId, post.Id))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var checkExist = await _unitOfWork.PostReactionRepository.FindOneByAsync(x => x.UserId == requestUserId && x.PostId == request.PostId && x.ReactionId == request.ReactionId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.PostReactionExist);
            }

            var addPostReaction = _mapper.Map<PostReaction>(request);
            addPostReaction.UserId = requestUserId;

            await _unitOfWork.PostReactionRepository.AddAsync(addPostReaction);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(500, Messages.STWrong);
            }

            var addedPostReaction = await _unitOfWork.PostReactionRepository.FindOneByAsync(x => x.PostId == request.PostId && x.UserId == requestUserId);

            var response = _mapper.Map<GetPostReactionResponse>(addedPostReaction);

            if (requestUserId != post.AuthorId)
            {
                await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.POST_REACTION, response);
            }

            return new DataResponse<GetPostReactionResponse>(response, 201, Messages.CreatedSuccessfully);

        }

        public async Task<IResponse> Update(string requestUserId, Guid id,UpdatePostReactionRequest request)
        {
            var postReaction = await _unitOfWork.PostReactionRepository.GetByIdAsync(id);

            if (postReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (postReaction.UserId != requestUserId)
            {
                return new ErrorResponse(400, Messages.NotOwnerPostReaction);
            }

            postReaction.ReactionId = request.ReactionId;
            await _unitOfWork.PostReactionRepository.UpdateAsync(postReaction);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(500, Messages.STWrong);
            }

            var postReactionUpdated = await _unitOfWork.PostReactionRepository.GetByIdAsync(id);

            return new DataResponse<GetPostReactionResponse>(_mapper.Map<GetPostReactionResponse>(postReactionUpdated), 201, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid Id)
        {
            var postReaction = await _unitOfWork.PostReactionRepository.GetByIdAsync(Id);
            if (postReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (postReaction.UserId != requestUserId)
            {
                return new ErrorResponse(400, Messages.NotOwnerPostReaction);
            }

            await _unitOfWork.PostReactionRepository.DeleteAsync(Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(500, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);

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

        private async Task<bool> CheckAccessPost(string requestId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId) ?? throw new NotFoundException("Post id: " + postId.ToString());

            switch (post.Access)
            {
                case PostAccess.ONLY_ME:
                    return post.AuthorId == requestId;
                case PostAccess.GROUP:
                    var group = await _unitOfWork.GroupRepository.GetByIdAsync(post.GroupId!.Value) ?? throw new NotFoundException("Group id: " + post.GroupId.ToString());
                    if (group.IsPublic) return true;

                    return await _unitOfWork.GroupMemberRepository.FindOneByAsync(x => x.GroupId == group.Id && x.UserId == requestId) != null;
                case PostAccess.PUBLIC:
                    return true;
                case PostAccess.ONLY_FRIEND:
                    return await _unitOfWork.FriendshipRepository.IsExistFriendshipAsync(requestId, post.AuthorId);
                default:
                    return false;
            }
        }
    
        private async Task<PostReactionDetail?> GetPostReactionByReaction(string requestUserId, Guid postId, int reactionId)
        {
            var reaction = await _unitOfWork.ReactionRepository.GetByIdAsync(reactionId);
            var postReactionCount = await _unitOfWork.PostReactionRepository.GetCountAsync(x => x.PostId == postId && x.ReactionId == reactionId);

            if (postReactionCount == 0) return null;

            ICollection<PostReaction> postReactions = null!;

            if (postReactionCount > 20)
            {
                postReactions = await _unitOfWork.PostReactionRepository.GetPagedAsync(20, 1, x => x.PostId == postId && x.ReactionId == reactionId, x => x.CreatedDate);
            } 
            else
            {
                postReactions = await _unitOfWork.PostReactionRepository.FindByAsync(x => x.PostId == postId && x.ReactionId == reactionId);
            }

            var response = new PostReactionDetail()
            {
                Id = reaction.Id,
                Name = reaction.Name,
                IconUrl = reaction.IconUrl,
                ColorCode = reaction.ColorCode,
                Users = postReactions.Select(x => _mapper.Map<BasicUserResponse>(x.User)).ToList(),
                Total = postReactionCount
            };

            // user request is reacted this post ?
            var userReacted = await _unitOfWork.PostReactionRepository.FindOneByAsync(x => x.UserId == requestUserId && x.PostId == postId && x.ReactionId == reaction.Id);

            // move it to first element of PostReactionDetail.Users
            if (userReacted != null)
            {
                var isExistedInUsers = response.Users.FirstOrDefault(x => x.Id == requestUserId);

                if (isExistedInUsers != null)
                {
                    response.Users.Insert(0, isExistedInUsers);
                    response.Users.Remove(isExistedInUsers);
                } else
                {
                    var user = _mapper.Map<BasicUserResponse>(await _unitOfWork.UserRepository.GetByIdAsync(userReacted.UserId));
                    response.Users.Insert(0, user);
                    response.Total -= 1;
                }
            }

            return response;
        }
    }
}
