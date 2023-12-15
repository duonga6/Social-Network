using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.DTOs.CommentReaction.Responses;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.PostComment.Responses;
using SocialNetwork.Business.DTOs.PostImage.Responses;
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

            CreateMap<IdentityRole, GetRoleResponse>();

            CreateMap<PostImage, GetPostImageResponse>();

            CreateMap<Post, GetPostResponse>()
                .ForMember(d => d.Images, o => o.MapFrom(s => s.Images));

            CreateMap<PostComment, GetPostCommentReponse>();

            CreateMap<PostReaction, GetPostReactionResponse>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Reaction.Name));

            CreateMap<CommentReaction, GetCommentReactionResponse>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Reaction.Name));

            CreateMap<Friendship, GetFriendshipResponse>();

            CreateMap<MessageService, GetMessageResponse>();

            CreateMap<NotificationService, GetNotificationResponse>();

        }
    }
}
