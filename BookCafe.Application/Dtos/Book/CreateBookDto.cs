using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Dtos.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public List<Guid> AuthorIds { get; set; }
    }

}
