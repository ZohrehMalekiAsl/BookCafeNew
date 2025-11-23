using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
