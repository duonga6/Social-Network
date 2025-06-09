using AutoMapper;
using MediatR;
using SocialNetwork.Application.Constants;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Utilities;
using SocialNetwork.Application.Wrappers.Responses;

namespace SocialNetwork.Application.Features.Users.Commands
{
    public class RegisterCommand : IRequest<IResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Gender Gender { set; get; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<RegisterCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }


        public async Task<IResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if ((await _unitOfWork.UserRepository.GetAsync(u => u.EmailAddress.Equals(request.EmailAddress), true)) != null)
                {
                    _logger.Error($"Email {request.EmailAddress} already in used.");
                    return new ErrorResponse(ResponseMessages.EmailAddressAlreadyInUsed);
                }

                var (passwordHash, passwordSalt) = PasswordUtils.CreateHash(request.Password);

                var user = _mapper.Map<User>(request);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                var confirmCode = PasswordUtils.GenerateRandomString(20);
                user.ConfirmEmailCode = confirmCode;
                user.ConfirmCodeCreateDate = DateTimeOffset.Now;
                _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.SaveChangesAsync();
                _logger.Info("Create user {0} success.", request.EmailAddress);

                string confirmationUrl = "http://localhost:9090/api/user/confirmemail/" + confirmCode;
                await _emailService.ComfirmationEmailAsync(confirmationUrl);
                _logger.Info("Send email confirm for user {0} success.", request.EmailAddress);

                return new SuccessResponse();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while create user {request.EmailAddress}. ex: {ex}.");
                return new ErrorResponse(ResponseMessages.InternalServerError);
            }
        }
    }
}
