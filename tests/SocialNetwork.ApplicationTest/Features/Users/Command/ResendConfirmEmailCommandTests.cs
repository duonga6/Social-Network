using Moq;
using SocialNetwork.Application.Features.Users.Commands;
using SocialNetwork.Application.Wrappers.Responses;
using SocialNetwork.Domain.Entities;
using System.Linq.Expressions;
using Xunit.Abstractions;

namespace SocialNetwork.ApplicationTest.Features.Users.Command
{
    public class ResendConfirmEmailCommandTests : FeatureTestBase<ResendConfirmEmailHandler>
    {
        public ResendConfirmEmailCommandTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task ResendConfirmEmail_ReturnSuccess()
        {
            var command = new ResendConfirmEmailComamnd()
            {
                Email = "test@gmail.com"
            };

            var fakeUser = new User
            {
                EmailAddress = "test@gmail.com",
                ConfirmCodeCreateDate = DateTimeOffset.Now.AddDays(-1)
            };

            userRepoMock.Setup(u => u.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), false)).ReturnsAsync(fakeUser);

            var handler = new ResendConfirmEmailHandler(uowMock.Object, loggerMock.Object, emailServiceMock.Object);
            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<SuccessResponse>(result);
        }

        [Fact]
        public async Task ResendConfirmEmail_UserNotExist_ReturnFailed()
        {
            var command = new ResendConfirmEmailComamnd()
            {
                Email = "test@gmail.com"
            };

            userRepoMock.Setup(u => u.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), false)).ReturnsAsync((User)null);

            var handler = new ResendConfirmEmailHandler(uowMock.Object, loggerMock.Object, emailServiceMock.Object);
            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<ErrorResponse>(result);
        }

        [Fact]
        public async Task ResendConfirmEmail_UserAlreadyConfirmed_ReturnFailed()
        {
            var command = new ResendConfirmEmailComamnd()
            {
                Email = "test@gmail.com"
            };

            var fakeUser = new User
            {
                EmailAddress = "test@gmail.com",
                IsConfirmedEmail = true,
            };

            userRepoMock.Setup(u => u.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), false)).ReturnsAsync(fakeUser);

            var handler = new ResendConfirmEmailHandler(uowMock.Object, loggerMock.Object, emailServiceMock.Object);
            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<ErrorResponse>(result);
        }

        [Fact]
        public async Task ResendEmailConfirm_TimeResendNotEnough_ReturnFailedAsync()
        {
            var command = new ResendConfirmEmailComamnd()
            {
                Email = "test@gmail.com"
            };

            var fakeUser = new User
            {
                EmailAddress = "test@gmail.com",
                ConfirmCodeCreateDate = DateTimeOffset.Now.AddMinutes(-5)
            };

            userRepoMock.Setup(u => u.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), false)).ReturnsAsync(fakeUser);

            var handler = new ResendConfirmEmailHandler(uowMock.Object, loggerMock.Object, emailServiceMock.Object);
            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<ErrorResponse>(result);
        }
    }
}
