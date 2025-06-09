using AutoMapper;
using MediatR;
using SocialNetwork.Application.Constants;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Utilities;
using SocialNetwork.Application.Wrappers.Responses;

namespace SocialNetwork.Application.Features.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, IResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IUnitOfWork unitOfWork, ILogger<LoginCommandHandler> logger, ITokenService tokenService, IMapper mapper)
        {
            _uow = unitOfWork;
            _logger = logger;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetAsync(u => u.EmailAddress.Equals(request.Email), true);
            if (user == null)
            {
                _logger.Error($"Not found user {request.Email}.");
                return new ErrorResponse(ResponseMessages.IncorrectEorP);
            }

            if (!user.IsConfirmedEmail)
            {
                _logger.Error($"User {request.Email} is not confirmed.");
                return new ErrorResponse(ResponseMessages.EmailNotConfirmed);
            }

            if (!PasswordUtils.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                _logger.Error($"Verfy passwored failed.");
                return new ErrorResponse(ResponseMessages.IncorrectEorP);
            }

            var roleNames = new List<string>();
            var roles = await _uow.RoleRepository.GetAllAsync(r => r.UserRoles.Any(ur => ur.UserId.Equals(user.Id)));
            foreach (var role in roles)
            {
                roleNames.Add(role.RoleName);
            }

            var token = _tokenService.CreateToken(user, roleNames);
            var result = _mapper.Map<UserWithTokenDTO>(user);
            result.Token = token;

            _logger.Info($"Login complete for {request.Email}.");
            return new DataResponse<UserWithTokenDTO>(result);
        }
    }
}
