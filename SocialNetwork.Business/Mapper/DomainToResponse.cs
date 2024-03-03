using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.DTOs.MediaType.Responses;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.PostMedia.Responses;
using SocialNetwork.Business.DTOs.Role.Responses;
using SocialNetwork.Business.DTOs.Users.Responses;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.Business.DTOs.Response;
using SocialNetwork.Business.DTOs.PostReactions.Responses;

namespace SocialNetwork.Business.Mapper
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse() 
        {
            CreateMap<Reaction, GetReactionResponse>();

            CreateMap<User, GetUserResponse>();
            CreateMap<User, BasicUserResponse>();

            CreateMap<User, UserWithTokenResponse>();

            CreateMap<IdentityRole, GetRoleResponse>();

            CreateMap<PostMedia, GetPostMediaResponse>();

            CreateMap<Post, GetPostResponse>()
                .ForMember(d => d.PostMedias, o => o.MapFrom(s => s.PostMedias));

            CreateMap<PostComment, GetPostCommentResponse>();

            CreateMap<CommentReaction, GetCommentReactionResponse>();


            CreateMap<Friendship, GetFriendshipResponse>()
                .ForPath(x => x.RequestUser.Id, o => o.MapFrom(s => s.RequestUser.Id))
                .ForPath(x => x.RequestUser.FullName, o => o.MapFrom(s => s.RequestUser.GetFullName()))
                .ForPath(x => x.RequestUser.AvatarUrl, o => o.MapFrom(s => s.RequestUser.AvatarUrl))
                .ForPath(x => x.TargetUser.Id, o => o.MapFrom(s => s.TargetUser.Id))
                .ForPath(x => x.TargetUser.FullName, o => o.MapFrom(s => s.TargetUser.GetFullName()))
                .ForPath(x => x.TargetUser.AvatarUrl, o => o.MapFrom(s => s.TargetUser.AvatarUrl));

            CreateMap<Message, GetMessageResponse>()
                .ForPath(x => x.Sender.Id, o => o.MapFrom(s => s.Sender.Id))
                .ForPath(x => x.Sender.AvatarUrl, o => o.MapFrom(s => s.Sender.AvatarUrl))
                .ForPath(x => x.Receiver.Id, o => o.MapFrom(s => s.Receiver.Id))
                .ForPath(x => x.Receiver.AvatarUrl, o => o.MapFrom(s => s.Receiver.AvatarUrl));

            CreateMap<Notification, GetNotificationResponse>()
                .ForPath(x => x.FromUser.Id, o => o.MapFrom(s => s.FromUser.Id))
                .ForPath(x => x.FromUser.AvatarUrl, o => o.MapFrom(s => s.FromUser.AvatarUrl));

            CreateMap<MediaType, GetMediaTypeResponse>();

            CreateMap<PostReaction, GetPostReactionResponse>();

        }
    }
}
