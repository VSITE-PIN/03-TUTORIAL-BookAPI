using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // POST: api/authors/add-author
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        // GET: api/authors/get-all-authors
        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorsService.GetAllAuthors();
            return Ok(authors);
        }

        // GET: api/authors/get-author-by-id/5
        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorsService.GetAuthorById(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // GET: api/authors/get-author-with-books/5
        [HttpGet("get-author-with-books/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var author = _authorsService.GetAuthorWithBooks(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

    }
}
