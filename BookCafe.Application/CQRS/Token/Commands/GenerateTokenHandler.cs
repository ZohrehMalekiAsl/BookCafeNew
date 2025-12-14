using BookCafe.Application.Dtos.Login;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.CQRS.Token.Commands
{
    public class GenerateTokenHandler : IRequestHandler<GenerateTokenCommand, LoginResponseDto>
    {
        private readonly IJwtTokenService _jwtTokenService;

        public GenerateTokenHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponseDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            return await _jwtTokenService.GetToken(request);
        }
    }
}
