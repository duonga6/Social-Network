using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IMediaTypeService
    {
        Task<IResponse> GetAll();
        Task<IResponse> GetById(int id);
    }
}
