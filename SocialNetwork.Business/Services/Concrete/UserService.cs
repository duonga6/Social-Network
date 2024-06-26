﻿using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.DTOs.Utilities.Requests;
using SocialNetwork.Business.Exceptions;
using SocialNetwork.Business.Helper;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;
using System.Text;
using System.Text.Encodings.Web;

namespace SocialNetwork.Business.Services.Concrete
{
    public class UserService : BaseServices<UserService>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly IPostService _postService;
        private readonly INotificationService _notificationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMailService _mailService;
        private readonly IHubControl _hubControl;
        private readonly IHostingEnvironment _env;

        public UserService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ILogger<UserService> logger,
                           UserManager<User> userManager,
                           ITokenService tokenService,
                           SignInManager<User> signInManager,
                           IPostService postService,
                           INotificationService notificationService,
                           RoleManager<IdentityRole> roleManager,
                           IMailService mailService,
                           IHostingEnvironment env,
                           IHubControl hubControl) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _postService = postService;
            _notificationService = notificationService;
            _roleManager = roleManager;
            _mailService = mailService;
            _env = env;
            _hubControl = hubControl;
        }

        #region Auth + User info

        public async Task<IResponse> GetAll(string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<User, bool>> filter = x => x.Status == 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = filter.And( x => (x.FirstName + " " + x.LastName).Contains(searchString.Trim()));
            } 

            int totalItems = await _unitOfWork.UserRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);
            if (pageNumber > pageCount && pageCount > 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var users = await _unitOfWork.UserRepository.GetPaged(pageSize, pageNumber, filter, x => x.FirstName, false);
            return new PagedResponse<List<GetUserResponse>>(_mapper.Map<List<GetUserResponse>>(users), totalItems, 200);
        }

        public async Task<IResponse> Register(RegistrationRequest request, string ipaddress)
        {
            if (!await _unitOfWork.IPLimitRepository.CheckIPRegistered(ipaddress))
            {
                return new ErrorResponse(400, Messages.IPLimitRegister);
            }

            var checkExistUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkExistUser != null && checkExistUser.Status != 0)
            {
                return new ErrorResponse(400, Messages.EmailUsed);
            }

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            string host = _env.IsDevelopment() ? "http://localhost:8080" : "https://facebook.duonga6.top";

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var url = HtmlEncoder.Default.Encode(host + $"/confirm-email?code={code}&email={user.Email}");

            var mail = new SendMailRequest
            {
                ToEmail = user.Email,
                Subject = "Xác thực tài khoản",
                HtmlBody = $"<html><body>Bạn đã đăng ký thành công tài khoản trên FBook. Hãy <a href='{url}'>click vào đây</a> để xác thực tài khoản của bạn</body></html>"
            };

            await _mailService.SendMailWithoutResponseAsync(mail);

            return new SuccessResponse(Messages.RegistrationSuccessfully, 201);
        }

        public async Task<IResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.IncorrectEP);
            }    

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);
            if (!signInResult.Succeeded)
            {
                return new ErrorResponse(400, signInResult.GetErrors());
            }

            var token = await _tokenService.CreateToken(user);

            var response = _mapper.Map<UserWithTokenResponse>(user);
            response.Token = token;

            return new DataResponse<UserWithTokenResponse>(response, 200, Messages.LoginSuccessfully);
        }

        public async Task<IResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            string host = _env.IsDevelopment() ? "http://localhost:8080" : "https://facebook.duonga6.top"; 

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var url = HtmlEncoder.Default.Encode(host + $"/reset-password?code={code}&email={user.Email}");

            var mail = new SendMailRequest
            {
                ToEmail = user.Email,
                Subject = "Đặt lại mật khẩu",
                HtmlBody = $"<html><body>Bạn đã yêu cầu đặt lại mật khẩu. Hãy <a href='{url}'>click vào đây</a> để đặt lại mật khẩu của bạn</body></html>"
            };

            await _mailService.SendMailWithoutResponseAsync(mail);

            return new DataResponse<ForgotPasswordCodeResponse>(new ForgotPasswordCodeResponse(code), 200, Messages.GetCodeResetPassword);
        }

        public async Task<IResponse> ResetPassword(ResetPasswordRequest request)
        { 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }    

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));

            var result = await _userManager.ResetPasswordAsync(user, code, request.Password);

            if (result.Succeeded)
            {
                var response = _mapper.Map<UserWithTokenResponse>(user);
                var token = await _tokenService.CreateToken(user);
                response.Token = token;
                return new DataResponse<UserWithTokenResponse>(response, 200, Messages.ResetPasswordSuccessfully);
            }   
            else
            {
                return new ErrorResponse(400, result.GetErrors());
            }    

        }

        public async Task<IResponse> GetById(string id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id) ?? throw new NotFoundException("User id : " + id);

            var response = _mapper.Map<GetUserResponse>(user);
            response.Roles = (await _userManager.GetRolesAsync(user)).ToArray();

            return new DataResponse<GetUserResponse>(response, 200);
        }

        public async Task<IResponse> UpdateInfo(string loggedUserId, string requestUserId, UpdateUserInfoRequest request)
        {
            if(!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var updateUser = _mapper.Map<User>(request);
            updateUser.Id = requestUserId;

            await _unitOfWork.UserRepository.Update(updateUser);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var userUpdated = await _userManager.FindByIdAsync(requestUserId);

            return new DataResponse<GetUserResponse>(_mapper.Map<GetUserResponse>(userUpdated), 200, Messages.UpdatedSuccessfully);

        }

        public async Task<IResponse> DeleteUser(string loggedUserId, string requestUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var user = await _userManager.FindByIdAsync(requestUserId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.UserRepository.Delete(user.Id);

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        public async Task<IResponse> ChangePassword(string loggedUserId, ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(loggedUserId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            if (request.Email != null && request.Email != user.Email)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }    

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new SuccessResponse(Messages.ChangePasswordSuccessfully, 200);
        }

        public async Task<IResponse> AddRoles(string userId, AddRolesToUserRequest request)
        {
            if (request.Roles == null || request.Roles.Count == 0)
            {
                return new ErrorResponse(400, Messages.RoleEmpty);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            if (!(await CheckRoleValid(request.Roles)))
            {
                return new ErrorResponse(400, Messages.InvalidRole);
            }

            var result = await _userManager.AddToRolesAsync(user, request.Roles);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new SuccessResponse(Messages.AddRoleToUserSuccess, 201);
        }

        public async Task<IResponse> GetRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new DataResponse<IList<string>>(roles, 200);
        }

        public async Task<IResponse> RenewToken(RenewTokenRequest token)
        {
            var result = await _tokenService.RenewToken(token);
            if (result.Token == null)
            {
                return new ErrorResponse(400, result.Message);
            }    

            return new DataResponse<Token>(result.Token, 200, result.Message);
        }

        public async Task<IResponse> UpdateRole(string userId, AddRolesToUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }
            
            if (!(await CheckRoleValid(request.Roles)))
            {
                return new ErrorResponse(400, Messages.InvalidRole);
            }

            var newRoles = request.Roles;
            var oldRoles = await _userManager.GetRolesAsync(user);
            var addRoles = newRoles.Where(r => !oldRoles.Contains(r)).ToList();
            var removeRoles = oldRoles.Where(r => !newRoles.Contains(r)).ToList();

            await _userManager.RemoveFromRolesAsync(user, removeRoles);
            await _userManager.AddToRolesAsync(user, addRoles);

            return new SuccessResponse(Messages.UpdatedSuccessfully, 200);
        }
        
        public async Task<IResponse> ConfirmEmail(ConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                return new ErrorResponse(404, result.GetErrors());
            }
            await _userManager.AddToRoleAsync(user, RoleName.User);

            var token = await _tokenService.CreateToken(user);

            var response = _mapper.Map<UserWithTokenResponse>(user);
            response.Token = token;

            return new DataResponse<UserWithTokenResponse>(response, 200);
        }

        public async Task<IResponse> ResendConfirmEmail(ResendConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var resultCode = new ResendConfirmEmailResponse(code);

            return new DataResponse<ResendConfirmEmailResponse>(resultCode, 200, Messages.GetCodeConfirmEmailSuccess);
        }

        public async Task<IResponse> GetPhoto(string requestUserId, string targetUserId, int pageSize, int pageNumber)
        {
            var user = await _unitOfWork.UserRepository.GetById(targetUserId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            Expression<Func<PostMedia, bool>> filter = x => x.MediaTypeId == (int)MediaTypeEnum.Image && x.UserId == targetUserId && x.Post.GroupId == null;

            int totalItems = await _unitOfWork.PostMediaRepository.GetCount(filter);

            int pageCount = (int)Math.Ceiling((decimal)totalItems / pageSize);


            if (pageNumber > pageCount && pageCount > 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }

            var postMedias = await _unitOfWork.PostMediaRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);

            var result = _mapper.Map<List<GetPostMediaResponse>>(postMedias);

            return new PagedResponse<List<GetPostMediaResponse>>(result, totalItems, 200);
        }

        private async Task<bool> CheckAccess(string loggedUserId, string requestUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

            if (requestUser == null || loggedUser == null)
            {
                return false;
            }

            if (requestUserId == loggedUserId)
            {
                return true;
            }

            return await _userManager.IsInRoleAsync(loggedUser, RoleName.Administrator);
        }

        private async Task<bool> CheckRoleValid(List<string> inputRoles)
        {
            var allRoles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
            if (inputRoles.Any(r => !allRoles.Contains(r)))
            {
                return false;
            }

            return true;
        }

        public async Task<IResponse> FindByEmail(string requestId, string email)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new NotFoundException("User with email: " + email);

            return new DataResponse<BasicUserResponse>(_mapper.Map<BasicUserResponse>(user), 200);
        }

        #endregion

        #region Post
        public async Task<IResponse> CreatePost(string loggedUserId , string requestUserId, CreatePostRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }
            return await _postService.Create(requestUserId, request);
        }

        public async Task<IResponse> GetPostById(string loggedUserId, string requestUserId, Guid postId)
        {
            if (!await CheckAccessPost(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }    

            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null || post.AuthorId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(post), 200);
        }

        public async Task<IResponse> GetPostCursor(string loggedUserId, string requestUserId, string? searchString, int pageSize, DateTime? cursor)
        {
            var checkUser = await _unitOfWork.UserRepository.GetById(requestUserId) ?? throw new NotFoundException("User id: " + requestUserId);

            Expression<Func<Post, bool>> filter = x => x.Status == 1 && x.AuthorId == requestUserId && x.GroupId == null;

            if (loggedUserId != requestUserId)
            {
                if (await _unitOfWork.FriendshipRepository.FindOneBy(x => (x.RequestUserId == loggedUserId && x.TargetUserId == requestUserId || x.TargetUserId == loggedUserId && x.RequestUserId == requestUserId) && x.Status == 1) == null)
                {
                    filter = filter.And(x => x.Access == PostAccess.PUBLIC);
                } 
                else
                {
                    filter = filter.And(x => x.Access != PostAccess.ONLY_ME);
                }
            }

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                filter = filter.And(x => x.Content.Contains(searchString));
            }

            if (cursor != null)
            {
                filter = filter.And(x => x.CreatedAt < cursor);
            }

            var data = (await _unitOfWork.PostRepository.GetCursorPaged(pageSize + 1, filter, x => x.CreatedAt, new Expression<Func<Post, object>>[]
            {
                x => x.Author,
                x => x.PostMedias,
                x => x.SharePost.PostMedias,
                x => x.SharePost.Author,
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


        public async Task<IResponse> GetPostByUser(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<Post, bool>> filter = x => x.Status == 1 && x.AuthorId == requestUserId && x.GroupId == null;

            if (searchString != null)
            {
                filter = filter.And(x => x.Content.Contains(searchString));
            }

            int totalItems = await _unitOfWork.PostRepository.GetCount(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var posts = await _unitOfWork.PostRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            return new PagedResponse<List<GetPostResponse>>(_mapper.Map<List<GetPostResponse>>(posts), totalItems, 200);
        }

        public async Task<IResponse> UpdatePost(string loggedUserId, string requestUserId, Guid postId, UpdatePostRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _postService.Update(requestUserId, postId, request);
        }

        public async Task<IResponse> DeletePost(string loggedUserId, string requestUserId, Guid postId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var post = await _unitOfWork.PostRepository.FindBy(p => p.Id == postId && p.AuthorId == requestUserId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            await _unitOfWork.PostRepository.Delete(postId);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 200);
        }

        private async Task<bool> CheckAccessPost(string loggedUserId, string requestUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

            if (requestUser == null || loggedUser == null) return false;

            if (requestUserId == loggedUserId)
            {
                return true;
            }

            if (!await _userManager.IsInRoleAsync(loggedUser, RoleName.Administrator))
            {
                return true;
            }

            return await IsFriend(loggedUserId, requestUserId);
        }

        #endregion

        #region Notification

        public async Task<IResponse> GetNotifications(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.GetNotifications(requestUserId, searchString, pageSize, pageNumber);
        }

        public async Task<IResponse> GetNotificationsById(string loggedUserId, string requestUserId, Guid id)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.GetById(requestUserId, id);
        }

        public async Task<IResponse> SeenNotifications(string loggedUserId, string requestUserId, Guid id)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.SeenNotification(requestUserId, id);
        }

        #endregion

        #region Friend

        public async Task<IResponse> GetFriends(string requestUserId, string targetUserId, int pageSize, int pageNumber, string? searchString)
        {
            Expression<Func<Friendship, bool>> filter;
            if (searchString != null)
            {
                filter = x => (x.RequestUserId == targetUserId && (x.TargetUser.FirstName.Contains(searchString) || x.TargetUser.LastName.Contains(searchString))) ||
                              (x.TargetUserId == targetUserId && (x.RequestUser.FirstName.Contains(searchString) || x.RequestUser.LastName.Contains(searchString)));
            }
            else
            {
                filter = x => x.RequestUserId == targetUserId || x.TargetUserId == targetUserId;
            }

            filter = filter.And(x => x.FriendshipTypeId == (int)FriendshipEnum.Accepted);

            int totalItem = await _unitOfWork.FriendshipRepository.GetCount(filter);
            int pageCount = (int)Math.Ceiling((double)totalItem / pageSize);

            if (pageNumber > pageCount && pageCount > 0)
            {
                return new ErrorResponse(404, Messages.OutOfPage);
            }

            var friends = await _unitOfWork.FriendshipRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            var result = _mapper.Map<List<GetFriendshipResponse>>(friends);

            return new PagedResponse<List<GetFriendshipResponse>>(result, totalItem, 200);
        }

        private async Task<bool> IsFriend(string userId1, string userId2)
        {
            var result = await _unitOfWork.FriendshipRepository.FindOneBy(x => x.RequestUserId == userId1 && x.TargetUserId == userId2 || x.RequestUserId == userId1 && x.TargetUserId == userId2);
            return result != null;
        }

        private async Task<bool> CheckOwnerOrAdminAsync(string loggedId, string requestId)
        {
            if (loggedId == requestId) return true;

            var user = await _userManager.FindByIdAsync(loggedId);
            if (user == null) return false;

            return await _userManager.IsInRoleAsync(user, RoleName.Administrator);
        }

        public async Task<IResponse> ChangeCoverImage(string requestId, ChangeCoverImageRequest request)
        {
            await _unitOfWork.UserRepository.UpdateCoverImage(requestId, request.Url);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var data = (DataResponse<GetUserResponse>)await this.GetById(requestId);

            return new DataResponse<GetUserResponse>(data.Data, 200);
        }

        public async Task<IResponse> ChangeAvatar(string requestId, ChangeCoverImageRequest request)
        {
            await _unitOfWork.UserRepository.UpdateAvatar(requestId, request.Url);
            if (!await _unitOfWork.CompleteAsync()) throw new NoDataChangeException();

            var data = (DataResponse<GetUserResponse>)await this.GetById(requestId);

            return new DataResponse<GetUserResponse>(data.Data, 200);
        }


        #endregion


        public async Task<IResponse> Stats(string requestUserId)
        {
            int totalUser = await _unitOfWork.UserRepository.GetQueryable().CountAsync(x => x.Status == 1);
            int activingUser = _hubControl.GetActivingUser();

            var response = new StatsUserResponse
            {
                TotalUser = totalUser,
                ActivingUser = activingUser,
            };

            return new DataResponse<StatsUserResponse>(response, 200);
        }

        public async Task<IResponse> AddRole(string requestUserId, string targetUserId, CreateUserRoleRequest request)
        {
            if (await _userManager.IsInRoleAsync(new User
            {
                Id = targetUserId
            }, RoleName.SuperAdministrator))
            {
                return new ErrorResponse(400, Messages.Forbidden);
            }

            if (request.Roles.Length < 1)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(targetUserId) ?? throw new NotFoundException("User id: " + targetUserId);

            foreach (var role in request.Roles)
            {
                if (!(await _roleManager.RoleExistsAsync(role)))
                return new ErrorResponse(400, Messages.InvalidRole);
            }

            await _userManager.AddToRolesAsync(user, request.Roles);

            return new SuccessResponse(Messages.AddRoleToUserSuccess, 201);
        }

        public async Task<IResponse> RemoveRole(string requestUserId, string targetUserId, CreateUserRoleRequest request)
        {
            if (await _userManager.IsInRoleAsync(new User
            {
                Id = targetUserId
            }, RoleName.SuperAdministrator))
            {
                return new ErrorResponse(400, Messages.Forbidden);
            }

            if (request.Roles.Length < 1)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(targetUserId) ?? throw new NotFoundException("User id: " + targetUserId);

            foreach (var role in request.Roles)
            {
                if (!(await _roleManager.RoleExistsAsync(role)))
                    return new ErrorResponse(400, Messages.InvalidRole);
            }

            await _userManager.RemoveFromRolesAsync(user, request.Roles);

            return new SuccessResponse(Messages.RemovedRole, 201);
        }

        public async Task<IResponse> LockOut(string requestId, string targetId)
        {
            if (await _userManager.IsInRoleAsync(new User
            {
                Id = targetId
            }, RoleName.Administrator))
            {
                return new ErrorResponse(400, Messages.Forbidden);
            }

            var user = await _userManager.FindByIdAsync(targetId) ?? throw new NotFoundException("User id: " + targetId);
            await _userManager.SetLockoutEndDateAsync(user, DateTime.UtcNow.AddYears(999));
            return new SuccessResponse(Messages.UserLocked, 200);
        }

        public async Task<IResponse> UnLockOut(string requestId, string targetId)
        {
            if (await _userManager.IsInRoleAsync(new User
            {
                Id = targetId
            }, RoleName.Administrator))
            {
                return new ErrorResponse(400, Messages.Forbidden);
            }

            var user = await _userManager.FindByIdAsync(targetId) ?? throw new NotFoundException("User id: " + targetId);
            await _userManager.SetLockoutEndDateAsync(user, null);
            return new SuccessResponse(Messages.UserLocked, 200);
        }
    }
}
