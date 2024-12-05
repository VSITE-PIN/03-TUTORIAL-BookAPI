using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

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

	[HttpPost]
	public IActionResult AddAuthor([FromBody] AuthorVM author)
    {
        AuthorsService.AddAuthor(author);
        return Ok();
    }
}