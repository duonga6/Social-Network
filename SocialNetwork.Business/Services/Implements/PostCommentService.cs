using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.CommentReaction.Responses;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.DTOs.PostComment.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostCommentService : BaseServices, IPostCommentService
    {
        private readonly UserManager<User> _userManager;
        public PostCommentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        #region Comment
        public async Task<IResponse> Create(string requestUserId, CreatePostCommentRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null) { return new ErrorResponse(404, Messages.NotFounb("Post")); }

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

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(addComment), 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestUserId, Guid id)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(id);

            if (comment == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            if (comment.UserId != requestUserId)
            {
                return new ErrorResponse(400, Messages.CommentNotOwner);
            }    

            if (!await _unitOfWork.PostCommentRepository.Delete(id))
            {
                return new ErrorResponse(404, Messages.NotFounb("Comment"));
            }

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public async Task<IResponse> GetAll()
        {
            var entity = await _unitOfWork.PostCommentRepository.GetAll();
            return new DataResponse(_mapper.Map<List<GetPostCommentReponse>>(entity), 200);
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

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(comment), 200);

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

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(comment), 204, Messages.UpdatedSuccessfully);

        }

        private async Task<bool> CheckAccessPost(string requestUserId, string targetUserId)
        {
            var requestUser = await _unitOfWork.UserRepository.FindById(targetUserId);
            var targetUser = await _unitOfWork.UserRepository.FindById(requestUserId);

            if (requestUser == null || targetUser == null) return false;

            if (requestUserId == targetUserId)
            {
                return true;
            }

            // Is admin
            if (await _userManager.IsInRoleAsync(targetUser, RoleName.Administrator))
            {
                return true;
            }

            // Is friend
            return await _unitOfWork.FriendshipRepository.IsFriend(requestUserId, targetUserId);
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
            if (await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator))
            {
                return true;
            }

            return false;
        }


        #endregion

        #region Comment Reaction

        public async Task<IResponse> GetReactions(string requestUserId, Guid commentId)
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

            var result = await _unitOfWork.CommentReactionRepository.GetByComment(commentId);

            return new DataResponse(_mapper.Map<List<GetCommentReactionResponse>>(result), 200);
        }

        public async Task<IResponse> GetReactionById(Guid commentId, string userId, int reactionId)
        {
            var entity = await _unitOfWork.CommentReactionRepository.GetById(commentId, userId, reactionId);
            
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            return new DataResponse(_mapper.Map<GetCommentReactionResponse>(entity), 200);

        }

        public async Task<IResponse> CreateReaction(Guid commentId, string userId, CreateCommentReactionRequest request)
        {
            if (await CheckExitCommentReaction(commentId, userId))
            {
                return new ErrorResponse(400, Messages.CommentReactionExist);
            }    

            var addEntity = _mapper.Map<CommentReaction>(request);
            addEntity.CommentId = commentId;
            addEntity.UserId = userId;

            await _unitOfWork.CommentReactionRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var addedEntity = await _unitOfWork.CommentReactionRepository.GetById(commentId, userId, addEntity.ReactionId);

            return new DataResponse(_mapper.Map<GetCommentReactionResponse>(addedEntity), 204, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> UpdateReaction(Guid commentId, string userId, CreateCommentReactionRequest request)
        {
            var checkExits = await _unitOfWork.CommentReactionRepository.GetById(commentId, userId, request.ReactionId);
            if (checkExits == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            var updateEntity = _mapper.Map<CommentReaction>(request);
            updateEntity.CommentId = commentId;
            updateEntity.UserId = userId;

            await _unitOfWork.CommentReactionRepository.Update(updateEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var updatedEntity = await _unitOfWork.CommentReactionRepository.GetById(commentId, userId, updateEntity.ReactionId);

            return new DataResponse(_mapper.Map<GetCommentReactionResponse>(updatedEntity), 204, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> DeleteReaction(Guid commentId, string userId, int reactionId)
        {
            var entity = await _unitOfWork.CommentReactionRepository.GetById(commentId, userId, reactionId);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            await _unitOfWork.CommentReactionRepository.Delete(commentId, userId, entity.ReactionId);
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
