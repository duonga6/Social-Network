using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Utilities;

namespace SocialNetwork.API.Controllers
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
