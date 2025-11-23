using System.Net.Sockets;

namespace BookCafe.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Nationality { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
