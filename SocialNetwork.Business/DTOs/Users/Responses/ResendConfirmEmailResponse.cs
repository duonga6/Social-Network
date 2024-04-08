namespace SocialNetwork.Business.DTOs.Responses
{
    public class ResendConfirmEmailResponse
    {
        public string Code { get; set; }

        public ResendConfirmEmailResponse(string code)
        {
            this.Code = code;
        }
        
    }
}
