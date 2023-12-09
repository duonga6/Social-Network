using AutoMapper;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.Services.Implements
{
    public class FriendshipService : BaseServices, IFriendshipService
    {
        public FriendshipService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResponse> GetByUser(string userId)
        {
            var entities = await _unitOfWork.FriendshipRepository.FindBy(x => x.RequestUserId == userId || x.TargetUserId == userId);

            return new DataResponse(_mapper.Map<List<GetFriendshipResponse>>(entities), 200);
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

            var checkExist = await _unitOfWork.FriendshipRepository.FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == request.TargetUserId);
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

            return new DataResponse(_mapper.Map<GetFriendshipResponse>(newFriendShip), 200, Messages.FriendshipSent);
        }

        public async Task<IResponse> BlockFriend(string requestUserId, BaseFriendRequest request)
        {
            if (!await CheckExistUser(requestUserId, request.TargetUserId))
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var entity = await _unitOfWork.FriendshipRepository.FindOneBy(x => x.RequestUserId == requestUserId && x.TargetUserId == request.TargetUserId, false);

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
            
            if (entity == null || entity.TargetUserId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound);
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

            return new SuccessResponse(Messages.FriendshipUnblocked, 204);
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
