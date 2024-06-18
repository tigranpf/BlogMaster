using BlogMaster.Application.DTO.Tags;
using BlogMaster.Application.UseCases.Commands.Tags;
using BlogMaster.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private UseCaseHandler Handler;

        public TagsController(UseCaseHandler commandHandler)
        {
            Handler = commandHandler;
        }
        // GET: api/<TagsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TagsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] AddTagDTO dto, [FromServices] IAddTagCommand command)
        {
            Handler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            Handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
