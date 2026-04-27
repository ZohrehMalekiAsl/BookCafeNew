using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Repositories
{
    public class RefreshTokenRepository(ApplicationDbContext dbContext)
        : GenericRepository<RefreshToken>(dbContext), IRefreshTokenRepository
    {
        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await dbContext.RefreshToken.FirstOrDefaultAsync(u => u.Token == token);
        }
        public async Task<List<RefreshToken>> GetTokenByUserId(Guid userId)
        {
          return await dbContext.RefreshToken.Where(u => u.UserId==userId && u.IsRevoked==false).ToListAsync();
        }
    }
}
