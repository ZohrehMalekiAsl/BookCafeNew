using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
       void Add(RefreshToken token);
        Task<RefreshToken> GetByTokenAsync(string token);
    }
}
