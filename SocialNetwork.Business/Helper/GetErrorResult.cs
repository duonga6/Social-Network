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

        public static List<string> GetErrors(this SignInResult signInResult)
        {
            var errors = new List<string>();

            if (signInResult.IsNotAllowed)
            {
                errors.Add("Email not confirmed");
            }
            else if (signInResult.IsLockedOut)
            {
                errors.Add("LockedOut");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                errors.Add("Require two factor");
            }
            else
            {
                errors.Add("Username or password invalid");
            }    

            return errors;
        }
    }
}
