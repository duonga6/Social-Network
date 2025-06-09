namespace SocialNetwork.Application.Interfaces
{
    public interface ILogger
    {
        void Info(string stringFormat, params object[] parameters);
        void Warn(string stringFormat, params object[] parameters);
        void Debug(string stringFormat, params object[] parameters);
        void Error(string stringFormat, params object[] parameters);
    }

    public interface ILogger<T> : ILogger where T : class
    {

    }
}
