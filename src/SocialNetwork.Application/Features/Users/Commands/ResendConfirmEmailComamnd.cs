using MediatR;
using SocialNetwork.Application.Constants;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Application.Utilities;
using SocialNetwork.Application.Wrappers.Responses;

namespace SocialNetwork.Application.Features.Users.Commands
{
    public class ResendConfirmEmailComamnd : IRequest<IResponse>
    {
        public string Email { get; set; }
    }

    public class ResendConfirmEmailHandler : IRequestHandler<ResendConfirmEmailComamnd, IResponse>
    {
        private readonly ILogger<ResendConfirmEmailHandler> _logger;
        private readonly IUnitOfWork _uow;
        private readonly IEmailService _emailService;

        public ResendConfirmEmailHandler(IUnitOfWork uow, ILogger<ResendConfirmEmailHandler> logger, IEmailService emailService)
        {
            _uow = uow;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IResponse> Handle(ResendConfirmEmailComamnd request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _uow.UserRepository.GetAsync(u => u.EmailAddress.Equals(request.Email));
                if (user == null)
                {
                    _logger.Error($"Cannot find user {request.Email}.");
                    return new ErrorResponse(ResponseMessages.ObjectNotFound);
                }

                if (user.IsConfirmedEmail)
                {
                    _logger.Error($"{request.Email} is already confirmed email.");
                    return new ErrorResponse(ResponseMessages.EmailAddressAlreadyInUsed);
                }

                if ((DateTimeOffset.Now - user.ConfirmCodeCreateDate).TotalMinutes < 15)
                {
                    _logger.Error($"{request.Email} only can can resend email confirm after {15 - (DateTimeOffset.Now - user.ConfirmCodeCreateDate).TotalMinutes} mininutes.");
                    return new ErrorResponse(ResponseMessages.EmailConfirmOnlyCanSendAfter(15 * 60 * 1000));
                }

                var confirmCode = PasswordUtils.GenerateRandomString(20);
                user.ConfirmEmailCode = confirmCode;
                user.ConfirmCodeCreateDate = DateTimeOffset.Now;
                await _uow.SaveChangesAsync();
                _logger.Info($"Create confirm code for {request.Email} success.");

                string confirmationUrl = "http://localhost:9090/api/user/confirmemail/" + confirmCode;
                await _emailService.ComfirmationEmailAsync(confirmationUrl);
                _logger.Info($"Resend confirm email for {request.Email} success.");

                return new SuccessResponse();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while resend email confirm for {request.Email}. ex: {ex}.");
                return new ErrorResponse(ResponseMessages.InternalServerError);
            }
        }
    }
}
