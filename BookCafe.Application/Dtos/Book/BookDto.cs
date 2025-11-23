using BookCafe.Application.Dtos.Authors;

namespace BookCafe.Application.Dtos.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public List<AuthorDto> Authors { get; set; }

    }
}
