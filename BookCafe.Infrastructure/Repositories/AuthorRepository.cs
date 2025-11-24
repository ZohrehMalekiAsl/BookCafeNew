using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using BookCafe.Infrastructure.Repositories;

namespace BookCafe.Infrastructure.Repository
{
    public class AuthorRepository(ApplicationDbContext dbContext) 
        : GenericRepository<Author>(dbContext), IAuthorRepository
    {
   
    }
}
