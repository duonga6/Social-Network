using MediatR;
using SocialNetwork.Application.Interfaces;

namespace SocialNetwork.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.Info($"Begin handling {typeof(TRequest).Name}");
            var response = await next(cancellationToken);
            _logger.Info($"Finished handling {typeof(TRequest).Name}");
            return response;
        }
    }
}
