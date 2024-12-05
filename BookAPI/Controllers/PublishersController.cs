using BookAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    public class PublishersController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PublishersController : ControllerBase
        {
            public PublishersService PublishersService { get; set; }
            public PublishersController(PublishersService publishersService)
            {
                PublishersService = publishersService;
            }
            [HttpPost]
            public IActionResult AddPublisher([FromBody] PublisherVM publisher)
            {
                PublishersService.AddPublisher(publisher);
                return Ok();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
