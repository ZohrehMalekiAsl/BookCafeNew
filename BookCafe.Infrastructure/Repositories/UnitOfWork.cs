using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookCafe.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAysnc()
        {
           return await _dbContext.SaveChangesAsync();
        }
        public async Task BeginTransaction()
        {
            _transaction= await _dbContext.Database.BeginTransactionAsync();
        }
        public async Task RollbackTransaction()
        {
            if (_transaction == null)
            {
                return;
            }

            await _transaction.RollbackAsync();
            await DisposeTransaction();
        }
        public async Task CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction is in progress to commit.");
            }

            try
            {
                await SaveAysnc();
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await RollbackTransaction();
                throw; 
            }
        }
        public async Task DisposeTransaction()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}
