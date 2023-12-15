using AutoMapper;
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

namespace SocialNetwork.Business.Services.Implements
{
    public class PostService : BaseServices<PostService>, IPostService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public PostService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ILogger<PostService> logger,
                           INotificationService notificationService,
                           UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        #region Post
        public async Task<IResponse> GetAll()
        {
            var entity = await _unitOfWork.PostRepository.GetAll();
            return new DataResponse(_mapper.Map<List<GetPostResponse>>(entity), 200);
        }
        public async Task<IResponse> GetById(string requestingUserId, Guid id)
        {
            var post = await _unitOfWork.PostRepository.GetById(id);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            if (!await _unitOfWork.FriendshipRepository.IsFriend(requestingUserId, post.AuthorId))
            {
                return new ErrorResponse(403, Messages.NotFriend);
            }

            return new DataResponse(_mapper.Map<GetPostResponse>(post), 200);
        }
        public async Task<IResponse> Create(CreatePostRequest request)
        {
            var user = await _unitOfWork.UserRepository.FindById(request.AuthorId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var addEntity = _mapper.Map<Post>(request);
            await _unitOfWork.PostRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            await _notificationService.CreateNotification(addEntity.AuthorId, "", TypeNotification.Post);

            return new DataResponse(_mapper.Map<GetPostResponse>(addEntity), 200, Messages.CreatedSuccessfully);
        }
        public async Task<IResponse> Update(string requestingUserId, Guid id, UpdatePostRequest request)
        {
            var postUpdate = _mapper.Map<Post>(request);
            postUpdate.Id = id;
            postUpdate.AuthorId = requestingUserId;

            if (!await _unitOfWork.PostRepository.Update(postUpdate))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }
            
            if (!await CheckPermission(requestingUserId, postUpdate.AuthorId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            foreach (var item in request.ImagesDelete)
            {
                if (!await _unitOfWork.PostImageRepository.Delete(item))
                {
                    return new ErrorResponse(404, Messages.NotFounb("Image delete"));
                }
            }

            foreach (var item in request.ImagesUpdate)
            {
                var updateImage = _mapper.Map<PostImage>(item);
                if (!await _unitOfWork.PostImageRepository.Update(updateImage))
                {
                    return new ErrorResponse(404, Messages.NotFounb("Image update"));
                }
            }

            foreach (var item in request.ImagesAdd)
            {
                var addImage = _mapper.Map<PostImage>(item);
                addImage.PostId = postUpdate.Id;
                await _unitOfWork.PostImageRepository.Add(addImage);
            }

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var updatedEntity = await _unitOfWork.PostRepository.GetById(id);

            return new DataResponse(_mapper.Map<GetPostResponse>(updatedEntity), 204, Messages.UpdatedSuccessfully);

        }
        public async Task<IResponse> Delete(string requestingUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
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
            var requestUser = await _unitOfWork.UserRepository.FindById(requestingUserId);
            var targetUser = await _unitOfWork.UserRepository.FindById(targetUserId);

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

        #region Post Comment
        public async Task<IResponse> GetAllComments(string requestUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null) return new ErrorResponse(404, Messages.NotFound);

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var result = await _unitOfWork.PostCommentRepository.GetByPost(postId);
            return new DataResponse(_mapper.Map<List<GetPostCommentReponse>>(result), 200);
        }
        public async Task<IResponse> GetCommentById(string requestUserId, Guid postId, Guid commentId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null) return new ErrorResponse(404, Messages.NotFound);

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var result = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.PostId == postId && x.Id == commentId && x.Status == 1);
            if (result == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(result), 200);
        }
        public async Task<IResponse> CreateComment(string requestUserId, Guid postId, CreateCommentRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null) return new ErrorResponse(404, Messages.NotFound);

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

            await _notificationService.CreateNotification(requestUserId, post.AuthorId, TypeNotification.PostComment);

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(addEntity), 200, Messages.CreatedSuccessfully);

        }
        public async Task<IResponse> DeleteComment(string requestUserId, Guid postId, Guid commentId)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
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
                return new ErrorResponse(404, Messages.NotFound);
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

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(entity), 204);
        }

        private async Task<bool> CheckPermissionWithFriendAccess(string requestingUserId, string targetUserId)
        {
            var requestUser = await _unitOfWork.UserRepository.FindById(requestingUserId);
            var targetUser = await _unitOfWork.UserRepository.FindById(targetUserId);

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
            if (await _unitOfWork.FriendshipRepository.IsFriend(requestingUserId, targetUserId))
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }
        private async Task<bool> CheckOwnerOrAdmin(string requestingUserId, string targetUserId)
        {
            var requestUser = await _unitOfWork.UserRepository.FindById(requestingUserId);
            var targetUser = await _unitOfWork.UserRepository.FindById(targetUserId);

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

        public async Task<IResponse> GetAllReactions(string requestUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }    

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var reactions = await _unitOfWork.PostReactionRepository.GetByPost(postId);

            return new DataResponse(_mapper.Map<List<GetPostReactionResponse>>(reactions), 200);
        }
        public async Task<IResponse> GetReactionById(string requestUserId, Guid postId, int reactionId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            var reaction = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, reactionId);

            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Reaction"));
            } 

            return new DataResponse(_mapper.Map<GetPostReactionResponse>(reaction), 200);
                
        }
        public async Task<IResponse> CreateReaction(string requestUserId, Guid postId, CreatePostReactionRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
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

            await _notificationService.CreateNotification(requestUserId, post.AuthorId, TypeNotification.PostReaction);

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, entity.ReactionId);

            return new DataResponse(_mapper.Map<GetPostReactionResponse>(entityAdded), 201, Messages.CreatedSuccessfully);
        }
        public async Task<IResponse> UpdateReaction(string requestUserId, Guid postId,int reactionId, CreatePostReactionRequest request)
        {
            var checkExits = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, reactionId);
            if (checkExits == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = requestUserId;
            entity.PostId = postId;

            if (!await _unitOfWork.PostReactionRepository.Update(entity))
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, entity.ReactionId);

            return new DataResponse(_mapper.Map<GetPostReactionResponse>(entityAdded), 204, Messages.UpdatedSuccessfully);
        }
        public async Task<IResponse> DeleteReaction(string requestUserId, Guid postId,int reactionId)
        {
            var entity = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId, reactionId);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
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
