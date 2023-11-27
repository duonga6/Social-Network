using AutoMapper;
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

namespace SocialNetwork.Business.Services.Implements
{
    public class PostCommentService : BaseServices, IPostCommentService
    {
        public PostCommentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #region Comment
        public async Task<IResponse> Create(CreatePostCommentRequest request)
        {
            if (!await CheckExitsPost(request.PostId))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            if (!await CheckExitsUser(request.UserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var addComment = _mapper.Map<PostComment>(request);
            await _unitOfWork.PostCommentRepository.Add(addComment);

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(addComment), 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(Guid id)
        {
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

        public async Task<IResponse> GetById(Guid id)
        {
            var entity = await _unitOfWork.PostCommentRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(entity), 200);

        }

        public async Task<IResponse> Update(Guid id, UpdatePostCommentRequest request)
        {
            var updateEntity = _mapper.Map<PostComment>(request);
            updateEntity.Id = id;

            if (!await _unitOfWork.PostCommentRepository.Update(updateEntity))
            {
                return new ErrorResponse(404, Messages.NotFounb("Comment"));
            }

            var result = await _unitOfWork.CompleteAsync();
            
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse(_mapper.Map<GetPostCommentReponse>(updateEntity), 204, Messages.UpdatedSuccessfully);

        }
    
        private async Task<bool> CheckExitsUser(string userId)
        {
            var user = await _unitOfWork.UserRepository.FindById(userId);

            return user != null;
        }

        private async Task<bool> CheckExitsPost(Guid Id)
        {
            var post = await _unitOfWork.PostRepository.GetById(Id);

            return post != null;
        }

        #endregion

        #region Comment Reaction

        public async Task<IResponse> GetReactions(Guid commentId)
        {
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
