using AutoMapper;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.Business.Mapper
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain() 
        {
            CreateMap<CreateReactionRequest, Reaction>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateReactionRequest, Reaction>()
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<RegistrationRequest, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.AvatarUrl, o => o.MapFrom(s => DefaultImage.DefaultUserAvatar));
                

            CreateMap<CreatePostRequest, Post>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostMediaRequest, PostMedia>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateSharePostRequest, Post>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateSharePostRequest, Post>()
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostMediaRequest, PostMedia>()
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostRequest, Post>()
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostReactionRequest, PostReaction>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostCommentRequest, PostComment>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostCommentRequest, PostComment>()
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateCommentReactionRequest, CommentReaction>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateUserInfoRequest, User>()
                .ForMember(d  => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostReactionsRequest, PostReaction>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateCommentReactionRequests, CommentReaction>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateGroupRequest, Group>()
                .ForMember(d => d.CreatedDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateGroupRequest, Group>()
                .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => DateTime.UtcNow));
        }
    }
}
