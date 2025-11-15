using BookAPI.Services;
using BookAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService AuthorsService { get; set; }
        public AuthorsController(AuthorsService authorsService)
        {
            AuthorsService = authorsService;
        } 
    [HttpGet("id")]
        public IActionResult GetAuthor([FromQuery] int id)
        {
            var author = AuthorsService.GetAuthorWithBooks(id);
            return Ok(author);
        }
    }
}
