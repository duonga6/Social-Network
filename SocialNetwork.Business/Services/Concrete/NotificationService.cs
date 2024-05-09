using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.Business.DTOs.Responses;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    internal class NotificationService : BaseServices<NotificationService>, INotificationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHubControl _centerHub;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<NotificationService> logger, UserManager<User> userManager, IHubControl centerHub) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _centerHub = centerHub;
        }

        public async Task<bool> CreateNotification(string fromUserId, string toUserId, NotificationEnum type, dynamic notifiable)
        {
            if (fromUserId == toUserId)
            {
                return false;
            }


            var fromUser = await _userManager.FindByIdAsync(fromUserId);
            var toUser = await _userManager.FindByIdAsync(toUserId);
            var jsonDetail = JsonConvert.SerializeObject(notifiable);

            if (fromUser == null)
            {
                return false;
            }

            List<Notification> notifications = new List<Notification>();

            string content = "";

            switch (type)
            {
                case NotificationEnum.CREATE_POST:
                    {
                        content = @$"<strong>{fromUser.GetFullName()}</strong> đã thêm một bài viết.";

                        var friendOfFromUser = (await _unitOfWork.FriendshipRepository.GetAllFriendship(fromUserId)).Select(x => x.RequestUserId == fromUserId ? x.TargetUserId : x.RequestUserId).ToList();

                        foreach (var targetId in friendOfFromUser)
                        {
                            notifications.Add(new Notification
                            {
                                NotifiableId = notifiable.Id.ToString(),
                                NotificationType = type.ToString(),
                                FromId = fromUserId,
                                ToId = targetId,
                                Content = content,
                                JsonDetail = jsonDetail,
                            });
                        }
                        break;
                    }
                case NotificationEnum.POST_COMMENT:
                    {
                        content = @$"<strong>{fromUser.GetFullName()}</strong> đã đã bình luận về bài viết của bạn.";

                        notifications.Add(new Notification
                        {
                            NotifiableId = notifiable.Id.ToString(),
                            NotificationType = type.ToString(),
                            FromId = fromUserId,
                            ToId = toUserId,
                            Content = content,
                            JsonDetail = jsonDetail,
                        });
                        break;
                    }
                case NotificationEnum.COMMENT_REACTION:
                    {
                        content = @$"<strong>{fromUser.GetFullName()}</strong> đã bày tỏ cảm xúc về bình luận của bạn.";

                        notifications.Add( new Notification 
                        {
                            NotifiableId = notifiable.Id.ToString(),
                            NotificationType = type.ToString(),
                            FromId = fromUserId,
                            ToId = toUserId,
                            Content = content,
                            JsonDetail = jsonDetail,
                        });
                        break;
                    }
                case NotificationEnum.FRIEND_REQUEST:
                    {
                        content = @$"<strong>{fromUser.GetFullName()}</strong> đã gửi cho bạn lời mời kết bạn.";

                        notifications.Add(new Notification 
                        {
                            NotifiableId = notifiable.Id.ToString(),
                            NotificationType = type.ToString(),
                            FromId = fromUserId,
                            ToId = toUserId,
                            Content = content,
                            JsonDetail = jsonDetail 
                        });
                        break;
                    }
                case NotificationEnum.POST_REACTION:
                    {
                        content = @$"<strong>{fromUser.GetFullName()}</strong> đã bày tỏ cảm xúc về bài viết của bạn.";

                        notifications.Add(new Notification {
                            NotifiableId = notifiable.Id.ToString(),
                            NotificationType = type.ToString(),
                            FromId = fromUserId,
                            ToId = toUserId,
                            Content = content,
                            JsonDetail = jsonDetail 
                        });
                        break;
                    }
                case NotificationEnum.SHARE_POST:
                    {
                        content = @$"<strong>{fromUser.GetFullName()}</strong> đã chia sẻ bài viết của bạn.";

                        notifications.Add(new Notification 
                        {
                            NotifiableId = notifiable.Id.ToString(),
                            NotificationType = type.ToString(),
                            FromId = fromUserId,
                            ToId = toUserId,
                            Content = content,
                            JsonDetail = jsonDetail 
                        });
                        break;
                    }
                case NotificationEnum.HAVE_REQUEST_JOIN_GROUP:
                    {

                        break;
                    }

            }
            await _unitOfWork.NotificationRepository.AddRange(notifications);
            await _unitOfWork.CompleteAsync();

            var notificationMapped = _mapper.Map<List<GetNotificationResponse>>(notifications);
            foreach(var notification in notificationMapped)
            {
                Task sendNotificaiton = Task.Run(async () =>
                {
                    await _centerHub.NewNotification(notification.ToId, notification);
                });
            }

            return true;
        }

        public async Task<IResponse> GetNotifications(string userId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Notification, bool>> filter = x => x.ToId == userId;

            if (searchString != null)
            {
                filter = filter.And(x => x.Content.Contains(searchString));
            }   

            int totalItems = await _unitOfWork.NotificationRepository.GetCount(filter);
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
            if (notification.ToId != userId) return new ErrorResponse(404, Messages.NotFound());

            await _unitOfWork.NotificationRepository.Seen(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.STWrong);
            }

            var response = await _unitOfWork.NotificationRepository.GetById(id);

            return new DataResponse<GetNotificationResponse>(_mapper.Map<GetNotificationResponse>(response), 200);
            
        }

        public async Task<IResponse> GetById(string userId, Guid id)
        {
            var notification = await _unitOfWork.NotificationRepository.GetById(id);

            if (notification == null || notification.ToId != userId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetNotificationResponse>(_mapper.Map<GetNotificationResponse>(notification), 200);

        }
    
        public async Task<IResponse> GetCursor(string requestUserId, int pageSize, DateTime? cursor, bool getNext)
        {
            Expression<Func<Notification, bool>> filter = x => x.ToId == requestUserId;

            int totalItems = await _unitOfWork.NotificationRepository.GetCount(filter);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var notifications = (await _unitOfWork
                .NotificationRepository
                .GetCursorPaged(pageSize + 1, filter, getNext)).ToList();

            bool hasNext = true;

            if (notifications.Count <= pageSize)
            {
                hasNext = false;
            } 
            else
            {
                notifications.RemoveAt(notifications.Count - 1);
            }

            DateTime? endCursor = notifications.LastOrDefault()?.CreatedAt;

            var response = _mapper.Map<List<GetNotificationResponse>>(notifications);

            return new CursorResponse<List<GetNotificationResponse>>(response, endCursor, hasNext, totalItems);

        }

    }
}
