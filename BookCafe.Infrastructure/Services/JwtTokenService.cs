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
        public Task<string> GenerateAccessToken(User user)
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
      
            return Task.FromResult(jwt);
        }
        public Task<RefreshToken> GenerateRefreshToken(Guid userId)
        {
          
            var days = double.Parse(_appSetting.RefreshTokenDays);

            var randomBytes = RandomNumberGenerator.GetBytes(64);
            var token = Convert.ToBase64String(randomBytes);
            var hashedToken = Convert.ToBase64String(HashRefreshToken(token));
            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = hashedToken,
                CreateAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(days),
                IsRevoked = false
            };
            
            return Task.FromResult(refreshToken );
        }
        public static byte[] GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[16]; // 16 بایت معمولاً برای Salt کافی است
            rng.GetBytes(salt);
            return salt;
        }

        private static byte[] HashRefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            var salt = GenerateSalt();
            var combined = Encoding.UTF8.GetBytes(refreshToken).Concat(salt).ToArray(); // ترکیب توکن و Salt

            using (var sha256 = SHA256.Create())
            {
                var hashedToken = sha256.ComputeHash(combined);
                return hashedToken;
            }
        }
    }
}
