using AutoMapper;
using LinqKit;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Ocsp;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class ConversationService : BaseServices<ConversationService>, IConversationService
    {
        private readonly IHubControl _centerHub;
        public ConversationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ConversationService> logger, IHubControl centerHub) : base(unitOfWork, mapper, logger)
        {
            _centerHub = centerHub;
        }


        public async Task<IResponse> Create(string requestId, CreateConversationRequest request)
        {
            if (request.UserIds.Count == 1)
            {
                var checkPrivateConversation = await _unitOfWork.ConversationRepository.FindOneBy(
                    x => x.Type == ConversationType.PRIVATE &&
                    x.Status == 1 && 
                    x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1) &&
                    x.ConversationParticipants.Any(cp => cp.UserId == request.UserIds[0] && cp.Status == 1));

                if (checkPrivateConversation != null)
                {
                    var conversation = (DataResponse<GetConversationResponse>)await this.GetById(requestId, checkPrivateConversation.Id);
                    return new DataResponse<GetConversationResponse>(conversation.Data, 201, Messages.CreatedSuccessfully);
                }
            }

            var requestUser = await _unitOfWork.UserRepository.GetById(requestId);

            var listParticipants = new List<ConversationParticipant>
            {
                new()
                {
                    UserId = requestId,
                    UserContactName = requestUser.GetFullName(),
                    IsAdmin = true,
                    IsSuperAdmin = true,
                }
            };


            foreach (var uid in request.UserIds)
            {
                if (uid == requestId) continue;

                var user = await _unitOfWork.UserRepository.GetById(uid) ?? throw new NotFoundException("User id: " + uid);
                listParticipants.Add(new()
                {
                    UserId = user.Id,
                    UserContactName = user.GetFullName(),
                    IsAdmin = request.UserIds.Count == 1,
                    IsSuperAdmin = request.UserIds.Count == 1,
                });
            }


            var newConversation = new Conversation
            {
                CreatedId = requestId,
                Type = request.UserIds.Count > 1 ? ConversationType.GROUP : ConversationType.PRIVATE,
                ConversationParticipants = listParticipants,
            };

            await _unitOfWork.ConversationRepository.Add(newConversation);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var conversationCreated = (DataResponse<GetConversationResponse>)await this.GetById(requestId, newConversation.Id);

            if (request.UserIds.Count > 1)
            {
                await _centerHub.NewGroupConversation(request.UserIds, conversationCreated.Data);
            }

            return new DataResponse<GetConversationResponse>(conversationCreated.Data, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Delete(string requestId, Guid conversationId)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == conversationId &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.IsSuperAdmin && cp.Status == 1)
            ) ?? throw new NotFoundException("Conversation id: " + conversationId.ToString());

            await _unitOfWork.ConversationRepository.Delete(conversationId);
            var result = await _unitOfWork.CompleteAsync();
            if (!result) throw new NoDataChangeException();

            var conversationParticipantIds = (await _unitOfWork.ConversationParticipantRepository.FindBy(x => x.ConversationId == conversation.Id && x.Status == 1)).Select(x => x.UserId).ToList();

            Task sendNotitication = Task.Run(async () =>
            {
                await _centerHub.DeleteConversation(conversationParticipantIds, conversation.Id);
            });
            

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> GetById(string requestId, Guid conversationId)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == conversationId &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1)
            ) ?? throw new NotFoundException("Conversation id: " + conversationId.ToString());

            var lastMessage = await _unitOfWork.MessageRepository.GetPaged(1, 1, new Expression<Func<Message, object>>[]
            {
                x => x.User
            }, x => x.ConversationId == conversation.Id, x => x.CreatedAt);
            conversation.Messages = lastMessage.ToList();

            var response = _mapper.Map<GetConversationResponse>(conversation);

            if (conversation.Type == ConversationType.PRIVATE)
            {
                var participant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == conversation.Id && x.UserId != requestId, new Expression<Func<ConversationParticipant, object>>[]
                {
                    x => x.User
                });
                response.Name = participant.UserContactName;
                response.Images = new() { participant.User.AvatarUrl };
            } 
            else
            {
                if (conversation.Name == null || conversation.Image == null)
                {

                    var participants = await _unitOfWork.ConversationParticipantRepository.GetPaged(2, 1, new Expression<Func<ConversationParticipant, object>>[]
                    {
                    x => x.User
                    }, x => x.ConversationId == conversation.Id, x => x.CreatedAt);
                    response.Name = string.Join(", ", participants.Select(x => x.User.FirstName));

                    if (conversation.Image == null)
                    {
                        response.Images = participants.Select(x => x.User.AvatarUrl).ToList();
                    }
                    else
                    {
                        response.Images = new() { conversation.Image };
                    }
                }

            }

            return new DataResponse<GetConversationResponse>(response, 200);
        }

        public async Task<IResponse> GetConversation(string requestId, int pageSize, string? searchString, DateTime? cursor)
        {
            Expression<Func<Conversation, bool>> filter = x => x.Status == 1 && x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1) && x.Messages.Any();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = filter.And(x => x.Name.Contains(searchString.Trim()));
            }

            if (cursor != null)
            {
                filter = filter.And(x => x.UpdatedAt < cursor);
            }

            var data = (await _unitOfWork.ConversationRepository.GetCursorPaged(pageSize + 1, filter, x => x.UpdatedAt)).ToList();

            bool hasNext = false;

            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.UpdatedAt : null;

            var response = new List<GetConversationResponse>();

            foreach (var conversation in data)
            {
                var lastMessage = await _unitOfWork.MessageRepository.GetPaged(1, 1, new Expression<Func<Message, object>>[]
                {
                    x => x.User,
                    x => x.Participant
                }, x => x.ConversationId == conversation.Id, x => x.CreatedAt);

                conversation.Messages = lastMessage.ToList();

                var mappedConversation = _mapper.Map<GetConversationResponse>(conversation);

                if (mappedConversation.Type == ConversationType.PRIVATE)
                {
                    var user = await _unitOfWork.ConversationParticipantRepository.FindOneBy(
                        x => x.ConversationId == conversation.Id && x.UserId != requestId,
                        new Expression<Func<ConversationParticipant, object>>[] { x => x.User }) ?? throw new NotFoundException("User conversation");
                    mappedConversation.Images = new() { user.User.AvatarUrl };
                    mappedConversation.Name = user.UserContactName;
                }
                else
                {
                    if (conversation.Name == null || conversation.Image == null)
                    {

                        var participants = await _unitOfWork.ConversationParticipantRepository.GetPaged(2, 1, new Expression<Func<ConversationParticipant, object>>[]
                        {
                            x => x.User
                        }, x => x.ConversationId == conversation.Id, x => x.CreatedAt);
                        mappedConversation.Name = string.Join(", ", participants.Select(x => x.User.FirstName));

                        if (conversation.Image == null)
                        {
                            mappedConversation.Images = participants.Select(x => x.User.AvatarUrl).ToList();
                        }
                        else
                        {
                            mappedConversation.Images = new() { conversation.Image };
                        }
                    }

                    if (lastMessage.Count > 0)
                    {
                        var messageSeen = await _unitOfWork.MessageMemberReadRepository.FindOneBy(x => x.ConversationId == conversation.Id && x.UserId == requestId && x.MessageId == lastMessage.First().Id);
                        mappedConversation.LastMessage.ReadedAt = messageSeen?.CreatedAt;
                    }

                }

                response.Add(mappedConversation);
            }

            return new CursorResponse<List<GetConversationResponse>>(response, endCursor, hasNext, 0);
        }

        public async Task<IResponse> Update(string requestId, Guid conversationId, UpdateConversationRequest request)
        {
            if (request.Name == null && request.Image == null)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == conversationId &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId)
            ) ?? throw new NotFoundException("Conversation id :" + conversationId.ToString());

            if (!string.IsNullOrEmpty(request.Name))
            {
                conversation.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Image))
            {
                conversation.Image = request.Image;
            }

            await _unitOfWork.ConversationRepository.Update(conversation);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetConversationResponse>(conversation);

            var participant = await _unitOfWork.ConversationParticipantRepository.GetConversationParticipantId(conversation.Id);

            Task sendNotification = Task.Run(async () =>
            {
                await _centerHub.ChangeConversationName(participant, response);
            });


            return new DataResponse<GetConversationResponse>(response, 200, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> GetByUserId(string requestId, string userId)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId) ?? throw new NotFoundException("User id: " + userId);

            var conversation = await _unitOfWork.ConversationRepository
                .FindOneBy(x => 
                    x.Type == ConversationType.PRIVATE &&
                    x.Status == 1 &&
                    x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1) && 
                    x.ConversationParticipants.Any(cp => cp.UserId == userId && cp.Status == 1));

            if (conversation == null)
            {
                var createRes = (DataResponse<GetConversationResponse>) await this.Create(requestId, new CreateConversationRequest
                {
                    Name = "",
                    UserIds = new List<string> {userId},
                });

                return new DataResponse<GetConversationResponse>(createRes.Data, 200);
            } else
            {
                return await this.GetById(requestId, conversation.Id);
            }
        }


        public async Task<IResponse> AddParticipant(string requestId, Guid id, CreateParticipantRequest request)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == id &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1)) ?? throw new NotFoundException("Conversation id: " + id.ToString());

            var listParticipants = new List<ConversationParticipant>();

            foreach (var userId in request.UserIds)
            {
                var user = await _unitOfWork.UserRepository.GetById(userId) ?? throw new NotFoundException("User userId: " + userId);
                var checkExistParticipant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == userId);

                if (checkExistParticipant != null && checkExistParticipant.Status == 1) continue;

                if (checkExistParticipant != null && checkExistParticipant.Status == 0)
                {
                    await _unitOfWork.ConversationParticipantRepository.AddParticipantExisted(checkExistParticipant.Id);
                } 
                else
                {
                    listParticipants.Add(new()
                    {
                        ConversationId = conversation.Id,
                        UserContactName = user.GetFullName(),
                        UserId = user.Id,
                    });
                }
            }

            await _unitOfWork.ConversationParticipantRepository.AddRange(listParticipants);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();


            var conversationData = (DataResponse<GetConversationResponse>)await this.GetById(requestId, conversation.Id);
            await _centerHub.NewGroupConversation(request.UserIds, conversationData.Data);

            var response = _mapper.Map<List<GetConversationParticipantResponse>>(listParticipants);

            return new DataResponse<List<GetConversationParticipantResponse>>(response, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> GetParticipant(string requestId, Guid id, int pageSize, int pageNumber, string? searchString)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetById(id) ?? throw new NotFoundException("Conversation id: " + id.ToString());

            var checkParticipant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x =>
                x.ConversationId == id &&
                x.UserId == requestId && x.Status == 1);

            if (checkParticipant == null) return new ErrorResponse(400, Messages.BadRequest);

            Expression<Func<ConversationParticipant, bool>> filter = x => x.ConversationId == id && x.Status == 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                filter = filter.And( x => x.UserContactName.Contains(searchString));
            }

            int totalItems = await _unitOfWork.ConversationParticipantRepository.GetCount(filter);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > totalPages && totalPages > 0) return new ErrorResponse(400, Messages.OutOfPage);

            var data = await _unitOfWork.ConversationParticipantRepository.GetPaged(pageSize, pageNumber, new Expression<Func<ConversationParticipant, object>>[]
            {
                x => x.User,
            }, filter, x => x.CreatedAt, false);

            var response = _mapper.Map<List<GetConversationParticipantResponse>>(data);

            return new PagedResponse<List<GetConversationParticipantResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> GetParticipantByUserId(string requestId, Guid id, string userId)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetById(id) ?? throw new NotFoundException("Conversation id: " + id.ToString());

            var checkParticipant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x =>
                x.ConversationId == id &&
                x.UserId == requestId && x.Status == 1);

            if (checkParticipant == null) return new ErrorResponse(400, Messages.BadRequest);

            var participant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == userId, new Expression<Func<ConversationParticipant, object>>[]
            {
                x => x.User,
            }) ?? throw new NotFoundException("Participant with user id: " + userId);

            return new DataResponse<GetConversationParticipantResponse>(_mapper.Map<GetConversationParticipantResponse>(participant), 200);
        }


        public async Task<IResponse> GetParticipantById(string requestId, Guid id, Guid participantId)
        {
            var checkParticipantMember = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == requestId && x.Status == 1);
            if (checkParticipantMember == null)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }


            var response = _mapper.Map<GetConversationParticipantResponse>(
            await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.Id == participantId && x.ConversationId == id && x.Status == 1, new Expression<Func<ConversationParticipant, object>>[]
                {
                    x => x.User,
                })
            );

            return new DataResponse<GetConversationParticipantResponse>(response, 200);
        }

        public async Task<IResponse> RemoveParticipant(string requestId, Guid id, Guid participantId)
        {
            var checkParticipantMember = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == requestId && x.Status == 1);

            if (checkParticipantMember == null)
            {
                return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            var participantRemove = await _unitOfWork.ConversationParticipantRepository.GetById(participantId) ?? throw new NotFoundException("Participant id: " + participantId.ToString());

            if (participantRemove.UserId != requestId)
            {
                if (!checkParticipantMember.IsAdmin) return new ErrorResponse(400, Messages.GroupAccessDenied);

                if (participantRemove.IsSuperAdmin || (participantRemove.IsAdmin && !checkParticipantMember.IsSuperAdmin)) return new ErrorResponse(400, Messages.GroupAccessDenied);
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.ConversationParticipantRepository.Delete(participantId);
                if (participantRemove.IsSuperAdmin)
                {
                    var lastAdmin = (await _unitOfWork.ConversationParticipantRepository.GetPaged(1, 1, x => x.ConversationId == id && x.IsAdmin && !x.IsSuperAdmin, x => x.CreatedAt, false)).ToList();
                    if (lastAdmin.Count == 0)
                    {
                        var lastMember = (await _unitOfWork.ConversationParticipantRepository.GetPaged(1, 1, x => x.ConversationId == id && !x.IsAdmin && !x.IsSuperAdmin, x => x.CreatedAt, false)).ToList();

                        if (lastMember.Count == 0)
                        {
                            return new ErrorResponse(400, Messages.BadRequest);
                        }
                        else
                        {
                            lastMember[0].IsAdmin = true;
                            lastMember[0].IsSuperAdmin = true;
                            await _unitOfWork.ConversationParticipantRepository.Update(lastMember[0]);
                        }
                    }
                    else
                    {
                        lastAdmin[0].IsSuperAdmin = true;
                        await _unitOfWork.ConversationParticipantRepository.Update(lastAdmin[0]);
                    }
                }
                if (!await _unitOfWork.CommitAsync()) throw new NoDataChangeException();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Conversation service/ Remove participant" + ex);
                await _unitOfWork.RollbackAsync();
                throw new NoDataChangeException();
            }

            Task sendNotificaiton = Task.Run(async () =>
            {
                await _centerHub.DeleteConversation(new List<string>() { participantRemove.UserId }, participantRemove.ConversationId);
            });


            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> UpdateParticipant(string requestId, Guid id, Guid participantId, UpdateParticipantRequest request)
        {
            var checkParticipantMember = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == requestId && x.Status == 1);

            if (checkParticipantMember == null)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var participant = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.Id == participantId && x.ConversationId == id) ?? throw new NotFoundException("Participant id: " + participantId.ToString());

            participant.UserContactName = request.Name;

            await _unitOfWork.ConversationParticipantRepository.Update(participant);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var updatedParticipant = await _unitOfWork.ConversationParticipantRepository.GetById(participantId, new Expression<Func<ConversationParticipant, object>>[]
            {
                x => x.User
            });

            return new DataResponse<GetConversationParticipantResponse>(_mapper.Map<GetConversationParticipantResponse>(updatedParticipant), 200, Messages.CreatedSuccessfully);
        }


        public async Task<IResponse> GetAdmin(string requestId, Guid id, int pageSize, int pageNumber, string? searchString)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetById(id) ?? throw new NotFoundException("Conversation id: " + id.ToString());

            var checkAccess = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == requestId  && x.Status == 1);

            if (checkAccess == null) return new ErrorResponse(400, Messages.BadRequest);

            Expression<Func<ConversationParticipant, bool>> filter = x => x.ConversationId == conversation.Id && x.IsAdmin;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = x => x.UserContactName.Contains(searchString.Trim());
            }

            int totalItems = await _unitOfWork.ConversationParticipantRepository.GetCount(filter);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > totalPages && totalPages > 0) return new ErrorResponse(400, Messages.OutOfPage);

            var data = await _unitOfWork.ConversationParticipantRepository.GetPaged(pageSize, pageNumber, new Expression<Func<ConversationParticipant, object>>[]
            {
                x => x.User,
            }, filter, x => x.CreatedAt, false);

            var response = _mapper.Map<List<GetConversationParticipantResponse>>(data);

            return new PagedResponse<List<GetConversationParticipantResponse>>(response, totalItems, 200);
        }

        public async Task<IResponse> AddAdmin(string requestId, Guid id, CreateConversationAdminRequest request)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetById(id) ?? throw new NotFoundException("Conversation id: " + id.ToString());

            var checkAccess = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == requestId && x.IsSuperAdmin);

            if (checkAccess == null) return new ErrorResponse(400, Messages.BadRequest);

            var participant = await _unitOfWork.ConversationParticipantRepository.GetById(request.ParticipantId);
            if (participant.IsAdmin) return new ErrorResponse(400, Messages.ParticipantAdminExisted);

            participant.IsAdmin = true;
            await _unitOfWork.ConversationParticipantRepository.Update(participant);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetConversationParticipantResponse>(await _unitOfWork.ConversationParticipantRepository.GetById(id, new Expression<Func<ConversationParticipant, object>>[]
            {
                x => x.User
            }));

            return new DataResponse<GetConversationParticipantResponse>(response, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> RemoveAdmin(string requestId, Guid id, Guid participantId)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetById(id) ?? throw new NotFoundException("Conversation id: " + id.ToString());

            var checkAccess = await _unitOfWork.ConversationParticipantRepository.FindOneBy(x => x.ConversationId == id && x.UserId == requestId && x.IsSuperAdmin);

            if (checkAccess == null) return new ErrorResponse(400, Messages.BadRequest);

            var participant = await _unitOfWork.ConversationParticipantRepository.GetById(participantId);
            if (!participant.IsAdmin) return new ErrorResponse(400, Messages.ParticipantAdminNotExisted);

            participant.IsAdmin = false;
            await _unitOfWork.ConversationParticipantRepository.Update(participant);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetConversationParticipantResponse>(await _unitOfWork.ConversationParticipantRepository.GetById(id, new Expression<Func<ConversationParticipant, object>>[]
            {
                x => x.User
            }));

            return new DataResponse<GetConversationParticipantResponse>(response, 201, Messages.CreatedSuccessfully);
        }


        public async Task<IResponse> GetMessage(string requestId, Guid id, int pageSize, DateTime? cursor, string? searchString)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == id &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1)) ?? throw new NotFoundException("Converstaion id: " + id.ToString());

            Expression<Func<Message, bool>> filter = x => x.ConversationId == id;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = filter.And(x => x.Content.Contains(searchString.Trim()));
            }

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.MessageRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Message, object>>[]
            {
                x => x.User,
                x => x.Participant
            })).ToList();

            bool hasNext = false;
            if (data.Count > pageSize)
            {
                hasNext = true;
                data.RemoveAt(data.Count - 1);
            }

            DateTime? endCursor = hasNext ? data.LastOrDefault()?.CreatedAt : null;

            var response = _mapper.Map<List<GetMessageResponse>>(data);

            return new CursorResponse<List<GetMessageResponse>>(response, endCursor, hasNext, 0);
        }

        public async Task<IResponse> GetMessageById(string requestId, Guid id, Guid messageId)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                x.Id == id &&
                x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1)) ?? throw new NotFoundException("Converstaion id: " + id.ToString());

            var message = await _unitOfWork.MessageRepository.FindOneBy(x => x.Id == messageId && x.ConversationId == id, new Expression<Func<Message, object>>[]
            {
                x => x.User,
                x => x.Participant,
            }) ?? throw new NotFoundException("Message id: " + messageId.ToString());

            return new DataResponse<GetMessageResponse>(_mapper.Map<GetMessageResponse>(message), 200);
        }

        public async Task<IResponse> CreateMessage(string requestId, Guid id, CreateMessageOnConversationRequest request)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                           x.Id == id) ?? throw new NotFoundException("Converstaion id: " + id.ToString());

            var participant = await _unitOfWork.ConversationParticipantRepository
                .FindOneBy(x => x.ConversationId == conversation.Id && x.UserId == requestId && x.Status == 1) ?? throw new NotFoundException("Participant in group");

            var newMessage = new Message
            {
                Content = request.Content,
                ConversationId = conversation.Id,
                MessageType = MessageType.NORMAL,
                UserId = requestId,
                ParticipantId = participant.Id,
            };

            await _unitOfWork.MessageRepository.Add(newMessage);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetMessageResponse>(await _unitOfWork.MessageRepository.GetById(newMessage.Id, new Expression<Func<Message, object>>[] { x => x.User,x => x.Participant }));

            var participantId = await _unitOfWork.ConversationParticipantRepository.GetConversationParticipantId(conversation.Id);

            Task sendNotificaiton = Task.Run(async () =>
            {
                await _centerHub.NewMessage(participantId, response);
            });

            return new DataResponse<GetMessageResponse>(response, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> UnsendMessage(string requestId, Guid id, Guid messageId)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                           x.Id == id &&
                           x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1)) ?? throw new NotFoundException("Converstaion id: " + id.ToString());

            var message = await _unitOfWork.MessageRepository.FindOneBy(x => x.Id == messageId && x.ConversationId == id);
            if (message.UserId != requestId) return new ErrorResponse(400, Messages.BadRequest);

            await _unitOfWork.MessageRepository.RevokeMessage(messageId);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            return new DataResponse<GetMessageResponse>(_mapper.Map<GetMessageResponse>(message), 200, Messages.DeletedSuccessfully);
        }

        public async Task<IResponse> SeenMessage(string requestId, Guid id, Guid messageId)
        {
            var conversation = await _unitOfWork.ConversationRepository.FindOneBy(x =>
                           x.Id == id &&
                           x.ConversationParticipants.Any(cp => cp.UserId == requestId && cp.Status == 1)) ?? throw new NotFoundException("Converstaion id: " + id.ToString());

            if (conversation.Type == ConversationType.PRIVATE)
            {
                var message = await _unitOfWork.MessageRepository.FindOneBy(x => x.Id == messageId && x.ConversationId == id);
                if (message.UserId == requestId) return new ErrorResponse(400, Messages.BadRequest);

                await _unitOfWork.MessageRepository.SeenMessage(messageId);
            } else
            {
                var checkSeen = await _unitOfWork.MessageMemberReadRepository.FindOneBy(x => x.ConversationId == id && x.MessageId == messageId && x.UserId == requestId);
                if (checkSeen != null) return new ErrorResponse(400, Messages.SeenMessageExist);

                var memberSeen = new MessageMemberReaded
                {
                    ConversationId = id,
                    MessageId = messageId,
                    UserId = requestId,
                };

                await _unitOfWork.MessageMemberReadRepository.Add(memberSeen);
            }
            
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            return new SuccessResponse(Messages.MessageSeen, 200);
        }

    }
}
