using Azure;
using BookCafe.Application.CQRS.Token.Commands;
using BookCafe.Application.Dtos.Login;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Repositories;
using BookCafe.Domain.Entities;

namespace BookCafe.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(IUserService userService, IJwtTokenService jwtTokenService, IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<LoginResponseDto> IsAuthenticated(GenerateTokenCommand request)
        {
            var user = await _userService.GetUserByUsername(request.UserName);
            if (user == null)
            {
                return new LoginResponseDto();
            }
            var result = _userService.ValidatePassword(user, request.Password);

            if (result == null || result.Result != true)
            {

                return new LoginResponseDto();
            }
            var jwt = _jwtTokenService.GenerateAccessToken(user);
            if (jwt == null)
            {
                return new LoginResponseDto();
            }
            else
            {
                var refToken= _jwtTokenService.GenerateRefreshToken(user.Id);
                if (refToken == null)
                {
                    return new LoginResponseDto();
                }
                else
                {
                    var refreshToken = new RefreshToken
                    {
                        CreateAt = refToken.Result.CreateAt,
                            ExpiresAt = refToken.Result.ExpiresAt,
                            Id = refToken.Result.Id,
                            Token=refToken.Result.Token,
                            IsRevoked = refToken.Result.IsRevoked,
                            UserId = user.Id,   
                            TokenVersion=user.TokenVersion,
                    };
                    
                    await _refreshTokenService.AddRefreshToken(refreshToken);
                    var response = new LoginResponseDto
                    {
                        AccessToken = jwt.Result,
                        ExpiresAt = refToken.Result.ExpiresAt,
                        RefreshToken=refToken.Result.Token
                    };
                    return response;
                }
               
            }
        }
    }
}
