using AutoMapper;
using SocialNetwork.Business.DTOs.Reaction.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.Business.Mapper
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain() 
        {
            CreateMap<CreateReactionRequest, Reaction>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateReactionRequest, Reaction>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<RegistrationRequest, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));
        }
    }
}
