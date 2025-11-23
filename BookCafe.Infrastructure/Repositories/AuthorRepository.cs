using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;

namespace BookCafe.Infrastructure.Repository
{
    public class AuthorRepository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Guid> AddAsync<T>(T Entity)
        {
            var guid = _dbContext.Add(Entity);
            var result = await _dbContext.SaveChangesAsync();
            return new Guid();
        }
        public async Task<bool> UpdateAsync<T>(T Entity)
        {
            _dbContext.Update(Entity);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
                return true;
            return false;
        }
    }
}
