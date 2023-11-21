using AutoMapper;
using SocialNetwork.Business.DTOs.Reaction.Requests;
using SocialNetwork.Business.DTOs.Reaction.Response;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.Business.Services.Implements
{
    public class ReactionService : BaseServices, IReactionService
    {
        public ReactionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResponse> Add(CreateReactionRequest entity)
        {
            var checkEntity = await _unitOfWork.ReactionRepository.FindBy(x => x.Name == entity.Name && x.Code == entity.Code);
            if (checkEntity.Count > 0)
                return new ErrorResponse(400, "Name and Code are already exist");

            var addEntity = _mapper.Map<Reaction>(entity);

            await _unitOfWork.ReactionRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();
            
            if (!result)
                return new ErrorResponse(400, "Error adding");

            var reusltEntity = _mapper.Map<GetReactionReponse>(addEntity);
            return new DataResponse(reusltEntity, 201);
        }

        public async Task<IResponse> Delete(Guid id)
        {
            var entity = await _unitOfWork.ReactionRepository.GetById(id);
            if (entity == null)
                return new ErrorResponse(404, "Not found");

            await _unitOfWork.ReactionRepository.Delete(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new ErrorResponse(400, "Error deleting");

            return new SuccessResponse("Delete successfully", 204);
        }

        public async Task<IResponse> GetAll()
        {
            var entity = await _unitOfWork.ReactionRepository.GetAll();
            var reusltEntity = _mapper.Map<List<GetReactionReponse>>(entity);
            return new DataResponse(reusltEntity, 200);
        }

        public async Task<IResponse> GetById(Guid id)
        {
            var entity = await _unitOfWork.ReactionRepository.GetById(id);
            if (entity == null)
                return new ErrorResponse(404, "Not found");

            var reusltEntity = _mapper.Map<GetReactionReponse>(entity);

            return new DataResponse(reusltEntity, 200);
        }

        public async Task<IResponse> Update(UpdateReactionRequest entity)
        {
            var findEntity = await _unitOfWork.ReactionRepository.GetById(entity.Id);
            if (findEntity == null)
                return new ErrorResponse(404, "Not found");

            if (entity.Name == findEntity.Name && entity.Code == findEntity.Code)
            {
                return new ErrorResponse(400, "Name and Code are already exist");
            }    

            var updateEntity = _mapper.Map<Reaction>(entity);

            await _unitOfWork.ReactionRepository.Update(updateEntity);
            var result = await _unitOfWork.CompleteAsync();
            
            if (!result)
                return new ErrorResponse(400, "Error updating");

            var resultEntity = _mapper.Map<GetReactionReponse>(updateEntity);
            return new DataResponse(resultEntity, 200);
            
        }
    }
}
