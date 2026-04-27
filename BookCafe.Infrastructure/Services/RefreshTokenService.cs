using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Repositories;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;

namespace BookCafe.Infrastructure.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RefreshTokenService(IRefreshTokenRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddRefreshToken(RefreshToken refreshToken)
        {
             await _unitOfWork.BeginTransaction();
             var refreshTokens=_repository.GetTokenByUserId(refreshToken.UserId);
            foreach (var token in refreshTokens.Result)
            {
                token.IsRevoked = true;
                _repository.Update(token);
            }
             _repository.Add(refreshToken);
             try
            { 
                await _unitOfWork.CommitTransaction();
                return await Task.FromResult(false);
             }
            catch (Exception ex) 
            {
                 return await Task.FromResult(true);
             }
            finally
            {
                _unitOfWork.RollbackTransaction();
            }
        }

        public async Task<RefreshToken> GetRefreshToken(string token)
        {
            return await _repository.GetByTokenAsync(token);
        }
        //public Task<RefreshToken> CreateAsync(int userId, string? deviceId = null)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task RevokeAsync(RefreshToken refreshToken)
        {
            refreshToken.IsRevoked = true;
            _repository.Update(refreshToken);
            await _unitOfWork.SaveAysnc();
        }

        public Task<bool> ValidateAsync(string token, RefreshToken refreshToken)
        {
            if (token == refreshToken.Token)
            { return Task.FromResult(true); }
            else
            { return Task.FromResult(false); }
        }
    }
}
