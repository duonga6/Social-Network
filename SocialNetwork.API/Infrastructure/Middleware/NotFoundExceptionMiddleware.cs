using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SocialNetwork.Business.Wrapper;
using System.Net;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Constants;

namespace SocialNetwork.API.Infrastructure.Middleware
{
    public class NotFoundExceptionMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger<NotFoundExceptionMiddleware> _logger;

        public NotFoundExceptionMiddleware(ILogger<NotFoundExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                if (e is NotFoundException) await HandleExceptionAsync(httpContext, e);
                else await _next(httpContext);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

            string message = Messages.NotFound(e.Message);

            //_logger.LogError(e.ToString());

            var error = JsonConvert.SerializeObject(new ErrorResponse(httpContext.Response.StatusCode, message), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return httpContext.Response.WriteAsync(error);
        }
    }
}
