using AutoMapper;

namespace SocialNetwork.Business.Utilities
{
    public class UTCDateTimeResolver : IValueResolver<object, object, DateTime>
    {
        public DateTime Resolve(object source, object destination, DateTime destMember, ResolutionContext context)
        {
            return DateTime.SpecifyKind(destMember, DateTimeKind.Utc);
        }
    }
}
