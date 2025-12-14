using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Dtos.Login
{
    public class LoginResponseDto
    {
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; }
    }
}
