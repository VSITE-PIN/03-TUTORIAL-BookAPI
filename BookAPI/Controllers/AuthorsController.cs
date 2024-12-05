using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    public class AuthorsController : Controller
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
            [HttpPost]
            public IActionResult AddAuthor([FromBody] AuthorVM author)
            {
                AuthorsService.AddAuthor(author);
                return Ok();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
