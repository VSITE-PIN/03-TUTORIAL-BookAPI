using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/books/get-all-books
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        // GET: api/books/get-book-by-id/5
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/books/add-book
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        // PUT: api/books/update-book-by-id/5
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookVM book)
        {
            _booksService.UpdateBookById(id, book);
            return Ok();
        }

        // DELETE: api/books/delete-book-by-id/5
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
