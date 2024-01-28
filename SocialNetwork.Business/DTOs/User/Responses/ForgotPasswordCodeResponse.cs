namespace SocialNetwork.Business.DTOs.User.Responses
{
    public class ForgotPasswordCodeResponse
    {
        public string Code { set; get; }

        public ForgotPasswordCodeResponse() 
        {
            Code = string.Empty;
        }

        public ForgotPasswordCodeResponse(string code)
        {
            Code = code;
        }
    }
}
