using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // POST: api/publishers/add-publisher
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }

        // GET: api/publishers/get-all-publishers
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            var publishers = _publisherService.GetAllPublishers();
            return Ok(publishers);
        }

        // GET: api/publishers/get-publisher-by-id/5
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);

            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        // DELETE: api/publishers/delete-publisher/5
        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherService.DeletePublisher(id);
            return Ok();
        }
    }
}
