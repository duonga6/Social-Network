using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.Business.Services.Concrete
{
    public class ReactionService : BaseServices<ReactionService>, IReactionService
    {
        public ReactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReactionService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> Add(CreateReactionRequest entity)
        {
            var checkExist = await _unitOfWork.ReactionRepository.FindByAsync(x => x.Name == entity.Name);
            if (checkExist.Count > 0)
            {
                return new ErrorResponse(400, Messages.ReactionExist);
            }    

            var addEntity = _mapper.Map<Reaction>(entity);

            await _unitOfWork.ReactionRepository.AddAsync(addEntity);
            var result = await _unitOfWork.CompleteAsync();
            
            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }
            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(addEntity), 201);
        }

        public async Task<IResponse> Delete(int id)
        {
            var entity = await _unitOfWork.ReactionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.ReactionRepository.DeleteAsync(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> GetAll()
        {
            var entity = await _unitOfWork.ReactionRepository.GetAllAsync();
            return new DataResponse<List<GetReactionResponse>>(_mapper.Map<List<GetReactionResponse>>(entity), 200);
        }

        public async Task<IResponse> GetById(int id)
        {
            var entity = await _unitOfWork.ReactionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(entity), 200);
        }

        public async Task<IResponse> Update(int Id, UpdateReactionRequest entity)
        {
            var findEntity = await _unitOfWork.ReactionRepository.GetByIdAsync(Id);
            if (findEntity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (entity.Name == findEntity.Name)
            {
                return new ErrorResponse(400, Messages.ReactionExist);
            }    

            var updateEntity = _mapper.Map<Reaction>(entity);
            updateEntity.Id = Id;

            await _unitOfWork.ReactionRepository.UpdateAsync(updateEntity);
            var result = await _unitOfWork.CompleteAsync();
            
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse<GetReactionResponse>(_mapper.Map<GetReactionResponse>(updateEntity), 200);
            
        }
    }
}
