using BookAPI.Data;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        // GET: api/<PublishersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PublishersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublishersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublishersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublisherService PublishersService { get; set; }
        public PublishersController(PublisherService publishersService)
        {
            PublishersService = publishersService;
        }
        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            PublisherService.AddPublisher(publisher);
            return Ok();
        }
    }
    [HttpDelete("id")]
    public IActionResult DeletePublisher([FromQuery] int id)
    {
        PublisherService.DeletePublisher(id);
        return Ok();
    }

}
