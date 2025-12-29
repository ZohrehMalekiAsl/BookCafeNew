using BookCafe.Application.Dtos.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Infra
{
    public interface IAuthService
    {
        Task<LoginResponseDto> IsAuthenticated (LoginRequestDto loginRequest);
    }
}
