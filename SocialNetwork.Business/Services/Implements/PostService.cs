using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.Business.Services.Implements
{
    public class PostService : BaseServices, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
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

        public async Task<IResponse> Delete(Guid id)
        {
            if (!await _unitOfWork.PostRepository.Delete(id))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }    

            var resut = await _unitOfWork.CompleteAsync();

            if (!resut)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public async Task<IResponse> GetAll()
        {
            var entity = await _unitOfWork.PostRepository.GetAll();
            return new DataResponse(_mapper.Map<List<GetPostResponse>>(entity), 200);
        }

        public async Task<IResponse> GetById(Guid id)
        {
            var entity = await _unitOfWork.PostRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            return new DataResponse(_mapper.Map<GetPostResponse>(entity), 200);
        }

        public async Task<IResponse> Update(Guid id, UpdatePostRequest request)
        {

            var entityUpdate = _mapper.Map<Post>(request);
            entityUpdate.Id = id;

            if (!await _unitOfWork.PostRepository.Update(entityUpdate))
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
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
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse(_mapper.Map<GetPostResponse>(entityUpdate), 204, Messages.UpdatedSuccessfully);

        }
    }
}
