using BookCafe.Application.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Dtos.Authors
{
    public class AuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Nationality { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
