using MediatR;
using SocialNetwork.Application.Wrappers.Responses;

namespace SocialNetwork.Application.Features.Users.Commands.Login
{
    public class LoginCommand : IRequest<IResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
