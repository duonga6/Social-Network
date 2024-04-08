namespace SocialNetwork.Business.DTOs.Responses
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
