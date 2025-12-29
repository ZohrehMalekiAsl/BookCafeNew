using BookCafe.Application.CQRS.Token.Commands;
using BookCafe.Application.Dtos.Login;
using BookCafe.Domain.Entities;

namespace BookCafe.Application.Interfaces.Infra
{
    public interface IJwtTokenService
    {
        Task<LoginResponseDto> GenerateAccessToken(User user);
        Task<LoginResponseDto> GenerateRefreshToken(GenerateTokenCommand command);
    }
}
