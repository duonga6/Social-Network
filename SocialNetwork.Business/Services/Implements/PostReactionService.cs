using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Responses;
using SocialNetwork.Business.DTOs.Reaction.Response;
using SocialNetwork.Business.DTOs.User.Responses;
using SocialNetwork.Business.Services.Implements.Base;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostReactionService : BaseServices<PostReactionService>, IPostReactionService
    {
        private readonly IFriendshipService _friendshipService;
        private readonly UserManager<User> _userManager;
        public PostReactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostReactionService> logger, IFriendshipService friendshipService, UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _friendshipService = friendshipService;
            _userManager = userManager;
        }

        public async Task<IResponse> GetCount(string requestUserId, Guid postId)
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

            int count = await _unitOfWork.PostReactionRepository.GetCount(x => x.PostId == postId);

            return new DataResponse<int>(count, 200);
        }

        public async Task<IResponse> GetByUser(string requestUserId, Guid postId)
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

            var postReaction = await _unitOfWork.PostReactionRepository.FindOneBy(x => x.UserId == requestUserId && x.PostId == postId);

            if (postReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(postReaction.Reaction), 200);
        }

        public async Task<IResponse> GetByPost(string requestUserId, Guid postId)
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

            // obj return
            var postReactions = new GetPostReactionResponse();
            
            // get reaction of this post by each ReactionEnum
            foreach (ReactionEnum react in Enum.GetValues(typeof(ReactionEnum)))
            {
                var item = await GetPostReactionByReaction(requestUserId, postId, (int)react);

                if (item != null)
                {
                    postReactions.Reactions.Add(item);
                } 
                    
            }

            return new DataResponse<GetPostReactionResponse>(postReactions, 200);
        }

        public async Task<IResponse> Create(string requestUserId, CreatePostReactionsRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var checkExist = await _unitOfWork.PostReactionRepository.FindOneBy(x => x.UserId == requestUserId && x.PostId == request.PostId && x.ReactionId == request.ReactionId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.PostReactionExist);
            }

            var addPostReaction = _mapper.Map<PostReaction>(request);
            addPostReaction.UserId = requestUserId;

            await _unitOfWork.PostReactionRepository.Add(addPostReaction);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(500, Messages.STWrong);
            }

            var addedPostReaction = await _unitOfWork.PostReactionRepository.FindOneBy(x => x.PostId == request.PostId && x.UserId == requestUserId);

            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(addedPostReaction.Reaction), 201, Messages.CreatedSuccessfully);

        }

        public async Task<IResponse> Update(string requestUserId, UpdatePostReactionRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckAccessPost(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var postReaction = await _unitOfWork.PostReactionRepository.GetById(request.PostId, requestUserId, false);

            if (postReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            postReaction.ReactionId = request.ReactionId;
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(500, Messages.STWrong);
            }

            var postReactionUpdated = await _unitOfWork.PostReactionRepository.GetById(request.PostId, requestUserId);

            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(postReactionUpdated.Reaction), 201, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid postId)
        {
            var postReaction = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId);
            if (postReaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.PostReactionRepository.Delete(postReaction.PostId, postReaction.UserId);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(500, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);

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
    
        private async Task<PostReactionDetail?> GetPostReactionByReaction(string requestUserId, Guid postId, int reactionId)
        {
            var reaction = await _unitOfWork.ReactionRepository.GetById(reactionId);
            var postReactionCount = await _unitOfWork.PostReactionRepository.Count(x => x.PostId == postId && x.ReactionId == reactionId);

            if (postReactionCount == 0) return null;

            ICollection<PostReaction> postReactions = null!;

            if (postReactionCount > 20)
            {
                postReactions = await _unitOfWork.PostReactionRepository.GetPaged(20, 1, x => x.PostId == postId && x.ReactionId == reactionId, x => x.CreatedAt);
            } 
            else
            {
                postReactions = await _unitOfWork.PostReactionRepository.FindBy(x => x.PostId == postId && x.ReactionId == reactionId);
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
            var userReacted = await _unitOfWork.PostReactionRepository.FindOneBy(x => x.UserId == requestUserId && x.PostId == postId);

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
                    var user = _mapper.Map<BasicUserResponse>(await _unitOfWork.UserRepository.GetById(userReacted.UserId));
                    response.Users.Insert(0, user);
                    response.Total -= 1;
                }
            }

            return response;
        }
    }
}
