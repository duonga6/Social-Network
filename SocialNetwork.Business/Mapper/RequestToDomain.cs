using AutoMapper;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.CommentReactions.Requests;
using SocialNetwork.Business.DTOs.Groups.Request;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.DTOs.PostMedia.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
using SocialNetwork.Business.DTOs.Posts.Requests;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Users.Requests;
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
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.AvatarUrl, o => o.MapFrom(s => AvatarUrl.Default));
                

            CreateMap<CreatePostRequest, Post>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostMediaRequest, PostMedia>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateSharePostRequest, Post>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateSharePostRequest, Post>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostMediaRequest, PostMedia>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostRequest, Post>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostReactionRequest, PostReaction>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostCommentRequest, PostComment>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostCommentRequest, PostComment>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateCommentReactionRequest, CommentReaction>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateUserInfoRequest, User>()
                .ForMember(d  => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<SendMessageRequest, Message>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostReactionsRequest, PostReaction>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateCommentReactionRequests, CommentReaction>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateGroupRequest, Group>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateGroupRequest, Group>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));
        }
    }
}
