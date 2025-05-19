using Microsoft.Extensions.Logging;

namespace SocialNetwork.Common
{
    public static class StaticLogger
    {
        private static ILoggerFactory _loggerFactory;

        public static void Initialize(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public static ILogger GetLogger(string categoryName)
        {
            if (_loggerFactory == null)
            {
                throw new InvalidOperationException("Logger factory has not been initialized");
            }

            return _loggerFactory.CreateLogger(categoryName);
        }

        public static ILogger GetLogger<T>()
        {
            return GetLogger(typeof(T).FullName!);
        }

        public static ILogger GetLogger(Type type)
        {
            return GetLogger(type.FullName!);
        }
    }
}
