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
                errors.Add("Email chưa được xác thực");
            }
            else if (signInResult.IsLockedOut)
            {
                errors.Add("Tài khoản đã bị khóa");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                errors.Add("Yêu cầu xác thực 2 lớp");
            }
            else
            {
                errors.Add("Email hoặc mật khẩu không chính xác");
            }    

            return errors;
        }
    }
}
