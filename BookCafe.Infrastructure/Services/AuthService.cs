using BookCafe.Application.Dtos.Login;
using BookCafe.Application.Interfaces.Infra;

namespace BookCafe.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUserService userService, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<LoginResponseDto> IsAuthenticated(LoginRequestDto loginRequest)
        {
            var user = await _userService.GetUserByUsername(loginRequest.UserName);
            if (user == null)
            {
                return new LoginResponseDto();
            }
            var result = _userService.ValidatePassword(user, loginRequest.Password);

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
                return jwt.Result;
            }
        }
    }
}
