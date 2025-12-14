using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetBySpecificationAsync(Author author);
        void Add(Author author);
        void Update(Author author);
    }
}
