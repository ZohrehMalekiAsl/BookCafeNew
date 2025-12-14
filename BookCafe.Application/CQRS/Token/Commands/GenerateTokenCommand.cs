using BookCafe.Application.Dtos.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.CQRS.Token.Commands
{
    public class GenerateTokenCommand: IRequest<LoginResponseDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
