using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.Services.Implements.Base;
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

        public async Task<bool> CreateNotification(string fromUserId, string toUserId, NotificationEnum type, Guid notifiableId)
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

            List<Notification> notifications = new List<Notification>();
            string content = "";

            switch (type)
            {
                case NotificationEnum.Post:
                    {
                        content = @$"""{fromUser.GetFullName()}"" đã thêm một bài viết.";

                        var friendOfFromUser = (await _unitOfWork.FriendshipRepository.GetAllFriendship(fromUserId)).Select(x => x.RequestUserId == fromUserId ? x.TargetUserId : x.RequestUserId);

                        foreach (var targetId in friendOfFromUser)
                        {
                            notifications.Add(new Notification
                            {
                                NotifiableId = notifiableId,
                                NotifiableType = "POST",
                                UserId = targetId,
                                NotificationDetail = new NotificationDetails
                                {
                                     Url = "",
                                     AuthorId = fromUserId,
                                     Content = content,
                                }
                            });
                        }

                        await _unitOfWork.NotificationRepository.AddRange(notifications);
                        return await _unitOfWork.CompleteAsync();
                    }
                case NotificationEnum.PostComment:
                    {
                        content = @$"""{fromUser.GetFullName()}"" đã đã bình luận về bài viết của bạn.";

                        var notification = new Notification
                        {
                            NotifiableId = notifiableId,
                            NotifiableType = "POST COMMENT",
                            UserId = toUserId,
                            NotificationDetail = new NotificationDetails
                            {
                                Url = "",
                                AuthorId = fromUserId,
                                Content = content,
                            }
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        return await _unitOfWork.CompleteAsync();
                    }
                case NotificationEnum.PostCommentReaction:
                    {
                        content = @$"""{fromUser.GetFullName()}"" đã bày tỏ cảm xúc về bình luận của bạn.";

                        var notification = new Notification
                        {
                            NotifiableId = notifiableId,
                            NotifiableType = "POST COMMENT REACTION",
                            UserId = toUserId,
                            NotificationDetail = new NotificationDetails
                            {
                                Url = "",
                                AuthorId = fromUserId,
                                Content = content,
                            }
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        return await _unitOfWork.CompleteAsync();
                    }
                case NotificationEnum.FriendRequest:
                    {
                        content = @$"""{fromUser.GetFullName()}"" đã gửi cho bạn lời mời kết bạn.";

                        var notification = new Notification
                        {
                            NotifiableId = notifiableId,
                            NotifiableType = "FRIEND REQUEST",
                            UserId = toUserId,
                            NotificationDetail = new NotificationDetails
                            {
                                Url = "",
                                AuthorId = fromUserId,
                                Content = content,
                            }
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        return await _unitOfWork.CompleteAsync();
                    }
                case NotificationEnum.PostReaction:
                    {
                        content = @$"""{fromUser.GetFullName()}"" đã bày tỏ cảm xúc về bài viết của bạn.";

                        var notification = new DataAccess.Entities.Notification
                        {
                            NotifiableId = notifiableId,
                            NotifiableType = "POST REACTION",
                            UserId = toUserId,
                            NotificationDetail = new NotificationDetails
                            {
                                Url = "",
                                AuthorId = fromUserId,
                                Content = content,
                            }
                        };

                        await _unitOfWork.NotificationRepository.Add(notification);
                        return await _unitOfWork.CompleteAsync();
                    }
                default:
                    return false;
            }
        }

        public async Task<IResponse> GetNotifications(string userId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Notification, bool>> filter = x => x.UserId == userId;

            if (searchString != null)
            {
                filter = filter.And(x => x.NotificationDetail.Content.Contains(searchString));
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
            if (notification.UserId != userId) return new ErrorResponse(404, Messages.NotFound());

            //if (notification.Seen)
            //{
            //    return new SuccessResponse(Messages.NotificationSeen, 204);
            //}    ??

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

            if (notification == null || notification.UserId != userId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetNotificationResponse>(_mapper.Map<GetNotificationResponse>(notification), 200);

        }
    }
}
