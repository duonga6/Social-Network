using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    internal class NotificationService : BaseServices<NotificationService>, INotificationService
    {
        private readonly UserManager<User> _userManager;
        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<NotificationService> logger, UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateNotification(string fromUserId, string toUserId, NotificationEnum type)
        {
            if (fromUserId == toUserId)
            {
                return false;
            }

            var fromUser = await _userManager.FindByIdAsync(fromUserId);
            var toUser = await _userManager.FindByIdAsync(toUserId);

            if (fromUser == null || toUser == null)
            {
                return false;
            }

            switch (type)
            {
                case NotificationEnum.Post:
                    {
                        string content = @$"""{fromUser.GetFullName()}"" đã đăng một bài viết.";

                        var friendOfFromUser = await _unitOfWork.FriendshipRepository.GetAllFriendship(fromUserId);
                        foreach (var item in friendOfFromUser)
                        {
                            if (item.TargetUserId != fromUserId)
                            {
                                var notification = new DataAccess.Entities.Notification
                                {
                                    Content = content,
                                    Seen = false,
                                    TargetUserId = item.TargetUserId,
                                    FromUserId = fromUserId,
                                };

                                await _unitOfWork.NotificationRepository.Add(notification);
                            }

                        }

                        var result = await _unitOfWork.CompleteAsync();
                        return result;
                    }
                case NotificationEnum.PostComment:
                    {
                        string content = @$"""{fromUser.GetFullName()}"" đã đã bình luận về bài viết của bạn.";

                        var notification = new DataAccess.Entities.Notification
                        {
                            Content = content,
                            Seen = false,
                            TargetUserId = toUserId,
                            FromUserId = fromUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                case NotificationEnum.PostCommentReaction:
                    {
                        string content = @$"""{fromUser.GetFullName()}"" đã bày tỏ cảm xúc về bình luận của bạn.";

                        var notification = new DataAccess.Entities.Notification
                        {
                            Content = content,
                            Seen = false,
                            TargetUserId = toUserId,
                            FromUserId = fromUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                case NotificationEnum.FriendRequest:
                    {
                        string content = @$"""{fromUser.GetFullName()}"" đã gửi cho bạn lời mời kết bạn.";

                        var notification = new DataAccess.Entities.Notification
                        {
                            Content = content,
                            Seen = false,
                            TargetUserId = toUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                case NotificationEnum.PostReaction:
                    {
                        string content = @$"""{fromUser.GetFullName()}"" đã bày tỏ cảm xúc về bài viết của bạn.";

                        var notification = new DataAccess.Entities.Notification
                        {
                            Content = content,
                            Seen = false,
                            TargetUserId = toUserId,
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        var result = await _unitOfWork.CompleteAsync();

                        return result;
                    }
                default:
                    return false;
            }
        }

        public async Task<IResponse> GetNotifications(string userId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Notification, bool>> filter;

            if (searchString != null)
            {
                filter = x => x.TargetUser.Id == userId && x.Content.Contains(searchString);
            }
            else
            {
                filter = x => x.TargetUser.Id == userId;
            }    

            int totalItems = await _unitOfWork.NotificationRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageCount < pageNumber && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var notifications = await _unitOfWork.NotificationRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            var notificationsResult = _mapper.Map<List<GetNotificationResponse>>(notifications);

            return new PagedResponse<List<GetNotificationResponse>>(notificationsResult, totalItems, 200);
        }

        public async Task<IResponse> SeenNotification(string userId, Guid id)
        {
            var notification = await _unitOfWork.NotificationRepository.GetById(id);
            if (notification.TargetUserId != userId) return new ErrorResponse(404, Messages.NotFound());

            if (notification.Seen)
            {
                return new SuccessResponse(Messages.NotificationSeen, 204);
            }    

            await _unitOfWork.NotificationRepository.Seen(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.STWrong);
            }

            return new SuccessResponse(Messages.MessageSeen, 204);
            
        }

        public async Task<IResponse> GetById(string userId, Guid id)
        {
            var notification = await _unitOfWork.NotificationRepository.GetById(id);

            if (notification == null || notification.TargetUserId != userId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetNotificationResponse>(_mapper.Map<GetNotificationResponse>(notification), 200);

        }
    }
}
