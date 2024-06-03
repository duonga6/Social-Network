using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Concrete
{
    public class PostService : BaseServices<PostService>, IPostService
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IPostCommentService _postCommentService;
        private readonly IFriendshipService _friendshipService;
        private readonly TimeLimitService _timeLimitService;
        private readonly BadWordService _badWordService;

        public PostService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ILogger<PostService> logger,
                           INotificationService notificationService,
                           UserManager<User> userManager,
                           IPostCommentService postCommentService,
                           IFriendshipService friendshipService,
                           TimeLimitService timeLimitService,
                           BadWordService badWordService) : base(unitOfWork, mapper, logger)
        {
            _notificationService = notificationService;
            _userManager = userManager;
            _postCommentService = postCommentService;
            _friendshipService = friendshipService;
            _timeLimitService = timeLimitService;
            _badWordService = badWordService;
        }

        #region Post
        public async Task<IResponse> GetAll(string requestUserId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Post, bool>> filter = x => x.Status == 1;

            filter = filter.And(x => 
                x.Access == PostAccess.ONLY_FRIEND && _unitOfWork.FriendshipRepository.GetQueryable().Any(f => (f.RequestUserId == requestUserId && f.TargetUserId == x.AuthorId || f.TargetUserId == requestUserId && f.RequestUserId == x.AuthorId) && f.FriendshipTypeId == (int)FriendshipEnum.Accepted)
            || x.Access == PostAccess.PUBLIC
            || x.AuthorId == requestUserId && x.GroupId == null
            || x.Group.GroupMembers.Any(gm => gm.UserId == requestUserId)
            );

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x =>
                    x.Content.Contains(searchString)    
                );
            }

            int totalItems = await _unitOfWork.PostRepository.GetCount(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var posts = await _unitOfWork.PostRepository.GetPaged(pageSize, pageNumber,
                new Expression<Func<Post, object>>[] {
                    x => x.Author,
                    x => x.PostMedias,
                    x => x.Group,
                    x => x.SharePost.Author,
                    x => x.SharePost.PostMedias,
                    x => x.SharePost.Group,
                }
                , filter, x => x.CreatedAt);

            var postsResponse = _mapper.Map<List<GetPostResponse>>(posts);

            return new PagedResponse<List<GetPostResponse>>(postsResponse, totalItems, 200);
        }

        public async Task<IResponse> GetCursor(string requestUserId, int pageSize, DateTime? cursor, string? searchString)
        {
            Expression<Func<Post, bool>> filter = x => x.Status == 1;

            filter = filter.And(x =>
                x.Access == PostAccess.ONLY_FRIEND && _unitOfWork.FriendshipRepository.GetQueryable().Any(f => (f.RequestUserId == requestUserId && f.TargetUserId == x.AuthorId || f.TargetUserId == requestUserId && f.RequestUserId == x.AuthorId) && f.FriendshipTypeId == (int)FriendshipEnum.Accepted)
            || x.Access == PostAccess.PUBLIC
            || x.AuthorId == requestUserId
            || x.Access == PostAccess.GROUP && x.Group.GroupMembers.Any(gm => gm.UserId == requestUserId)
            );

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x =>
                    x.Content.Contains(searchString)
                );
            }

            int totalItems = await _unitOfWork.PostRepository.GetCount(filter);

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias,
                x => x.Group,
                x => x.SharePost.Author,
                x => x.SharePost.PostMedias,
                x => x.SharePost.Group,
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

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new CursorResponse<List<GetPostResponse>>(response, endCursor, hasNext, totalItems);
        }


        public async Task<IResponse> SearchCursor(string requestUserId, int pageSize, DateTime? cursor, string? searchString)
        {
            Expression<Func<Post, bool>> filter = x => x.Status == 1;

            filter = filter.And(x =>
                x.Access == PostAccess.ONLY_FRIEND && _unitOfWork.FriendshipRepository.GetQueryable().Any(f => (f.RequestUserId == requestUserId && f.TargetUserId == x.AuthorId || f.TargetUserId == requestUserId && f.RequestUserId == x.AuthorId) && f.FriendshipTypeId == (int)FriendshipEnum.Accepted)
            || x.Access == PostAccess.PUBLIC
            || x.AuthorId == requestUserId
            || x.Access == PostAccess.GROUP && x.Group.IsPublic
            );

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(x =>
                    x.Content.Contains(searchString)
                );
            }

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias,
                x => x.Group,
                x => x.SharePost.Author,
                x => x.SharePost.PostMedias,
                x => x.SharePost.Group,
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

            var response = _mapper.Map<List<GetPostResponse>>(data);

            return new CursorResponse<List<GetPostResponse>>(response, endCursor, hasNext, 0);
        }

        public async Task<IResponse> GetById(string requestingUserId, Guid id)
        {
            var post = await _unitOfWork.PostRepository.GetById(id);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await _friendshipService.IsFriend(requestingUserId, post.AuthorId))
            {
                return new ErrorResponse(403, Messages.NotFriend);
            }

            return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(post), 200);
        }
     
        public async Task<IResponse> Create(string requestUserId, CreatePostRequest request)
        {
            if (string.IsNullOrEmpty(request.Content) && request.PostMedias?.Count == 0 && request.SharePostId == null)
            {
                return new ErrorResponse(400, Messages.PostEmpty);
            }

            if (_badWordService.CheckBadWord(request.Content ?? ""))
            {
                return new ErrorResponse(400, Messages.BadWordContent);
            }

            if (!_timeLimitService.CheckLimitCreatePost(requestUserId))
            {
                return new ErrorResponse(400, Messages.LimitTimePost(_timeLimitService.TimeLimitPost));
            }

            if (request.SharePostId != null)
            {
                var sharePost = await _unitOfWork.PostRepository.GetById(request.SharePostId.Value, new Expression<Func<Post, object>>[] {x => x.Group, x => x.Author}) ?? throw new NotFoundException("Post to share id: " + request.SharePostId.ToString());
                // Check group
                if (sharePost.GroupId != null && !sharePost.Group.IsPublic)
                {
                    var checkMember = await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.UserId == requestUserId && x.GroupId == sharePost.GroupId);
                    if (checkMember == null) return new ErrorResponse(400, Messages.GroupAccessDenied);
                }

                // Check access post
                if (sharePost.Access == PostAccess.ONLY_ME)
                {
                    return new ErrorResponse(400, Messages.PostAccessDenied(sharePost.Id.ToString()));
                } 
                else if (sharePost.Access == PostAccess.ONLY_FRIEND)
                {
                    var checkFriend = await _unitOfWork.FriendshipRepository.FindOneBy(x => (x.RequestUserId == requestUserId && x.TargetUserId == sharePost.AuthorId || x.RequestUserId == sharePost.AuthorId && x.TargetUserId == requestUserId) && x.Status == 1);
                    if (checkFriend == null) return new ErrorResponse(400, Messages.NotFriend);
                }
                
                // Check media: post must not contain media
                if (request.PostMedias?.Count > 0)
                {
                    return new ErrorResponse(400, Messages.SharePostMustNotHaveMedia);
                }
            }

            // Check group
            if (request.GroupId != null)
            {
                var group = await _unitOfWork.GroupRepository.GetById(request.GroupId.Value, new Expression<Func<Group, object>>[] 
                { 
                    x => x.GroupMembers.Where(x => x.UserId == requestUserId),
                }) ?? throw new NotFoundException("Group id: " + request.GroupId.ToString());

                if (group.GroupMembers.Count == 0)
                {
                    return new ErrorResponse(400, Messages.GroupAccessDenied);
                }
            }

            var addEntity = _mapper.Map<Post>(request);
            //foreach (var media in addEntity.PostMedias)
            //{
            //    media.UserId = requestUserId;
            //}
            addEntity.AuthorId = requestUserId;

            await _unitOfWork.PostRepository.Add(addEntity);

            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var response = _mapper.Map<GetPostResponse>(await _unitOfWork.PostRepository.GetById(addEntity.Id, new Expression<Func<Post, object>>[] 
            {
                x => x.Author,
                x => x.PostMedias,
                x => x.Group,
                x => x.SharePost.Author,
                x => x.SharePost.PostMedias,
                x => x.SharePost.Group,
            }));

            if (request.GroupId == null)
            {
                await _notificationService.CreateNotification(addEntity.AuthorId, "", NotificationEnum.CREATE_POST, response);
            }

            return new DataResponse<GetPostResponse>(response, 201, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> CreateShare(string requestUserId, CreateSharePostRequest request)
        {
            var postShare = await _unitOfWork.PostRepository.GetById(request.SharePostId);
            if (postShare == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post share"));
            }

            var addEntity = _mapper.Map<Post>(request);
            addEntity.AuthorId = requestUserId;

            await _unitOfWork.PostRepository.Add(addEntity);
            
            if (!await _unitOfWork.CompleteAsync())
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var addedEntity = await _unitOfWork.PostRepository.GetById(addEntity.Id);

            var response = _mapper.Map<GetPostResponse>(addedEntity);

            await _notificationService.CreateNotification(requestUserId, postShare.AuthorId, NotificationEnum.SHARE_POST, response);

            return new DataResponse<GetPostResponse>(response, 200, Messages.CreatedSuccessfully);
        }

        public async Task<IResponse> Update(string requestingUserId, Guid id, UpdatePostRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetById(id) ?? throw new NotFoundException("Post id: " + id.ToString());

            if (!await CheckPermission(requestingUserId, post.AuthorId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            _mapper.Map(request, post);

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (request.MediasDelete != null)
                    foreach (var item in request.MediasDelete)
                    {
                        await _unitOfWork.PostMediaRepository.Delete(item);
                    }

                if (request.MediasUpdate != null)
                    foreach (var item in request.MediasUpdate)
                    {
                        var updateImage = _mapper.Map<PostMedia>(item);
                        await _unitOfWork.PostMediaRepository.Update(updateImage);
                    }

                if (request.MediasAdd != null)
                    foreach (var item in request.MediasAdd)
                    {
                        var addImage = _mapper.Map<PostMedia>(item);
                        addImage.PostId = post.Id;
                        addImage.UserId = requestingUserId;
                        await _unitOfWork.PostMediaRepository.Add(addImage);
                    }

                await _unitOfWork.PostRepository.Update(post);

                if (!await _unitOfWork.CommitAsync()) throw new NoDataChangeException();

                var updatedEntity = await _unitOfWork.PostRepository.GetById(id);

                return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(updatedEntity), 200, Messages.UpdatedSuccessfully);
            } catch (Exception ex)
            {
                _logger.LogError("Error PostService_Create: " + ex);
                await _unitOfWork.RollbackAsync();
                throw new NoDataChangeException();
            }

            

        }
     
        public async Task<IResponse> Delete(string requestingUserId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckPermission(requestingUserId, post.AuthorId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            await _unitOfWork.PostRepository.Delete(post.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }
     
        private async Task<bool> CheckPermission(string requestingUserId, string targetUserId)
        {
            // Is owner
            if (requestingUserId == targetUserId)
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(new User
            {
                Id = requestingUserId
            }, RoleName.Administrator);
        }

        #endregion

        #region Post Comment
        public async Task<IResponse> GetComments(string requestUserId, Guid postId, string? searchString, int pageSize, int pageNumber)
        {
            return await _postCommentService.GetAll(requestUserId, searchString, pageSize, pageNumber, postId);
        }
        
        public async Task<IResponse> GetCommentById(string requestUserId, Guid postId, Guid commentId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null) return new ErrorResponse(404, Messages.NotFound());

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            var result = await _unitOfWork.PostCommentRepository.FindOneBy(x => x.PostId == postId && x.Id == commentId && x.Status == 1);
            if (result == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(result), 200);
        }
        
        public async Task<IResponse> CreateComment(string requestUserId, Guid postId, CreatePostCommentRequest request)
        {
            if (!await CheckPermission(requestUserId, postId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            var post = await _unitOfWork.PostRepository.GetById(postId);

            var addEntity = _mapper.Map<PostComment>(request);
            addEntity.PostId = postId;
            addEntity.UserId = requestUserId;

            await _unitOfWork.PostCommentRepository.Add(addEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var response = _mapper.Map<GetPostCommentResponse>(addEntity);

            await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.POST_COMMENT, response);

            return new DataResponse<GetPostCommentResponse>(response, 200, Messages.CreatedSuccessfully);

        }
        
        public async Task<IResponse> DeleteComment(string requestUserId, Guid postId, Guid commentId)
        {
            var comment = await _unitOfWork.PostCommentRepository.GetById(commentId, new Expression<Func<PostComment, object>>[]
            {
                x => x.Post
            }) ?? throw new NotFoundException("Comment id: " + commentId.ToString());

            if (comment.UserId != requestUserId && comment.Post.AuthorId != requestUserId)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            await _unitOfWork.PostCommentRepository.Delete(comment.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);

        }
        
        public async Task<IResponse> UpdateComment(string requestUserId, Guid postId, Guid commentId, UpdatePostCommentRequest request)
        {
            var entity = await _unitOfWork.PostCommentRepository.GetById(commentId);
            if (entity == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (!await CheckOwnerOrAdmin(requestUserId, entity.UserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            entity.Content = request.Content;

            await _unitOfWork.PostCommentRepository.Update(entity);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            return new DataResponse<GetPostCommentResponse>(_mapper.Map<GetPostCommentResponse>(entity), 200);
        }

        private async Task<bool> CheckPermissionWithFriendAccess(string requestingUserId, string targetUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestingUserId);
            var targetUser = await _userManager.FindByIdAsync(targetUserId);

            if (requestUser == null || targetUser == null)
            {
                return false;
            }

            // Is owner
            if (requestingUserId == targetUserId)
            {
                return true;
            }

            // Is friend
            if (await _friendshipService.IsFriend(requestingUserId, targetUserId))
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }
        
        private async Task<bool> CheckOwnerOrAdmin(string requestingUserId, string targetUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestingUserId);
            var targetUser = await _userManager.FindByIdAsync(targetUserId);

            if (requestUser == null || targetUser == null)
            {
                return false;
            }

            // Is owner
            if (requestingUserId == targetUserId)
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }

        #endregion

        #region Post Reaction

        public async Task<IResponse> GetAllReactions(string requestUserId, Guid postId, int pageSize, int pageNumber)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);

            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }    

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }

            int totalItems = await _unitOfWork.PostReactionRepository.GetCount(x => x.PostId == postId);
            int pageCount = (int)Math.Ceiling((double) totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var reactions = await _unitOfWork.PostReactionRepository.GetPaged(pageSize, pageNumber, x => x.PostId == postId, x => x.CreatedAt);

            return new PagedResponse<List<GetPostReactionResponses>>(_mapper.Map<List<GetPostReactionResponses>>(reactions), totalItems, 200);
        }
       
        public async Task<IResponse> GetReactionById(string requestUserId, Guid postId, int reactionId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            if (!await CheckPermissionWithFriendAccess(requestUserId, post.AuthorId))
            {
                return new ErrorResponse(400, Messages.NotFriend);
            }    

            var reaction = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId);

            if (reaction == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Reaction"));
            } 

            return new DataResponse<GetPostReactionResponses>(_mapper.Map<GetPostReactionResponses>(reaction), 200);
                
        }
       
        public async Task<IResponse> CreateReaction(string requestUserId, Guid postId, CreatePostReactionRequest request)
        {
            if (!await CheckPermission(requestUserId, postId)) return new ErrorResponse(400, Messages.PostAccessDenied());

            var checkExist = await _unitOfWork.PostReactionRepository.FindOneBy(x => x.PostId == postId && x.UserId == requestUserId);
            if (checkExist != null)
            {
                return new ErrorResponse(400, Messages.PostReactionExist);
            }

            var post = await _unitOfWork.PostRepository.GetById(postId);

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = requestUserId;
            entity.PostId = postId;

            await _unitOfWork.PostReactionRepository.Add(entity);

            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.AddError);
            }

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId);
            var response = _mapper.Map<GetPostReactionResponses>(entityAdded);
            await _notificationService.CreateNotification(requestUserId, post.AuthorId, NotificationEnum.POST_REACTION, response);

            return new DataResponse<GetPostReactionResponses>(response, 201, Messages.CreatedSuccessfully);
        }
       
        public async Task<IResponse> UpdateReaction(string requestUserId, Guid postId, int reactionId, CreatePostReactionRequest request)
        {
            var checkExits = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId);
            if (checkExits == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            var entity = _mapper.Map<PostReaction>(request);
            entity.UserId = requestUserId;
            entity.PostId = postId;

            await _unitOfWork.PostReactionRepository.Update(entity);

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var entityAdded = await _unitOfWork.PostReactionRepository.GetById(postId, requestUserId);

            return new DataResponse<GetPostReactionResponses>(_mapper.Map<GetPostReactionResponses>(entityAdded), 200, Messages.UpdatedSuccessfully);
        }
     
        public async Task<IResponse> DeleteReaction(string requestUserId, Guid postId, int reactionId)
        {
            var reaction = await _unitOfWork.PostReactionRepository
                .FindOneBy(x => x.PostId == postId && x.ReactionId == reactionId && x.UserId == requestUserId) ?? throw new NotFoundException("Reaction");

            await _unitOfWork.PostReactionRepository.Delete(reaction.Id);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<bool> CheckPermission(string userId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId, new Expression<Func<Post, object>>[]
            {
                x => x.Group
            }) ?? throw new NotFoundException("Post");

            if (userId == post.AuthorId) return true;

            switch (post.Access)
            {
                case PostAccess.ONLY_ME:
                    return post.AuthorId == userId;
                case PostAccess.ONLY_FRIEND:
                    return await _unitOfWork.FriendshipRepository.ExistFriendShip(userId, post.AuthorId);
                case PostAccess.PUBLIC:
                    return true;
                case PostAccess.GROUP:
                    if (post.Group.IsPublic) return true;
                    return await _unitOfWork.GroupMemberRepository.FindOneBy(x => x.GroupId == post.GroupId && x.UserId == userId) != null;
                default:
                    return false;
            }
        }

        public async Task<IResponse> StatsReport(string requestUserId)
        {
            //var user = await _userManager.FindByIdAsync(requestUserId) ?? throw new NotFoundException("User id: " + requestUserId);

            //if (!await _userManager.IsInRoleAsync(user, RoleName.Administrator)) return new ErrorResponse(401, Messages.UnAuthorized);

            var today = DateTime.UtcNow;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var startOfMonth = new DateTime(today.Year, today.Month, 1);

            int postPerDay = await _unitOfWork.PostRepository.GetCount(x => x.Status == 1 && x.CreatedAt > today.Date);
            int postPerWeek = await _unitOfWork.PostRepository.GetCount(x => x.Status == 1 && x.CreatedAt > startOfWeek);
            int postPerMonth = await _unitOfWork.PostRepository.GetCount(x => x.Status == 1 && x.CreatedAt > startOfMonth);
            int totalPost = await _unitOfWork.PostRepository.GetCount(x => x.Status == 1);

            var response = new StatsPostResponse
            {
                PostPerDay = postPerDay,
                PostPerWeek = postPerWeek,
                PostPerMonth = postPerMonth,
                TotalPost = totalPost,
            };

            return new DataResponse<StatsPostResponse>(response, 200);
        }


        #endregion

    }
}
