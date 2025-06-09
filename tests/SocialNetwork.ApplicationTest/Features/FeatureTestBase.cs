using AutoMapper;
using Moq;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using Xunit.Abstractions;

namespace SocialNetwork.ApplicationTest.Features
{
    public abstract class FeatureTestBase<T> where T : class
    {
        private readonly ITestOutputHelper _output;
        protected Mock<ILogger<T>> loggerMock;
        protected Mock<IUnitOfWork> uowMock = new Mock<IUnitOfWork>();
        protected Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();
        protected Mock<IMapper> mapperMock = new Mock<IMapper>();
        protected Mock<IEmailService> emailServiceMock = new Mock<IEmailService>();
        protected Mock<ITokenService> tokenService = new Mock<ITokenService>();

        public FeatureTestBase(ITestOutputHelper output)
        {
            #region Logger
            this._output = output;
            loggerMock = new Mock<ILogger<T>>();
            loggerMock
                .Setup(l => l.Info(It.IsAny<string>(), It.IsAny<object[]>()))
                .Callback<string, object[]>((message, param) =>
                {
                    _output.WriteLine("INFO " + string.Format(message, param));
                });

            loggerMock
                .Setup(l => l.Error(It.IsAny<string>(), It.IsAny<object[]>()))
                .Callback<string, object[]>((message, param) =>
                {
                    _output.WriteLine("ERROR " + string.Format(message, param));
                });

            loggerMock
                .Setup(l => l.Warn(It.IsAny<string>(), It.IsAny<object[]>()))
                .Callback<string, object[]>((message, param) =>
                {
                    _output.WriteLine("WARN " + string.Format(message, param));
                });

            loggerMock
                .Setup(l => l.Debug(It.IsAny<string>(), It.IsAny<object[]>()))
                .Callback<string, object[]>((message, param) =>
                {
                    _output.WriteLine("DEBUG " + string.Format(message, param));
                });
            #endregion

            #region UOW
            uowMock.Setup(u => u.UserRepository).Returns(userRepoMock.Object);
            #endregion
        }
    }
}
