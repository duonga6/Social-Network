using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.API.Controllers.Base
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected string UserId
        {
            get { return User.GetUserId(); }
        }

        protected ObjectResult ResponseModel(IResponse response)
        {
            var result = new ObjectResult(response);
            result.StatusCode = response.Status;
            result.ContentTypes.Add("application/json");

            return result;
        }
    }
}
