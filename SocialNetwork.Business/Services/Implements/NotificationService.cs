using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.Services.Implements
{
    internal class NotificationService : BaseServices<NotificationService>, INotificationService
    {
        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<NotificationService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<bool> CreateNotification(string fromUserId, string toUserId, TypeNotification type)
        {
            if (fromUserId == toUserId)
            {
                return false;
            }

            var fromUser = await _unitOfWork.UserRepository.FindById(fromUserId);
            var toUser = await _unitOfWork.UserRepository.FindById(toUserId);

            switch (type)
            {
                case TypeNotification.Post:
                    {
                        if (fromUser == null) return false;
                        string content = @$"""{fromUser.FirstName} {fromUser.LastName}"" đã đăng một bài viết.";

                        var friendOfFromUser = await _unitOfWork.FriendshipRepository.GetAllFriends(fromUserId);
                        foreach (var item in friendOfFromUser)
                        {
                            if (item.TargetUserId != fromUserId)
                            {
                                var notification = new DataAccess.Entities.NotificationService
                                {
                                    Content = content,
                                    Seen = false,
                                    UserId = item.TargetUserId,
                                };

                                await _unitOfWork.NotificationRepository.Add(notification);
                            }

                        }

                        var result = await _unitOfWork.CompleteAsync();
                        return result;
                    }
                case TypeNotification.PostComment:
                    {
                        if (fromUser == null || toUser == null) return false;
                        string content = @$"""{fromUser.FirstName} {fromUser.LastName}"" đã đã bình luận về bài viết của bạn.";

                        var notification = new DataAccess.Entities.NotificationService
                        {
                            Content = content,
                            Seen = false,
                            UserId = toUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                case TypeNotification.PostCommentReaction:
                    {
                        if (fromUser == null || toUser == null) return false;
                        string content = @$"""{fromUser.FirstName} {fromUser.LastName}"" đã bày tỏ cảm xúc về bình luận của bạn.";

                        var notification = new DataAccess.Entities.NotificationService
                        {
                            Content = content,
                            Seen = false,
                            UserId = toUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                case TypeNotification.FriendRequest:
                    {
                        if (fromUser == null || toUser == null) return false;
                        string content = @$"""{fromUser.FirstName} {fromUser.LastName}"" đã gửi cho bạn lời mời kết bạn.";

                        var notification = new DataAccess.Entities.NotificationService
                        {
                            Content = content,
                            Seen = false,
                            UserId = toUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                case TypeNotification.PostReaction:
                    {
                        if (fromUser == null || toUser == null) return false;
                        string content = @$"""{fromUser.FirstName} {fromUser.LastName}"" đã bày tỏ cảm xúc về bài viết của bạn.";

                        var notification = new DataAccess.Entities.NotificationService
                        {
                            Content = content,
                            Seen = false,
                            UserId = toUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                default:
                    return false;
            }
        }

        public async Task<IResponse> GetNotifications(string userId)
        {
            var notifications = await _unitOfWork.NotificationRepository.GetUserNotifications(userId);
            return new DataResponse(_mapper.Map<List<GetNotificationResponse>>(notifications), 200);
        }

        public async Task<IResponse> SeenNotification(string userId, Guid id)
        {
            var notification = await _unitOfWork.NotificationRepository.GetById(id);
            if (notification.UserId != userId) return new ErrorResponse(404, Messages.NotFound);

            if (notification.Seen)
            {
                return new SuccessResponse(Messages.NotiHBSeen, 204);
            }    

            await _unitOfWork.NotificationRepository.Seen(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.STWroong);
            }

            return new SuccessResponse(Messages.MessageSeen, 204);
            
        }

        public async Task<IResponse> GetById(string userId, Guid id)
        {
            var notification = await _unitOfWork.NotificationRepository.GetById(id);

            if (notification == null || notification.UserId != userId)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse(_mapper.Map<GetNotificationResponse>(notification), 200);

        }
    }
}
