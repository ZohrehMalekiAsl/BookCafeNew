using BookCafe.Application.CQRS.Token.Commands;
using BookCafe.Application.Dtos.Login;

namespace BookCafe.Application.Interfaces.Infra
{
    public interface IAuthService
    {
        Task<LoginResponseDto> IsAuthenticated (GenerateTokenCommand request);
    }
}
