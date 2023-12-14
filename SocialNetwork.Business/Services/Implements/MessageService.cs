using AutoMapper;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.Business.Services.Implements
{
    public class MessageService : BaseServices, IMessageService
    {
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
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

        public async Task<IResponse> GetAll(string requestUserId, string targetUserId)
        {
            if (!await CheckFriend(requestUserId, targetUserId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var messages = await _unitOfWork.MessageRepository.GetConversation(requestUserId, targetUserId);
            var messagesResponse = _mapper.Map<List<GetMessageResponse>>(messages);

            return new DataResponse(messagesResponse, 200);
        }

        public async Task<IResponse> SendMessage(string requestUserId, SendMessageRequest request)
        {
            if (!await CheckFriend(requestUserId, request.ReceiverId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var addEntity = _mapper.Map<Message>(request);
            addEntity.SenderId = requestUserId;

            await _unitOfWork.MessageRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(501, Messages.STWroong);
            }

            return new DataResponse(_mapper.Map<GetMessageResponse>(addEntity), 200, Messages.MessageSent);

        }

        private async Task<bool> CheckFriend(string requestUserId, string targetUserId) => await _unitOfWork.FriendshipRepository.IsFriend(requestUserId, targetUserId);
    }
}
