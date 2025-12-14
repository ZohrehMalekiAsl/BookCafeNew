using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using BookCafe.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCafe.Infrastructure.Repository
{
    public class AuthorRepository(ApplicationDbContext dbContext) 
        : GenericRepository<Author>(dbContext), IAuthorRepository
    {

        public async Task<IEnumerable<Author>> GetBySpecificationAsync(Author author)
        {
            var result = dbContext.Author.Where(x => x.FirstName.Contains(author.FirstName)
            );
            return await result.ToListAsync();
        }
     
    }
}
