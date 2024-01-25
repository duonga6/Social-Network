namespace SocialNetwork.Business.Settings
{
    public class MailSettings
    {
        public string Mail { set; get; } = string.Empty;
        public string DisplayName { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
        public string Host { set; get; } = string.Empty;
        public int Port { set; get; }
    }
}
