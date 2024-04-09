using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialNetwork.Business.Wrapper;

namespace SocialNetwork.API.Infrastructure.Extensions
{
    public static class CustomValidationResponse
    {
        public static void AddCustomValidationResponse(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    List<string> validErrors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => GetErrorMessage(x)).ToList();
                    var result = new BadRequestObjectResult(new ErrorResponse(400, validErrors));
                    return result;
                };
            });
        }

        private static string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
            "The input was not valid." :
            error.ErrorMessage;
        }
    }


    //public class CustomValidationResponse : IAsyncActionFilter
    //{
    //    private string GetErrorMessage(ModelError error)
    //    {
    //        return string.IsNullOrEmpty(error.ErrorMessage) ?
    //        "The input was not valid." :
    //        error.ErrorMessage;
    //    }

    //    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            List<string> validError = new();
    //            foreach (var keyPairModelState in context.ModelState)
    //            {
    //                var errors = keyPairModelState.Value.Errors;

    //                if (errors != null && errors.Count > 0)
    //                {
    //                    for (int i = 0; i < errors.Count; i++)
    //                    {
    //                        validError.Add(GetErrorMessage(errors[i]));
    //                    }
    //                }

    //            }

    //            context.Result = new BadRequestObjectResult(new ErrorResponse(400, validError));
    //            return;
    //        }

    //        await next();
    //    }
    //}
}
