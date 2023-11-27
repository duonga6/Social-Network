using AutoMapper;
using SocialNetwork.Business.Constants;
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

        public async Task<IResponse> Create(CreatePostCommentRequest request)
        {
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

            return new SuccessResponse(Messages.UpdatedSuccessfully, 204);

        }
    }
}
