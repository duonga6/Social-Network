using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.DataAccess.Entities;

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
                .ForMember(d => d.PostMedias, o => o.MapFrom(s => s.PostMedias))
                .ForMember(d => d.User, o => o.MapFrom(s => s.Author))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<PostComment, GetPostCommentResponse>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)))
                .ForMember(d => d.User, o => o.MapFrom(x => x.User))
                .ForMember(d => d.Path, o => o.MapFrom(x => x.Path.Split(new char[]  { ';' }).Select(x => x.ToLower()).ToArray()));

            CreateMap<CommentReaction, GetCommentReactionResponse>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<Friendship, GetFriendshipResponse>()
                .ForMember(d => d.FriendStatus, o => o.MapFrom(x => x.FriendshipTypeId))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.UpdatedAt, DateTimeKind.Utc)));

            CreateMap<Message, GetMessageResponse>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<Notification, GetNotificationResponse>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<MediaType, GetMediaTypeResponse>();

            CreateMap<PostReaction, GetPostReactionResponse>();

            CreateMap<PostReaction, UserReacted>();

            CreateMap<CommentReaction, UserReacted>();

            CreateMap<Group, GetGroupResponse>()
                .ForMember(d => d.User, o => o.MapFrom(x => x.CreatedBy))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<Group, GetGroupBasicResponse>();

            CreateMap<GroupMember, GetGroupMemberResponse>()
                .ForMember(d => d.JoinedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<GroupInvite, GetGroupInviteResponse>()
                .ForMember(d => d.CreatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.CreatedAt, DateTimeKind.Utc)));

            CreateMap<Conversation, GetConversationResponse>()
                .ForMember(d => d.LastMessage, o => o.MapFrom(x => x.Messages.FirstOrDefault()))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(x => DateTime.SpecifyKind(x.UpdatedAt, DateTimeKind.Utc)))
                .ForMember(d => d.Images, o => o.MapFrom(x => new List<string>() { x.Image }));

            CreateMap<ConversationParticipant, GetConversationParticipantResponse>();

        }
    }
}
