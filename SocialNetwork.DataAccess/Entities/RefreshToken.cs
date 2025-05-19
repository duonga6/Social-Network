namespace SocialNetwork.DataAccess.Entities
{
    public class RefreshToken : EntityTrackingBase<Guid>
    {
        public string UserId { get; set; }
        public string Token { set; get; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime ExpiredAt { get; set; }

        public virtual User User { get; set; }
    }
}
