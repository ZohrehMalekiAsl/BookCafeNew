using BookCafe.Application.Contracts.Services;
using BookCafe.Application.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Service.Book
{
    public class BookService : IBookService
    {
        public async Task<List<BookDto>> GetBookAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> InsertBookAsynce(CreateBookDto bookDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateBookAsynce(Guid bookId, UpdateBookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
