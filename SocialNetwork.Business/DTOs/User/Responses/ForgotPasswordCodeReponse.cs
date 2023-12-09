namespace SocialNetwork.Business.DTOs.User.Responses
{
    public class ForgotPasswordCodeReponse
    {
        public string Code { set; get; }

        public ForgotPasswordCodeReponse() 
        {
            Code = string.Empty;
        }

        public ForgotPasswordCodeReponse(string code)
        {
            Code = code;
        }
    }
}
