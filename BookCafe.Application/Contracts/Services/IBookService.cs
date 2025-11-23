using BookCafe.Application.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Contracts.Services
{
    public interface IBookService
    {
        Task<Guid> InsertBookAsynce(CreateBookDto bookDto);
        Task<bool> UpdateBookAsynce(Guid bookId, UpdateBookDto bookDto);
        Task<List<BookDto>> GetBookAsync();
    }
}
