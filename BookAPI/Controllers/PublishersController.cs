using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        // POST: api/publishers/add-publisher
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        // GET: api/publishers/get-all-publishers
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            var publishers = _publishersService.GetAllPublishers();
            return Ok(publishers);
        }

        // GET: api/publishers/get-publisher-by-id/5
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publishersService.GetPublisherById(id);

            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        // DELETE: api/publishers/delete-publisher/5
        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publishersService.DeletePublisher(id);
            return Ok();
        }
    }
}
