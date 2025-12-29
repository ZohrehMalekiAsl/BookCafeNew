using Azure;
using BookCafe.Application.CQRS.Token.Commands;
using BookCafe.Application.Dtos.Login;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookCafe.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
  
        private readonly IAppSetting _appSetting;

        public JwtTokenService(IAppSetting appSetting)
        {
        
            _appSetting = appSetting;
        }



        public Task<LoginResponseDto> GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetting.SecretKey));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
           { new Claim(JwtRegisteredClaimNames.Sub, user.UserName) };

            var token = new JwtSecurityToken(
            issuer: _appSetting.Issuer,
            audience: _appSetting.Audience,
            claims: claim,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(_appSetting.AccessTokenMinutes)), // زمان انقضا
            signingCredentials: credential
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            var response = new LoginResponseDto
            {
                ExpiresAt = token.ValidTo,
                AccessToken = jwt
            };
            return Task.FromResult(response);
        }
        public Task<LoginResponseDto> GenerateRefreshToken(GenerateTokenCommand command)
        {
          
            var days = double.Parse(_appSetting.RefreshTokenDays);

            var randomBytes = RandomNumberGenerator.GetBytes(64);
            var token = Convert.ToBase64String(randomBytes);
            var g = new LoginResponseDto();
            return Task.FromResult(g);
            //{
            //    UserId = 
            //    Token = token,
            //    CreateAt = DateTime.UtcNow,
            //    ExpiresAt = DateTime.UtcNow.AddDays(days),
            //    IsRevoked = false
            //};

        }
    }
}
