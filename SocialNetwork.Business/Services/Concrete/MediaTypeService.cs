using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.Business.Services.Concrete
{
    public class MediaTypeService : BaseServices<MediaTypeService>, IMediaTypeService
    { 
        public MediaTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MediaTypeService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> GetAll()
        {
            var mediaTypes = await _unitOfWork.MediaTypeRepository.GetAll();

            var response = _mapper.Map<List<GetMediaTypeResponse>>(mediaTypes);
            return new DataResponse<List<GetMediaTypeResponse>>(response, 200);
        }

        public async Task<IResponse> GetById(int id)
        {
            var mediaType = await _unitOfWork.MediaTypeRepository.GetById(id);

            if (mediaType == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            var response = _mapper.Map<GetMediaTypeResponse>(mediaType);

            return new DataResponse<GetMediaTypeResponse>(response, 200);
        }
    }
}
