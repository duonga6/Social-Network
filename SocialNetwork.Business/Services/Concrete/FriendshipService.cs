using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using System.Linq.Expressions;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;


namespace SocialNetwork.Business.Services.Concrete
{
    public class FriendshipService : BaseServices<FriendshipService>, IFriendshipService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public FriendshipService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FriendshipService> logger, UserManager<User> userManager, INotificationService notificationService) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public async Task<IResponse> GetByUser(string requestUserId, string? searchString, int pageSize, int pageNumber, FriendType type)
        {
            if (!await CheckExistUser(requestUserId))
            {
                return new ErrorResponse(400, Messages.NotFound("Request user"));
            }

            Expression<Func<Friendship, bool>>? filter;

            switch (type)
            {
                case FriendType.All:
                    if (searchString == null)
                    {
                        filter = x => (x.RequestUserId == requestUserId || x.TargetUserId == requestUserId);
                    }   
                    else
                    {
                        filter = x =>
                            (x.RequestUserId == requestUserId || x.TargetUserId == requestUserId) &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));
                    }    
                    break;
                case FriendType.PendingFromMe:
                    if (searchString == null)
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendshipTypeId == (int)FriendshipEnum.Pending;
                    }   
                    else
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendshipTypeId == (int)FriendshipEnum.Pending &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));

                    }
                    break;
                case FriendType.PendingFromOther :
                    if (searchString == null)
                    {
                        filter = x => x.TargetUserId == requestUserId && x.FriendshipTypeId == (int)FriendshipEnum.Pending;
                    }
                    else
                    {
                        filter = x => x.TargetUserId == requestUserId && x.FriendshipTypeId == (int)FriendshipEnum.Pending &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));
                    }
                    break;
                case FriendType.Accepted:
                    if (searchString == null)
                    {
                        filter = x => (x.RequestUserId == requestUserId || x.TargetUserId == requestUserId) && x.FriendshipTypeId == (int)FriendshipEnum.Accepted;
                    }
                    else
                    {
                        filter = x => (x.RequestUserId == requestUserId || x.TargetUserId == requestUserId) && x.FriendshipTypeId == (int)FriendshipEnum.Accepted &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));
                    }
                    break;
                case FriendType.Blocked:
                    if (searchString == null)
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendshipTypeId == (int)FriendshipEnum.Blocked;
                    }
                    else
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendshipTypeId == (int)FriendshipEnum.Blocked &&
                        (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));
                    }
                    break;
                default:
                    filter = null;
                    break;
            }

            int totalItems = await _unitOfWork.FriendshipRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);


            if (pageCount < pageNumber && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var friendships = await _unitOfWork.FriendshipRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);

            return new PagedResponse<List<GetFriendshipResponse>>(_mapper.Map<List<GetFriendshipResponse>>(friendships), totalItems, 200);
        }

        public async Task<IResponse> GetById(string requestUserId, Guid id)
        {
            if (!await CheckExistUser(requestUserId))
            {
                return new ErrorResponse(400, Messages.NotFound("Request user"));
            }

            var friendship = await _unitOfWork.FriendshipRepository.GetById(id);

            if (friendship.RequestUserId != requestUserId && friendship.TargetUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetFriendshipResponse>(_mapper.Map<GetFriendshipResponse>(friendship), 200);
        }

        public async Task<IResponse> AcceptRequest(string requestUserId, Guid id)
        {

            var entity = await _unitOfWork.FriendshipRepository
                    .GetById(id, false);
            
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Friendship"));
            }

            if (entity.TargetUserId != requestUserId)
            {
                return new ErrorResponse(400, Messages.NotFound());
            }

            if (entity.FriendshipTypeId != (int)FriendshipEnum.Pending)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            entity.FriendshipTypeId = (int)FriendshipEnum.Accepted;
            entity.UpdatedAt = DateTime.UtcNow;

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.FriendshipAccepted, 204);
        }

        public async Task<IResponse> AddFriendRequest(string requestUserId, BaseFriendRequest request)
        {

            if (!await CheckExistUser(requestUserId) || !await CheckExistUser(request.TargetUserId))
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var checkExist = await _unitOfWork.FriendshipRepository
                .FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == request.TargetUserId
                    || x.RequestUserId == request.TargetUserId && x.TargetUserId == requestUserId);


            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.FriendshipExisted);
            }

            var newFriendShip = new Friendship()
            {
                RequestUserId = requestUserId,
                TargetUserId = request.TargetUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FriendshipTypeId = (int)FriendshipEnum.Pending
            };

            await _unitOfWork.FriendshipRepository.Add(newFriendShip);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            var response = _mapper.Map<GetFriendshipResponse>(newFriendShip);

            await _notificationService.CreateNotification(requestUserId, request.TargetUserId, NotificationEnum.FRIEND_REQUEST, response);

            return new DataResponse<GetFriendshipResponse>(response, 200, Messages.FriendshipSent);
        }
            

        public async Task<IResponse> BlockFriend(string requestUserId, BaseFriendRequest request)
        {
            if (!await CheckExistUser(requestUserId) || !await CheckExistUser(request.TargetUserId))
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository
                .FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == request.TargetUserId || x.RequestUserId == request.TargetUserId && x.TargetUserId == requestUserId, false);

            if (entity == null)
            {
                var newFriendShip = new Friendship()
                {
                    RequestUserId = requestUserId,
                    TargetUserId = request.TargetUserId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    FriendshipTypeId = (int)(int)FriendshipEnum.Blocked
                };

                await _unitOfWork.FriendshipRepository.Add(newFriendShip);
            }
            else
            {
                entity.FriendshipTypeId = (int)FriendshipEnum.Blocked;
                await _unitOfWork.FriendshipRepository.Update(entity);
            }

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.FriendshipBlocked, 204);
        }

        public async Task<IResponse> CancelRequest(string requestUserId, Guid id)
        {

            var entity = await _unitOfWork.FriendshipRepository
                    .GetById(id);

            if (entity == null || entity.RequestUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (entity.FriendshipTypeId != (int)FriendshipEnum.Pending)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.FriendshipCanceled, 204);

        }

        public async Task<IResponse> RefuseRequest(string requestUserId, Guid id)
        {
            var entity = await _unitOfWork.FriendshipRepository
                .GetById(id);
            
            if (entity == null || entity.TargetUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.FriendshipRefused, 204);
        }

        public async Task<IResponse> UnBlockFriend(string requestUserId, Guid id)
        {

            var entity = await _unitOfWork.FriendshipRepository
                .GetById(id);

            if (entity == null || entity.RequestUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (entity.FriendshipTypeId != (int)FriendshipEnum.Blocked)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.FriendshipUnblocked, 204);
        }

        public async Task<IResponse> UnFriendRequest(string requestUserId, Guid id)
        {

            var entity = await _unitOfWork.FriendshipRepository
                .GetById(id);
            
            if (entity == null || entity.RequestUserId != requestUserId && entity.TargetUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound("Friendship"));
            }

            if (entity.FriendshipTypeId != (int)FriendshipEnum.Accepted)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWrong);
            }

            return new SuccessResponse(Messages.FriendshipUnfriended, 204);
        }

        public async Task<IResponse> GetInfo(string requestUserId, string targetUserId)
        {
            var friendShip = await _unitOfWork
                .FriendshipRepository
                .FindOneBy(x => 
                    (x.TargetUserId == requestUserId && x.RequestUserId == targetUserId) || 
                    (x.TargetUserId == targetUserId && x.RequestUserId == requestUserId));

            var result = _mapper.Map<GetFriendshipResponse>(friendShip);

            return new DataResponse<GetFriendshipResponse>(result, 200);
        }

        public async Task<IResponse> GetSuggestFriend(string requestUserId, int pageSize, int pageNumber)
        {
            var query = from user in _unitOfWork.UserRepository.GetQueryable()
                        where user.Id != requestUserId && !_unitOfWork.FriendshipRepository.GetQueryable()
                                        .Any(f => (f.RequestUserId == requestUserId && f.TargetUserId == user.Id) || (f.RequestUserId == user.Id && f.TargetUserId == requestUserId))
                        select user;

            int totalItems = await query.CountAsync();
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var friends = await query.OrderBy(x => x.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = _mapper.Map<List<BasicUserResponse>>(friends);

            return new PagedResponse<List<BasicUserResponse>>(result, totalItems, 200);
        }

        public async Task<bool> IsFriend(string userId1, string userId2)
        {
            if (userId1 == userId2)
            {
                return true;
            }

            var result = await _unitOfWork.FriendshipRepository.FindOneBy(x => x.RequestUserId == userId1 && x.TargetUserId == userId2 || x.RequestUserId == userId2 && x.TargetUserId == userId1);
            return result != null;
        }

        private async Task<bool> CheckExistUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null;
        }
    }
}
