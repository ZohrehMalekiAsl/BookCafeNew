using BookCafe.Application.CQRS.Token.Commands;
using BookCafe.Application.Dtos.Login;
using BookCafe.Application.Interfaces.Infra;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookCafe.Infrastructure
{
    public class JwtTokenService : IJwtTokenService
    {
  
        private readonly IAppSetting _appSetting;

        public JwtTokenService(IAppSetting appSetting)
        {
        
            _appSetting = appSetting;
        }

        public Task<LoginResponseDto> GetToken(GenerateTokenCommand command)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetting.SecretKey));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
           { new Claim(JwtRegisteredClaimNames.Sub, command.UserName) };

            var token = new JwtSecurityToken(
            issuer: _appSetting.Issuer,
            audience: _appSetting.Audience,
            claims: claim,
            expires: DateTime.UtcNow.AddMinutes(30), // زمان انقضا
            signingCredentials: credential
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            var response = new LoginResponseDto
            {
                ExpiresAt = token.ValidTo,
                RefreshToken = jwt
            };
            return Task.FromResult(response);
        }
    }
}
