using BookCafe.Domain.Entities;

namespace BookCafe.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        void Add(RefreshToken token);
        void Update(RefreshToken token);
        Task<RefreshToken> GetByTokenAsync(string token);
        Task<List<RefreshToken>> GetTokenByUserId(Guid userId);
    }
}
