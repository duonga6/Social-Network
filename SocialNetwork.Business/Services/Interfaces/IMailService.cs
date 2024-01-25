using SocialNetwork.Business.DTOs.Utilities.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IMailService
    {
        Task<IResponse> SendMailAsync(SendMailRequest request);
    }
}
