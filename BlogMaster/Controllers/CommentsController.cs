using BlogMaster.Application.DTO.Comments;
using BlogMaster.Application.UseCases.Commands.Comments;
using BlogMaster.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public CommentsController(UseCaseHandler handler)
        {
            Handler = handler;
        }
        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] AddCommentDTO dto, [FromServices] IAddCommentCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            Handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
