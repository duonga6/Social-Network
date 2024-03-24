using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        public async Task<bool> CreateNotification(string fromUserId, string toUserId, NotificationEnum type, dynamic notifiable)
        {
            if (fromUserId == toUserId)
            {
                return false;
            }

            var fromUser = await _userManager.FindByIdAsync(fromUserId);
            var toUser = await _userManager.FindByIdAsync(toUserId);
            var jsonDetail = JsonConvert.SerializeObject(notifiable, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            if (fromUser == null || toUser == null)
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

                        var friendOfFromUser = (await _unitOfWork.FriendshipRepository.GetAllFriendship(fromUserId)).Select(x => x.RequestUserId == fromUserId ? x.TargetUserId : x.RequestUserId);

                        foreach (var targetId in friendOfFromUser)
                        {
                            notifications.Add(new Notification
                            {
                                NotifiableId = notifiable.Id.ToString(),
                                NotificationType = type.ToString(),
                                FromId = fromUserId,
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
                        content = @$"<strong>{fromUser.GetFullName()}<strong> đã bày tỏ cảm xúc về bài viết của bạn.";

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

            }
            await _unitOfWork.NotificationRepository.AddRange(notifications);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IResponse> GetNotifications(string userId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Notification, bool>> filter = x => x.ToId == userId;

            if (searchString != null)
            {
                filter = filter.And(x => x.Content.Contains(searchString));
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
            if (notification.ToId != userId) return new ErrorResponse(404, Messages.NotFound());

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

            var notifications = await _unitOfWork
                .NotificationRepository
                .GetCursorPaged(pageSize, filter, getNext);

            bool hasNext = true;

            // Check has next
            var query = _unitOfWork.NotificationRepository.GetQueryable().AsNoTracking().Where(filter);

            if (getNext)
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }
            else
            {
                query = query.OrderBy(x => x.CreatedAt);
            }

            var checkCount = await query.Take(pageSize + 1).CountAsync();

            if (checkCount <= notifications.Count)
            {
                hasNext = false;
            }

            var endCursor = notifications.LastOrDefault()?.CreatedAt;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetNotificationResponse>>(notifications);

            return new CursorResponse<List<GetNotificationResponse>>(response, endCursor, hasNext, totalItems);

        }

    }
}
