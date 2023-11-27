using SocialNetwork.Business.DTOs.Reaction.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IReactionService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(Guid id);
        Task<IResponse> Add(CreateReactionRequest entity);
        Task<IResponse> Update(Guid Id, UpdateReactionRequest entity);
        Task<IResponse> Delete(Guid id);
    }
}
