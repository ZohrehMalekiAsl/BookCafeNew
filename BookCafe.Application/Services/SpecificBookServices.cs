using BookCafe.Application.Interfaces.Services;
using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Services
{
    public class SpecificBookServices : IBookService
    {
        public async Task<List<Book>> GetBooksAsync(string title)
        {
            
            List<Book> booklist = new List<Book>();
            booklist.Add(new Book { Title = title });
            return booklist;
        }
    }
}
