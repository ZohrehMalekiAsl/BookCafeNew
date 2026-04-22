using BookCafe.Application.Dtos.Book;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IEnumerable< IBookService> _bookService;

        public BookController(IEnumerable<IBookService> bookService)
        {
            _bookService = bookService;
        }
        [HttpPost(Name = "AddBook")]
        public async Task<IActionResult> CreateBook(BookDto book)
        {
            var result= await _bookService.OfType<GetBookServices>().FirstOrDefault().GetBooksAsync(book.Title);
            return Ok(result);
        }
    }
}
