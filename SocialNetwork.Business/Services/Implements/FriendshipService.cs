using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    public class FriendshipService : BaseServices<FriendshipService>, IFriendshipService
    {
        public FriendshipService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FriendshipService> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<IResponse> GetByUser(string requestUserId, string? searchString, int pageSize, int pageNumber, FriendType type)
        {

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
                        filter = x => x.RequestUserId == requestUserId && x.FriendStatus == FriendshipStatus.Pending;
                    }   
                    else
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendStatus == FriendshipStatus.Pending &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));

                    }
                    break;
                case FriendType.PendingFromOther :
                    if (searchString == null)
                    {
                        filter = x => x.TargetUserId == requestUserId && x.FriendStatus == FriendshipStatus.Pending;
                    }
                    else
                    {
                        filter = x => x.TargetUserId == requestUserId && x.FriendStatus == FriendshipStatus.Pending &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));
                    }
                    break;
                case FriendType.Accepted:
                    if (searchString == null)
                    {
                        filter = x => (x.RequestUserId == requestUserId || x.TargetUserId == requestUserId) && x.FriendStatus == FriendshipStatus.Accepted;
                    }
                    else
                    {
                        filter = x => (x.RequestUserId == requestUserId || x.TargetUserId == requestUserId) && x.FriendStatus == FriendshipStatus.Accepted &&
                            (x.RequestUserId == requestUserId ? (x.TargetUser.FirstName + " " + x.TargetUser.LastName).Contains(searchString) : (x.RequestUser.FirstName + " " + x.RequestUser.LastName).Contains(searchString));
                    }
                    break;
                case FriendType.Blocked:
                    if (searchString == null)
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendStatus == FriendshipStatus.Blocked;
                    }
                    else
                    {
                        filter = x => x.RequestUserId == requestUserId && x.FriendStatus == FriendshipStatus.Blocked &&
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
            var friendship = await _unitOfWork.FriendshipRepository.GetById(id);

            if (friendship.RequestUserId != requestUserId && friendship.TargetUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse<GetFriendshipResponse>(_mapper.Map<GetFriendshipResponse>(friendship), 200);
        }

        public async Task<IResponse> AcceptRequest(string requestUserId, string targetUserId)
        {
            if (!await CheckExistUser(requestUserId, targetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository
                    .FindOneBy(x => x.RequestUserId == targetUserId && x.TargetUserId == requestUserId, false);
            
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Friend ship"));
            }

            if (entity.FriendStatus != FriendshipStatus.Pending)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            entity.FriendStatus = FriendshipStatus.Accepted;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.FriendshipRepository.Update(entity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new SuccessResponse(Messages.FriendshipAccepted, 204);
        }

        public async Task<IResponse> AddFriendRequest(string requestUserId, BaseFriendRequest request)
        {
            if (!await CheckExistUser(requestUserId, request.TargetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var checkExist = await _unitOfWork.FriendshipRepository
                .FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == request.TargetUserId
                    || x.RequestUserId == request.TargetUserId && x.TargetUserId == requestUserId);


            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var newFriendShip = new Friendship()
            {
                RequestUserId = requestUserId,
                TargetUserId = request.TargetUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FriendStatus = FriendshipStatus.Pending
            };

            await _unitOfWork.FriendshipRepository.Add(newFriendShip);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new DataResponse<GetFriendshipResponse>(_mapper.Map<GetFriendshipResponse>(newFriendShip), 200, Messages.FriendshipSent);
        }

        public async Task<IResponse> BlockFriend(string requestUserId, BaseFriendRequest request)
        {
            if (!await CheckExistUser(requestUserId, request.TargetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
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
                    FriendStatus = FriendshipStatus.Blocked
                };

                await _unitOfWork.FriendshipRepository.Add(newFriendShip);
            }
            else
            {
                entity.FriendStatus = FriendshipStatus.Blocked;
                await _unitOfWork.FriendshipRepository.Update(entity);
            }

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new SuccessResponse(Messages.FriendshipBlocked, 204);
        }

        public async Task<IResponse> CancelRequest(string requestUserId, string targetUserId)
        {
            if (!await CheckExistUser(requestUserId, targetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository
                    .FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == targetUserId, false);

            if (entity == null || entity.RequestUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            if (entity.FriendStatus != FriendshipStatus.Pending)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new SuccessResponse(Messages.FriendshipCanceled, 204);

        }

        public async Task<IResponse> RefuseRequest(string requestUserId, string targetUserId)
        {
            if (!await CheckExistUser(requestUserId, targetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository
                .FindOneBy(x => x.RequestUserId == targetUserId && x.TargetUserId == requestUserId, false);
            
            if (entity == null || entity.TargetUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new SuccessResponse(Messages.FriendshipRefused, 204);
        }

        public async Task<IResponse> UnBlockFriend(string requestUserId, string targetUserId)
        {
            if (!await CheckExistUser(requestUserId, targetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository
                .FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == targetUserId, false);

            if (entity == null || entity.RequestUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            if (entity.FriendStatus != FriendshipStatus.Blocked)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new SuccessResponse(Messages.FriendshipUnblocked, 204);
        }

        public async Task<IResponse> UnFriendRequest(string requestUserId, string targetUserId)
        {
            if (!await CheckExistUser(requestUserId, targetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository
                .FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == targetUserId || x.RequestUserId == targetUserId && x.TargetUserId == requestUserId);
            
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("Friendship"));
            }

            if (entity.FriendStatus != FriendshipStatus.Accepted)
            {
                return new ErrorResponse(400, Messages.FriendshipStatusInValid);
            }

            await _unitOfWork.FriendshipRepository.Delete(entity.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new SuccessResponse(Messages.FriendshipUnfriended, 204);
        }

        private async Task<bool> CheckExistUser(string user1, string user2)
        {
            if ((await _unitOfWork.UserRepository.FindById(user1)) == null)
            {
                return false;
            }

            if ((await _unitOfWork.UserRepository.FindById(user2)) == null)
            {
                return false;
            }

            return true;
        }
    }
}
