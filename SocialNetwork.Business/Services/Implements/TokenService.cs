using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Business.DTOs.Token;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Settings;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.Business.Services.Implements
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public TokenService(IOptions<JWTSettings> jwtSettings, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _jwtSettings = jwtSettings.Value;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Token> CreateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiration);
            var securityKey = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature);

            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = GetClaims(user, userRoles),
                Expires = accessTokenExpiration,
                SigningCredentials = signingCredentials,

            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = refreshTokenExpiration,
                IsRevoked = false,
                IsUsed = false,
                JwtId = token.Id,
                Token = GenerateRefreshToken()
            };

            await _unitOfWork.RefreshTokenRepository.Add(refreshToken);
            await _unitOfWork.CompleteAsync();

            return new Token
            {
                AccessToken = jwtToken,
                AccessTokenExpiration = accessTokenExpiration,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshTokenExpiration
            };
        }

        private ClaimsIdentity GetClaims(User user, List<string> roles)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Email, user.Email),
                new("userid", user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return new ClaimsIdentity(claims);
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
            }
            return Convert.ToBase64String(random);
        }
    
        public async Task<TokenWithMessage> RenewToken(RenewTokenRequest token)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
            var tokenValidateParams = new TokenValidationParameters()
            {
                ValidateIssuer = false, // dev
                ValidateAudience = false, // dev
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                RequireExpirationTime = false, // dev - cần cập nhật khi thêm refresh token
                ClockSkew = TimeSpan.Zero,   // Thời gian delay giữa client và server
                ValidateLifetime = false, // Không kiểm tra hết hạn
            };

            try
            {
                // Check format access token
                var tokenVerification = jwtTokenHandle.ValidateToken(token.AccessToken, tokenValidateParams, out var validatedToken);
                if (validatedToken == null)
                {
                    return new TokenWithMessage
                    {
                        Message = "Token invalid (format)",
                        Token = null
                    };
                }

                // Check Algorithms
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return new TokenWithMessage
                        {
                            Message = "Token invalid (Alg)",
                            Token = null
                        };
                    }    
                }

                // Check time expired
                var utcExpriedSecond = long.Parse(tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)!.Value);
                var expiredDate = ConvertUnixTime(utcExpriedSecond);
                if (expiredDate > DateTime.UtcNow)
                {
                    return new TokenWithMessage
                    {
                        Message = "Token is not expired",
                        Token = null
                    };
                }

                // Check refresh token in DB
                var jti = tokenVerification.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)!.Value;
                if (jti == null)
                {
                    return new TokenWithMessage
                    {
                        Message = "Token invalid (Jti)",
                        Token = null
                    };
                }
                //  Check exits
                var refreshToken = await _unitOfWork.RefreshTokenRepository.GetToken(token.RefreshToken, jti);
                if (refreshToken == null)
                {
                    return new TokenWithMessage
                    {
                        Message = "Refresh token not exist",
                        Token = null
                    };
                }

                //  Check is used || is revoked
                if (refreshToken.IsUsed)
                {
                    return new TokenWithMessage
                    {
                        Message = "Refresh token is used",
                        Token = null
                    };
                }
                if (refreshToken.IsRevoked)
                {
                    return new TokenWithMessage
                    {
                        Message = "Refresh token is revoked",
                        Token = null
                    };
                }

                //  Check user
                var userId = tokenVerification.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                if (userId == null)
                {
                    return new TokenWithMessage
                    {
                        Message = "User not found",
                        Token = null
                    };
                }
                var user = await _unitOfWork.UserRepository.FindById(userId);
                if (user == null) 
                {
                    return new TokenWithMessage
                    {
                        Message = "User not found",
                        Token = null
                    };
                }

                // Update token
                await _unitOfWork.RefreshTokenRepository.RevokeToken(refreshToken);
                var resultUpdate = await _unitOfWork.CompleteAsync();
                if (!resultUpdate)
                {
                    return new TokenWithMessage
                    {
                        Message = "Error revoke token",
                        Token = null
                    };
                }

                var newToken = await CreateToken(user);

                return new TokenWithMessage
                {
                    Message = "Renew Token Successfully",
                    Token = newToken
                };

            }
            catch (Exception ex)
            {
                return new TokenWithMessage
                {
                    Message = $"Something went wrong: {ex.Message}",
                    Token = null
                };
            }
                        
        }

        private DateTime ConvertUnixTime(long seconds)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return dateTimeInterval.AddSeconds(seconds);
        }
    }
}
