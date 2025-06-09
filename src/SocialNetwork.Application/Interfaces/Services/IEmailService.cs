namespace SocialNetwork.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task ComfirmationEmailAsync(string url);
    }
}
