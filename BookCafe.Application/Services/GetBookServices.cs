using BookCafe.Application.Interfaces.Services;
using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Services
{
    public class GetBookServices : IBookService
    {
        public async Task<List<Book>> GetBooksAsync(string title)
        {
            Cat cat = new Cat();
            //cat.Eat();
            cat.Speak("hb");
            cat.SpeakWithoutChild("Ss");
            cat.Walk();
           //cat.Read("ss");
            cat.Repeat();
            List<Book> booklist = new List<Book>();
            booklist.Add(new Book { Title = title+"general" });
            return booklist;
        }
    }
}
