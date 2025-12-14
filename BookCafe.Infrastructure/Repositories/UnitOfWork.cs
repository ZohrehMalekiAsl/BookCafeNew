using BookCafe.Application.Interfaces.Infra;
using BookCafe.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AysncSave()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
