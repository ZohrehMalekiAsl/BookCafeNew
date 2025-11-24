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
    public class GenericRepository<TEntity> (ApplicationDbContext dbContext) where TEntity : class, IEntity
    {
        public void Add(TEntity entity)
        {
            dbContext.Add(entity);
        }
        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            dbContext.Remove(entity);
        }
        public async Task<T> GetByIdAsync<T>(Guid guid)
        {
            var result= dbContext.FindAsync(guid);
            return result;
        }
    }
}
