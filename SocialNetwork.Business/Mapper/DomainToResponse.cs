using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.DTOs.CommentReaction.Responses;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.DTOs.MediaType.Responses;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.PostComment.Responses;
using SocialNetwork.Business.DTOs.PostMedia.Responses;
using SocialNetwork.Business.DTOs.PostReaction.Responses;
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
            CreateMap<User, UserWithTokenResponse>();

            CreateMap<IdentityRole, GetRoleResponse>();

            CreateMap<PostMedia, GetPostMediaResponse>();

            CreateMap<Post, GetPostResponse>()
                .ForMember(d => d.PostMedias, o => o.MapFrom(s => s.PostMedias))
                .ForPath(d => d.Author.Id, o => o.MapFrom(s => s.Author.Id))
                .ForPath(d => d.Author.FullName, o => o.MapFrom(s => s.Author.GetFullName()))
                .ForPath(d => d.Author.AvatarUrl, o => o.MapFrom(s => s.Author.AvatarUrl));

            CreateMap<PostComment, GetPostCommentResponse>()
                .ForPath(d => d.User.Id, o => o.MapFrom(s => s.User.Id))
                .ForPath(d => d.User.FullName, o => o.MapFrom(s => s.User.GetFullName()))
                .ForPath(d => d.User.AvatarUrl, o => o.MapFrom(s => s.User.AvatarUrl));

            CreateMap<PostReaction, GetPostReactionResponse>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Reaction.Name))
                .ForPath(d => d.User.Id, o => o.MapFrom(s => s.User.Id))
                .ForPath(d => d.User.FullName, o => o.MapFrom(s => s.User.GetFullName()))
                .ForPath(d => d.User.AvatarUrl, o => o.MapFrom(s => s.User.AvatarUrl));

            CreateMap<CommentReaction, GetCommentReactionResponse>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Reaction.Name))
                .ForPath(d => d.User.Id, o => o.MapFrom(s => s.User.Id))
                .ForPath(d => d.User.FullName, o => o.MapFrom(s => s.User.GetFullName()))
                .ForPath(d => d.User.AvatarUrl, o => o.MapFrom(s => s.User.AvatarUrl));

            CreateMap<Friendship, GetFriendshipResponse>()
                .ForPath(x => x.RequestUser.Id, o => o.MapFrom(s => s.RequestUser.Id))
                .ForPath(x => x.RequestUser.FullName, o => o.MapFrom(s => s.RequestUser.GetFullName()))
                .ForPath(x => x.RequestUser.AvatarUrl, o => o.MapFrom(s => s.RequestUser.AvatarUrl))
                .ForPath(x => x.TargetUser.Id, o => o.MapFrom(s => s.TargetUser.Id))
                .ForPath(x => x.TargetUser.FullName, o => o.MapFrom(s => s.TargetUser.GetFullName()))
                .ForPath(x => x.TargetUser.AvatarUrl, o => o.MapFrom(s => s.TargetUser.AvatarUrl));

            CreateMap<Message, GetMessageResponse>()
                .ForPath(x => x.Sender.Id, o => o.MapFrom(s => s.Sender.Id))
                .ForPath(x => x.Sender.FullName, o => o.MapFrom(s => s.Sender.GetFullName()))
                .ForPath(x => x.Sender.AvatarUrl, o => o.MapFrom(s => s.Sender.AvatarUrl))
                .ForPath(x => x.Receiver.Id, o => o.MapFrom(s => s.Receiver.Id))
                .ForPath(x => x.Receiver.FullName, o => o.MapFrom(s => s.Receiver.GetFullName()))
                .ForPath(x => x.Receiver.AvatarUrl, o => o.MapFrom(s => s.Receiver.AvatarUrl));

            CreateMap<Notification, GetNotificationResponse>()
                .ForPath(x => x.FromUser.Id, o => o.MapFrom(s => s.FromUser.Id))
                .ForPath(x => x.FromUser.AvatarUrl, o => o.MapFrom(s => s.FromUser.AvatarUrl));

            CreateMap<MediaType, GetMediaTypeResponse>();

        }
    }
}
