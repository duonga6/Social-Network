using Moq;
using SocialNetwork.Application.Features.Users.Commands;
using SocialNetwork.Application.Utilities;
using SocialNetwork.Application.Wrappers.Responses;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Enums;
using System.Linq.Expressions;
using Xunit.Abstractions;

namespace SocialNetwork.ApplicationTest.Features.Users.Command
{
    public class RegisterCommandTests : FeatureTestBase<RegisterCommandHandler>
    {
        public RegisterCommandTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task RegisterCommand_ReturnSuccess()
        {
            var command = new RegisterCommand()
            {
                FirstName = "Phạm",
                LastName = "Dương",
                DateOfBirth = new DateTimeOffset(new DateTime(2002, 01, 24)),
                EmailAddress = "shenmurai1st@gmail.com",
                Gender = Gender.Male,
                Password = "demo12!@"
            };

            var fakeUser = new User
            {
                FirstName = "Phạm",
                LastName = "Dương",
                DateOfBirth = new DateTimeOffset(new DateTime(2002, 01, 24)),
                EmailAddress = "shenmurai1st@gmail.com",
                Gender = Gender.Male,
                PasswordHash = PasswordUtils.CreateHash("demo12!@").passwordHash,
                PasswordSalt = PasswordUtils.CreateHash("demo12!@").passwordSalt,
            };

            userRepoMock.Setup(r => r.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), true)).ReturnsAsync((User)null);
            mapperMock.Setup(m => m.Map<User>(It.IsAny<RegisterCommand>())).Returns(fakeUser);
            emailServiceMock.Setup(e => e.ComfirmationEmailAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

            var handler = new RegisterCommandHandler(uowMock.Object, mapperMock.Object, emailServiceMock.Object, loggerMock.Object);
            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<SuccessResponse>(result);
        }

        [Fact]
        public async Task RegisterCommand_EmailIsInUsed_ReturnError()
        {
            var command = new RegisterCommand()
            {
                FirstName = "Phạm",
                LastName = "Dương",
                DateOfBirth = new DateTimeOffset(new DateTime(2002, 01, 24)),
                EmailAddress = "shenmurai1st@gmail.com",
                Gender = Gender.Male,
                Password = "demo12!@"
            };

            var fakeUser = new User
            {
                FirstName = "Phạm",
                LastName = "Dương",
                DateOfBirth = new DateTimeOffset(new DateTime(2002, 01, 24)),
                EmailAddress = "shenmurai1st@gmail.com",
                Gender = Gender.Male,
                PasswordHash = PasswordUtils.CreateHash("demo12!@").passwordHash,
                PasswordSalt = PasswordUtils.CreateHash("demo12!@").passwordSalt,
            };

            userRepoMock.Setup(r => r.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), true)).ReturnsAsync(fakeUser);
            uowMock.Setup(u => u.UserRepository).Returns(userRepoMock.Object);
            mapperMock.Setup(m => m.Map<User>(It.IsAny<RegisterCommand>())).Returns(fakeUser);
            emailServiceMock.Setup(e => e.ComfirmationEmailAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

            var handler = new RegisterCommandHandler(uowMock.Object, mapperMock.Object, emailServiceMock.Object, loggerMock.Object);
            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<ErrorResponse>(result);
        }
    }
}
