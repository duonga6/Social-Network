using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SocialNetwork.Business.Wrapper;
using System.Net;

namespace SocialNetwork.API.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            } catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";

            List<string> exceptions = new();

            if (e.InnerException != null)
            {
                exceptions.Add(e.InnerException.ToString());
                if (e.InnerException.Message != null)
                {
                    exceptions.Add(e.InnerException.Message);
                }
                else if (e.InnerException.InnerException?.Message != null)
                {
                    exceptions.Add(e.InnerException.InnerException.Message);
                } 
            } 
            else if (e.Message != null)
            {
                exceptions.Add(e.Message);
            }

            var errorLogDetails = new
            {
                Errors = exceptions,
            };

            _logger.LogError($"Unknown error occurred: {errorLogDetails}");
            var error = JsonConvert.SerializeObject(new ErrorResponse(httpContext.Response.StatusCode, message), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return httpContext.Response.WriteAsync(error);
        }
    }
}
