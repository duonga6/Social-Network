using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    public class MessageService : BaseServices<MessageService>, IMessageService
    {
        private readonly UserManager<User> _userManager;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MessageService> logger, UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
        }

        public async Task<IResponse> DeleteMessage(string requestUserId, Guid id)
        {
            var message = await _unitOfWork.MessageRepository.GetById(id);

            if (message == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            if (message.SenderId != requestUserId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            await _unitOfWork.MessageRepository.Delete(id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);

        }

        public async Task<IResponse> GetByUser(string requestUserId, string targetUserId, string? searchString, int pageSize, int pageNumber)
        {
            if (requestUserId == targetUserId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }    

            if (!await CheckFriend(requestUserId, targetUserId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            Expression<Func<Message, bool>>? filter;

            if (searchString == null)
            {
                filter = x => (x.SenderId == requestUserId && x.ReceiverId == targetUserId || x.SenderId == targetUserId && x.ReceiverId == requestUserId) && x.Status == 1;
            }   
            else
            {
                filter = x => ((x.SenderId == requestUserId && x.ReceiverId == targetUserId || x.SenderId == targetUserId && x.ReceiverId == requestUserId) && x.Status == 1) &&
                x.Content.Contains(searchString);
            }

            int totalItems = await _unitOfWork.MessageRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageCount < pageNumber && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var messages = await _unitOfWork.MessageRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            var messagesResponse = _mapper.Map<List<GetMessageResponse>>(messages);

            return new PagedResponse<List<GetMessageResponse>>(messagesResponse, totalItems, 200);
        }

        public async Task<IResponse> SendMessage(string requestUserId, SendMessageRequest request)
        {
            if (!await CheckFriend(requestUserId, request.ReceiverId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var addEntity = _mapper.Map<DataAccess.Entities.Message>(request);
            addEntity.SenderId = requestUserId;

            await _unitOfWork.MessageRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new DataResponse<GetMessageResponse>(_mapper.Map<GetMessageResponse>(addEntity), 200, Messages.MessageSent);

        }

        public async Task<IResponse> GetById(string requestUserId, Guid id)
        {
            var message = await _unitOfWork.MessageRepository.GetById(id);
            if (message == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }    

            if (!await CheckFriend(requestUserId, message.SenderId) && !await CheckFriend(requestUserId, message.ReceiverId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            return new DataResponse<GetMessageResponse>(_mapper.Map<GetMessageResponse>(message), 200);
            
        }

        private async Task<bool> CheckFriend(string requestUserId, string targetUserId) => await _unitOfWork.FriendshipRepository.IsFriend(requestUserId, targetUserId);
    }
}
