using BookAPI.Services;
using BookAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
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
        [HttpDelete("id")]
        public IActionResult DeletePublisher([FromQuery] int id)
        {
            PublishersService.DeletePublisher(id);
            return Ok();
        }
    }
}

