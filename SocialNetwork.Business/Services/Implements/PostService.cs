using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostService : BaseServices, IPostService
    {
        private readonly UserManager<User> _userManager;    
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
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
            var entity = await _unitOfWork.PostRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            if (!await CheckPermission(requestingUserId, entity.AuthorId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return new DataResponse(_mapper.Map<GetPostResponse>(entity), 200);
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

            return new DataResponse(_mapper.Map<GetPostResponse>(addEntity), 200, Messages.CreatedSuccessfully);
        }
        public async Task<IResponse> Update(string requestingUserId, Guid id, UpdatePostRequest request)
        {

            var entityUpdate = _mapper.Map<Post>(request);
            entityUpdate.Id = id;
            entityUpdate.AuthorId = requestingUserId;

            if (!await _unitOfWork.PostRepository.Update(entityUpdate))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }
            
            if (!await CheckPermission(requestingUserId, entityUpdate.AuthorId))
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
                addImage.PostId = entityUpdate.Id;
                await _unitOfWork.PostImageRepository.Add(addImage);
            }

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.STWroong);
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
                return new ErrorResponse(400, Messages.STWroong);
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

            if (requestingUserId != targetUserId && !await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator))
            {
                return false;
            }    

            if (requestingUserId != targetUserId)
            {
                return false;    
            }

            return true;
        }


        #endregion

        #region Post Comment
        public async Task<IResponse> GetAllComments(Guid postId)
        {
            var result = await _unitOfWork.PostCommentRepository.FindBy(x => x.PostId == postId && x.Status == 1);
            return new DataResponse(_mapper.Map<List<GetPostCommentReponse>>(result), 200);
        }
        public async Task<IResponse> GetCommentById(Guid postId, Guid commentId)
        {
            var result = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.PostId == postId && x.Id == commentId);
            if (result == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(result), 200);
        }
        public async Task<IResponse> CreateComment(Guid postId, string userId, CreateCommentRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            } 

            var addEntity = _mapper.Map<PostComment>(request);
            addEntity.PostId = postId;
            addEntity.UserId = userId;

            await _unitOfWork.PostCommentRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }    

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(addEntity), 200, Messages.CreatedSuccessfully);

        }
        public async Task<IResponse> DeleteComment(Guid postId, Guid commentId, string userId)
        {
            var entity = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == commentId && x.PostId == postId && x.UserId == userId && x.Status == 1);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            if (entity.UserId != userId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            await _unitOfWork.PostCommentRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);

        }
        public async Task<IResponse> UpdateComment(Guid postId, Guid commentId, string userId, UpdateCommentRequest request)
        {
            var entity = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.Id == commentId && x.PostId == postId && x.UserId == userId && x.Status == 1);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            if (entity.UserId != userId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var updateEntity = _mapper.Map<PostComment>(request);
            updateEntity.PostId = postId;
            updateEntity.Id = commentId;
            updateEntity.UserId = userId;

            if (!await _unitOfWork.PostCommentRepository.Update(updateEntity))
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(updateEntity), 204);
        }

        #endregion

        #region Post Reaction
        public async Task<IResponse> GetAllReactions(Guid postId)
        {    
            var result = await _unitOfWork.PostReactionRepository.GetByPost(postId);

            return new DataResponse(_mapper.Map<List<GetPostReactionResponse>>(result), 200);
        }

        public async Task<IResponse> GetReactionById(Guid postId, string userId, int reactionId)
        {
            if (!await CheckExitsPost(postId, userId))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            var result = await _unitOfWork.PostReactionRepository.GetById(postId, userId, reactionId);
            if (result == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            } 

            return new DataResponse(_mapper.Map<GetPostReactionResponse>(result), 200);
                
        }

        public async Task<IResponse> CreateReaction(Guid postId, string userId, CreatePostReactionRequest request)
        {
            if (!await CheckExitsPost(postId, userId))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = userId;
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

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, userId, entity.ReactionId);

            return new DataResponse(_mapper.Map<GetPostReactionResponse>(entityAdded), 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> UpdateReaction(Guid postId, string userId, int reactionId, CreatePostReactionRequest request)
        {
            var checkExits = await _unitOfWork.PostReactionRepository.GetById(postId, userId, reactionId);
            if (checkExits == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = userId;
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

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, userId, entity.ReactionId);

            return new DataResponse(_mapper.Map<GetPostReactionResponse>(entityAdded), 204, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> DeleteReaction(Guid postId, string userId, int reactionId)
        {
            var entity = await _unitOfWork.PostReactionRepository.GetById(postId, userId, reactionId);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            await _unitOfWork.PostReactionRepository.Delete(postId, userId, reactionId);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }
        #endregion

        private async Task<bool> CheckExitsPost(Guid postId, string userId)
        {
            var user = await _unitOfWork.PostRepository.FindOneBy(x => x.Id == postId && x.AuthorId == userId);

            return user != null;
        }
    }
}
