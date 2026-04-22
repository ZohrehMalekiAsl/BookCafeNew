using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync(string title);
    }
}
