using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.PostImage.Responses;
using SocialNetwork.Business.DTOs.Reaction.Response;
using SocialNetwork.Business.DTOs.Role.Responses;
using SocialNetwork.Business.DTOs.User.Responses;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.Business.Mapper
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse() 
        {
            CreateMap<Reaction, GetReactionReponse>();

            CreateMap<User, GetUserResponse>();

            CreateMap<IdentityRole, GetRoleResponse>();

            CreateMap<PostImage, GetPostImageResponse>();

            CreateMap<Post, GetPostResponse>()
                .ForMember(d => d.Images, o => o.MapFrom(s => s.Images));

            CreateMap<PostComment, GetPostImageResponse>();
        }
    }
}
