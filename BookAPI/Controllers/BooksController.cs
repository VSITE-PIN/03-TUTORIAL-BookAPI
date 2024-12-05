
using Microsoft.AspNetCore.Mvc;
using BookAPI.Data;
using BookAPI.Services;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _booksService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            if (updatedBook == null)
                return NotFound();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBook(id);
            return Ok();
        }
    }
}
