using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Repositories
{
    public class RefreshTokenRepository(ApplicationDbContext dbContext) : GenericRepository<RefreshToken>(dbContext), IRefreshTokenRepository, IUnitOfWork
    {
        public Task<int> AysncSave()
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetByTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
