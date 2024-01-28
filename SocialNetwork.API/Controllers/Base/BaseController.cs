using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;

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
    }
}
