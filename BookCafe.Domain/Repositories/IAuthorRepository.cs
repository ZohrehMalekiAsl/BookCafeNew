using BookCafe.Domain.Entities;

namespace BookCafe.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetBySpecificationAsync(Author author);
        void Add(Author author);
        void Update(Author author);
    }
}
