using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService BooksService { get; set; }

        public BooksController(BooksService booksService)
        {
            BooksService = booksService;
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            BooksService.AddBook(book);
            return Ok();
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = BooksService.GetAllBooks();
            return Ok(allBooks);
        }

        // GET: api/Books/id?id=1
        [HttpGet("id")]
        public IActionResult GetBookById([FromQuery] int id)
        {
            var book = BooksService.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // PUT: api/Books/id?id=1
        [HttpPut("id")]
        public IActionResult UpdateBookById([FromQuery] int id, [FromBody] BookVM bookVM)
        {
            var updatedBook = BooksService.UpdateBookById(id, bookVM);
            if (updatedBook == null)
                return NotFound();

            return Ok(updatedBook);
        }

        // DELETE: api/Books/id?id=1
        [HttpDelete("id")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            BooksService.DeleteBook(id);
            return Ok();
        }
    }
}
