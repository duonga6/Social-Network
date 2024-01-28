using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.PostComment.Responses;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostService : BaseServices<PostService>, IPostService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IPostCommentService _postCommentService;
        private readonly IFriendshipService _friendshipService;

        public PostService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ILogger<PostService> logger,
                           INotificationService notificationService,
                           UserManager<User> userManager,
                           IPostCommentService postCommentService,
                           IFriendshipService friendshipService) : base(unitOfWork, mapper, logger)
        {
            _notificationService = notificationService;
            _userManager = userManager;
            _postCommentService = postCommentService;
            _friendshipService = friendshipService;
        }

        #region Post
        public async Task<IResponse> GetAll(string requestUserId, string? searchString, int pageSize, int pageNumber)
        {
            if (await _userManager.FindByIdAsync(requestUserId) == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            Expression<Func<Post, bool>> filter;

            Expression<Func<Post, bool>> active = x => x.Status == 1;
            Expression<Func<Post, bool>> search = x => x.Content.Contains(searchString!) || (x.Author.FirstName + x.Author.LastName).Contains(searchString!);
            Expression<Func<Post, bool>> isFriendOrOwner = x => x.AuthorId == requestUserId ||
            (x.Author.Friendships1.Any(m => (m.RequestUserId == requestUserId || m.TargetUserId == requestUserId) && m.FriendshipTypeId == (int)FriendshipEnum.Accepted) || 
            x.Author.Friendships2.Any(m => (m.RequestUserId == requestUserId || m.TargetUserId == requestUserId) && m.FriendshipTypeId == (int)FriendshipEnum.Accepted));

            if (await CheckAdmin(requestUserId))
            {
                if (searchString == null)
                {
                    filter = active;
                }
                else
                {
                    filter = search.And(active);
                }
            }   
            else
            {

                if (searchString == null)
                {
                    filter = isFriendOrOwner.And(active);
                }
                else
                {
                    filter = isFriendOrOwner.And(search).And(active);
                }    
            }

            int totalItems = await _unitOfWork.PostRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var posts = await _unitOfWork.PostRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            var postsResponse = _mapper.Map<List<GetPostResponse>>(posts);


            return new PagedResponse<List<GetPostResponse>>(postsResponse, totalItems, 200);
        }
      
        public async Task<IResponse> GetById(string requestingUserId, Guid id)
        {
            var post = await _unitOfWork.PostRepository.GetById(id);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await _friendshipService.IsFriend(requestingUserId, post.AuthorId))
            {
                return new ErrorResponse(403, Messages.NotFriend);
            }

            return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(post), 200);
        }
     
        public async Task<IResponse> Create(CreatePostRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.AuthorId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var addEntity = _mapper.Map<Post>(request);
            await _unitOfWork.PostRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            await _notificationService.CreateNotification(addEntity.AuthorId, "", NotificationEnum.Post);

            return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(addEntity), 200, Messages.CreatedSuccessfully);
        }
     
        public async Task<IResponse> Update(string requestingUserId, Guid id, UpdatePostRequest request)
        {
            var postUpdate = _mapper.Map<Post>(request);
            postUpdate.Id = id;
            postUpdate.AuthorId = requestingUserId;

            if (!await _unitOfWork.PostRepository.Update(postUpdate))
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }
            
            if (!await CheckPermission(requestingUserId, postUpdate.AuthorId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            foreach (var item in request.ImagesDelete)
            {
                if (!await _unitOfWork.PostImageRepository.Delete(item))
                {
                    return new ErrorResponse(404, Messages.NotFound("Image delete"));
                }
            }

            foreach (var item in request.ImagesUpdate)
            {
                var updateImage = _mapper.Map<PostMedia>(item);
                if (!await _unitOfWork.PostImageRepository.Update(updateImage))
                {
                    return new ErrorResponse(404, Messages.NotFound("Image update"));
                }
            }

            foreach (var item in request.ImagesAdd)
            {
                var addImage = _mapper.Map<PostMedia>(item);
                addImage.PostId = postUpdate.Id;
                await _unitOfWork.PostImageRepository.Add(addImage);
            }

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var updatedEntity = await _unitOfWork.PostRepository.GetById(id);

            return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(updatedEntity), 204, Messages.UpdatedSuccessfully);

        }
     
        public async Task<IResponse> Delete(string requestingUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckPermission(requestingUserId, post.AuthorId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            await _unitOfWork.PostRepository.Delete(post.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }
     
        private async Task<bool> CheckPermission(string requestingUserId, string targetUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestingUserId);
            var targetUser = await _userManager.FindByIdAsync(targetUserId);

            if (requestUser == null || targetUser == null)
            {
                return false;
            }

            // Is owner
            if (requestingUserId == targetUserId)
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }

        private async Task<bool> CheckAdmin(string requestUserId)
        {
            var user = await _userManager.FindByIdAsync(requestUserId);
            if (user == null) return false;

            return await _userManager.IsInRoleAsync(user, RoleName.Administrator);
        }

        #endregion

        #region Post Comment
        public async Task<IResponse> GetComments(string requestUserId, Guid postId, string? searchString, int pageSize, int pageNumber)
        {
            return await _postCommentService.GetAll(requestUserId, searchString, pageSize, pageNumber, postId);
        }
        
        public async Task<IResponse> GetCommentById(string requestUserId, Guid postId, Guid commentId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null) return new ErrorResponse(404, Messages.NotFound());

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var result = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.PostId == postId && x.Id == commentId && x.Status == 1);
            if (result == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(result), 200);
        }
        
        public async Task<IResponse> CreateComment(string requestUserId, Guid postId, CreateCommentRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null) return new ErrorResponse(404, Messages.NotFound());

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var addEntity = _mapper.Map<PostComment>(request);
            addEntity.PostId = postId;
            addEntity.UserId = requestUserId;

            await _unitOfWork.PostCommentRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.PostComment);

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(addEntity), 200, Messages.CreatedSuccessfully);

        }
        
        public async Task<IResponse> DeleteComment(string requestUserId, Guid postId, Guid commentId)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (comment.UserId != requestUserId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            await _unitOfWork.PostCommentRepository.Delete(comment.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);

        }
        
        public async Task<IResponse> UpdateComment(string requestUserId, Guid postId, Guid commentId, UpdateCommentRequest request)
        {
            var entity = await _unitOfWork.PostCommentRepository.GetById(commentId, false);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (!await CheckOwnerOrAdmin(requestUserId, entity.UserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            entity.Content = request.Content;

            await _unitOfWork.PostCommentRepository.Update(entity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(entity), 204);
        }

        private async Task<bool> CheckPermissionWithFriendAccess(string requestingUserId, string targetUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestingUserId);
            var targetUser = await _userManager.FindByIdAsync(targetUserId);

            if (requestUser == null || targetUser == null)
            {
                return false;
            }

            // Is owner
            if (requestingUserId == targetUserId)
            {
                return true;
            }

            // Is friend
            if (await _friendshipService.IsFriend(requestingUserId, targetUserId))
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }
        
        private async Task<bool> CheckOwnerOrAdmin(string requestingUserId, string targetUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestingUserId);
            var targetUser = await _userManager.FindByIdAsync(targetUserId);

            if (requestUser == null || targetUser == null)
            {
                return false;
            }

            // Is owner
            if (requestingUserId == targetUserId)
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }

        #endregion

        #region Post Reaction

        public async Task<IResponse> GetAllReactions(string requestUserId, Guid postId, int pageSize, int pageNumber)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }    

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            int totalItems = await _unitOfWork.PostReactionRepository.Count(x => x.PostId == postId);
            int pageCount = (int)Math.Ceiling((double) totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var reactions = await _unitOfWork.PostReactionRepository.GetPaged(pageSize, pageNumber, x => x.PostId == postId, x => x.CreatedAt);

            return new PagedResponse<List<GetPostReactionResponse>>(_mapper.Map<List<GetPostReactionResponse>>(reactions), totalItems, 200);
        }
       
        public async Task<IResponse> GetReactionById(string requestUserId, Guid postId, int reactionId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            var reaction = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, reactionId);

            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Reaction"));
            } 

            return new DataResponse<GetPostReactionResponse>(_mapper.Map<GetPostReactionResponse>(reaction), 200);
                
        }
       
        public async Task<IResponse> CreateReaction(string requestUserId, Guid postId, CreatePostReactionRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }    

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = requestUserId;
            entity.PostId = postId;

            if (!await _unitOfWork.PostReactionRepository.Add(entity))
            {
                return new ErrorResponse(400, Messages.PostReactionExist);
            }    

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.PostReaction);

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, entity.ReactionId);

            return new DataResponse<GetPostReactionResponse>(_mapper.Map<GetPostReactionResponse>(entityAdded), 201, Messages.CreatedSuccessfully);
        }
       
        public async Task<IResponse> UpdateReaction(string requestUserId, Guid postId,int reactionId, CreatePostReactionRequest request)
        {
            var checkExits = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, reactionId);
            if (checkExits == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = requestUserId;
            entity.PostId = postId;

            if (!await _unitOfWork.PostReactionRepository.Update(entity))
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, entity.ReactionId);

            return new DataResponse<GetPostReactionResponse>(_mapper.Map<GetPostReactionResponse>(entityAdded), 204, Messages.UpdatedSuccessfully);
        }
     
        public async Task<IResponse> DeleteReaction(string requestUserId, Guid postId,int reactionId)
        {
            var entity = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, reactionId);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.PostReactionRepository.Delete(postId, requestUserId, reactionId);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }
        
        #endregion
        
    }
}
