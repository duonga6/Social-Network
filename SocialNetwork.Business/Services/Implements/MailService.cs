using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Utilities.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Settings;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Implements
{
    public class MailService : IMailService
    {

        private readonly MailSettings _mailSettings;
        private readonly ILogger<MailService> _logger;

        public MailService(IOptions<MailSettings> mailSettings, ILogger<MailService> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task<IResponse> SendMailAsync(SendMailRequest request)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(request.ToEmail));
            message.Subject = request.Subject;

            var body = new BodyBuilder()
            {
                HtmlBody = request.HtmlBody,
            };

            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(message);
            }
            catch (Exception ex)
            {
                Directory.CreateDirectory("MailsErrorSave");
                var emailErrorPath = $"MailsErrorSave/{Guid.NewGuid()}.eml";
                await message.WriteToAsync(emailErrorPath);
                _logger.LogError($"Error send email to {request.ToEmail} {DateTime.UtcNow.ToString("HH:mm dd/MM/yyyy")}:\n{ex.Message}");

                return new ErrorResponse(501, Messages.STWrong);
            }

            smtp.Disconnect(true);
            _logger.LogInformation($"Sent email to {request.ToEmail}");
            return new SuccessResponse(Messages.EmailSent + $"to {request.ToEmail}", 200);
        }
    }
}
