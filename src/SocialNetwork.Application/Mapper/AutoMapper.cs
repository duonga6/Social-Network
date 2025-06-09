using AutoMapper;
using SocialNetwork.Application.Features.Users.Commands;

namespace SocialNetwork.Application.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
        }
    }
}
