using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class MessageService : BaseServices<MessageService>, IMessageService
    {
        private readonly UserManager<User> _userManager;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MessageService> logger, UserManager<User> userManager) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
        }

        public async Task<IResponse> Create(string requestId, CreateMessageRequest request)
        {
            var checkUserSend = await _unitOfWork.UserRepository.GetById(requestId) ?? throw new NotFoundException("User + id: " + requestId);
            var checkUserRecive = await _unitOfWork.UserRepository.GetById(request.UserId) ?? throw new NotFoundException("User + id: " + request.UserId);
            bool compareId = checkUserSend.Id.CompareTo(checkUserRecive.Id) <= 0;

            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(
                x => x.Type == ConversationType.PRIVATE && 
                x.ConversationParticipants.Any(x => x.UserId == requestId) &&
                x.ConversationParticipants.Any(x => x.UserId == request.UserId)
                );

            var newMessage = new Message
            {
                Content = request.Content,
                MessageType = MessageType.NORMAL,
                UserId = requestId,
            };

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                if (conversation == null)
                {

                    var newConversation = new Conversation
                    {
                        Type = ConversationType.PRIVATE,
                        CreatedId = requestId,
                        ConversationParticipants = new List<ConversationParticipant>
                    {
                        new ConversationParticipant
                        {
                            UserId = checkUserSend.Id,
                            UserContactName = checkUserSend.GetFullName(),
                        },
                         new ConversationParticipant
                        {
                            UserId = checkUserRecive.Id,
                            UserContactName = checkUserRecive.GetFullName(),
                        }
                    },
                        Messages = new List<Message>
                    {
                        newMessage
                    }
                    };

                    await _unitOfWork.ConversationRepository.Add(newConversation);

                }
                else
                {
                    newMessage.ConversationId = conversation.Id;
                    await _unitOfWork.MessageRepository.Add(newMessage);
                    await _unitOfWork.ConversationRepository.UpdateNewestMessage(conversation.Id);
                }

                if (!await _unitOfWork.CommitAsync()) throw new NoDataChangeException();
            } 
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("Error Message Service / Create " + ex);
                return new ErrorResponse(501, Messages.STWrong);
            }

            var messagedAdded = await _unitOfWork.MessageRepository.GetById(newMessage.Id, new Expression<Func<Message, object>>[]
            {
                    x => x.User
            });

            var response = _mapper.Map<GetMessageResponse>(messagedAdded);

            return new DataResponse<GetMessageResponse>(response, 201);
        }

        public async Task<IResponse> Create(string requestId, CreateMessageWithConversationRequest request)
        {
            var conversation = await _unitOfWork.ConversationRepository
                .FindOneBy(x =>
                x.Id == request.ConversationId &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId)) ?? throw new NotFoundException("Conversation id: " + request.ConversationId.ToString());

            if (request.ReplyId != null)
            {
                var replyMessage = await _unitOfWork.MessageRepository.
                    FindOneBy(x => x.Id == request.ReplyId && x.ConversationId == request.ConversationId) ?? throw new NotFoundException("Reply message id: " + request.ReplyId.ToString());
            }

            var newMessage = new Message
            {
                Content = request.Content,
                MessageType = MessageType.NORMAL,
                ReplyId = request.ReplyId,
                UserId = requestId,
                ConversationId = conversation.Id,
            };

            await _unitOfWork.MessageRepository.Add(newMessage);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var messagedAdded = await _unitOfWork.MessageRepository.GetById(newMessage.Id, new Expression<Func<Message, object>>[]
            {
                    x => x.User
            });

            var response = _mapper.Map<GetMessageResponse>(messagedAdded);

            return new DataResponse<GetMessageResponse>(response, 201);
        }

        public async Task<IResponse> Get(string requestId, Guid conversationId, int pageSize, string? searchString, DateTime? cursor)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetById(conversationId) ?? throw new NotFoundException("Conversation id: " + conversationId.ToString());

            var checkParicipant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == conversation.Id &&
                x.UserId == requestId);

            if (checkParicipant == null) return new ErrorResponse(400, Messages.BadRequest);

            Expression<Func<Message, bool>> filter = x => x.Status == 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And(x => x.Content.Contains(searchString));
            }

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.MessageRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Message, object>>[]
            {
                x => x.User
            })).ToList();

            bool hasNext = false;
            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedAt : null;

            if (endCursor != null)
            {
                endCursor = DateTime.SpecifyKind(endCursor.Value, DateTimeKind.Utc);
            }

            var response = _mapper.Map<List<GetMessageResponse>>(data);

            return new CursorResponse<List<GetMessageResponse>>(response, cursor, hasNext, 0);
        }

        public async Task<IResponse> GetById(string requestId, Guid messagesId)
        {
            var message = await _unitOfWork.MessageRepository.GetById(messagesId, new Expression<Func<Message, object>>[]
            {
                x => x.User
            }) ?? throw new NotFoundException("Message id: " + messagesId.ToString());

            if (requestId != message.UserId)
            {
                var checkAccess = await _unitOfWork.ConversationRepository
                    .FindOneBy(x => 
                    x.Id == message.ConversationId && 
                    x.ConversationParticipants.Any(x => x.UserId == requestId)) ?? throw new NotFoundException("Conversation of message id: " + messagesId.ToString());
            }

            var response = _mapper.Map<GetMessageResponse>(message);

            return new DataResponse<GetMessageResponse>(response, 200);
        }

        public async Task<IResponse> RevokeMessage(string requestId, Guid messageId)
        {
            var message = await _unitOfWork.MessageRepository.GetById(messageId) ?? throw new NotFoundException("Message id: " + messageId.ToString());

            if (message.UserId != requestId) return new ErrorResponse(400, Messages.BadRequest);

            await _unitOfWork.MessageRepository.RevokeMessage(message.Id);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            return new SuccessResponse(Messages.MessageRevoked, 200);
        }

        public async Task<IResponse> SeenMessage(string requestId, Guid messageId)
        {
            var message = await _unitOfWork.MessageRepository.GetById(messageId) ?? throw new NotFoundException("Message id: " + messageId.ToString());

            if (message.UserId == requestId) return new ErrorResponse(400, Messages.BadRequest);

            bool compareId = requestId.CompareTo(message.UserId) <= 0;

            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == message.ConversationId &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId)
            );

            if (conversation == null) return new ErrorResponse(400, Messages.BadRequest);

            if (conversation.Type == ConversationType.GROUP)
            {
                var messageReaded = new MessageMemberReaded
                {
                    ConversationId = conversation.Id,
                    MessageId = message.Id,
                    UserId = requestId,
                };

                await _unitOfWork.MessageMemberReadRepository.Add(messageReaded);
            } else
            {
                await _unitOfWork.MessageRepository.SeenMessage(message.Id);
            }
            
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            return new SuccessResponse(Messages.MessageSeen, 200);
        }
    }
}
