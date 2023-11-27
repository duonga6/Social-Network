using System.Security.Claims;

namespace SocialNetwork.API.Utilities
{
    public static class Utilities
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirst("userid")?.Value ?? "";
        }
    }
}
