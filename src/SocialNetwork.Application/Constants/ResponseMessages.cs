namespace SocialNetwork.Application.Constants
{
    public static class ResponseMessages
    {
        #region Users
        public static string EmailAddressAlreadyInUsed => "Email address already in used.";
        public static string EmailAlreadyComfirmed => "Email address already confirmed.";
        public static string EmailConfirmOnlyCanSendAfter(long miliseconds) => $"Email confirm only can send after {miliseconds}";
        public static string IncorrectEorP => "Email or password is not correct.";
        public static string EmailNotConfirmed => "Email is not confirmed.";
        #endregion

        #region Common
        public static string InternalServerError => "";
        #endregion

        #region CRUD
        public static string ObjectNotFound => "Object not found.";
        #endregion
    }
}
