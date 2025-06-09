using Moq;
using SocialNetwork.Application.Features.Users.Commands.Login;
using SocialNetwork.Application.Utilities;
using SocialNetwork.Domain.Entities;
using System.Linq.Expressions;
using Xunit.Abstractions;

namespace SocialNetwork.ApplicationTest.Features.Users.Command
{
    public class LoginCommandTests : FeatureTestBase<LoginCommandHandler>
    {
        public LoginCommandTests(ITestOutputHelper output) : base(output)
        {
        }

        public void Login_ValidEmailAndPassword_ReturnSuccess()
        {
            var command = new LoginCommand()
            {
                Email = "test@gmail.com",
                Password = "demo12!@",
            };

            var (passwordHash, passwordSalt) = PasswordUtils.CreateHash(command.Password);
            var fakeUser = new User
            {
                EmailAddress = "test@gmail.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsConfirmedEmail = true,
            };

            userRepoMock.Setup(u => u.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<bool>())).ReturnsAsync(fakeUser);

            var handler = new LoginCommandHandler(uowMock.Object, loggerMock.Object, tokenService.Object, mapperMock.Object);

        }
    }
}
