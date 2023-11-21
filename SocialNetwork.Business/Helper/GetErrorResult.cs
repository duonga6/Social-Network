using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Business.Helper
{
    public static class GetErrorResult
    {
        public static List<string> GetErrors(this IdentityResult identityResult)
        {
            var errors = new List<string>();

            foreach (var error in identityResult.Errors)
            {
                errors.Add(error.Description);
            }    

            return errors;
        }
    }
}
