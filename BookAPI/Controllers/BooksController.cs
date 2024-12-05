using BookAPI.Services;
using BookAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService BookService { get; set; }
        public BooksController(BookService booksService)
        {
            BookService = booksService;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            BookService.AddBook(book);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = BookService.GetAllBooks();
            return Ok(allBooks);
        }
        
        [HttpGet("id")]
        public IActionResult GetBookById([FromQuery] int id)
        {
            var book = BookService.GetBookById(id);
            return Ok(book);
        }
        [HttpPut("id")]
        public IActionResult UpdateBookById([FromQuery] int id,
[FromBody] BookVM bookVM)
        {
            var updatedBook = BookService.UpdateBookById(id, bookVM);
            return Ok(updatedBook);
        }
        [HttpDelete("id")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            BookService.DeleteBook(id);
            return Ok();
        }

    }
}
