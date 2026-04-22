using BookCafe.Domain.Entities;

namespace BookCafe.Application.Repositories
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetRefreshToken(string token);
        Task<bool> AddRefreshToken(RefreshToken refreshToken);
        Task<bool> ValidateAsync(string token, RefreshToken refreshToken);
        Task RevokeAsync(RefreshToken refreshToken);
    }
}
