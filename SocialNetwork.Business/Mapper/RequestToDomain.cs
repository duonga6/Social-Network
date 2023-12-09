using AutoMapper;
using SocialNetwork.Business.DTOs.CommentReaction.Requests;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.PostComment.Requests;
using SocialNetwork.Business.DTOs.PostImage.Requests;
using SocialNetwork.Business.DTOs.PostReaction.Requests;
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

            CreateMap<CreatePostRequest, Post>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreatePostImageRequest, PostImage>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostImageRequest, PostImage>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdatePostRequest, Post>()
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<CreateCommentRequest, PostComment>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => DateTime.UtcNow));

            CreateMap<UpdateCommentRequest, PostComment>()
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
        }
    }
}
