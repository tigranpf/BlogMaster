using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.UseCases.Commands.BlogPosts;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public BlogPostController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        // GET: api/<BlogPostController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchBlogPostsDTO dto, [FromServices] IGetBlogPostsQuery query)
        {
            return Ok(Handler.HandleQuery(query, dto));
        }

        // GET api/<BlogPostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBlogPostQuery query)
        {
            return Ok(Handler.HandleQuery(query, id));
        }

        // POST api/<BlogPostController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddBlogPostDTO dto, [FromServices] IAddBlogPostCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<BlogPostController>/5
        [Authorize]
        [HttpPatch]
        public IActionResult HttpPatch([FromBody] EditBlogPostDTO dto,
                              [FromServices] IEditBlogPostCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<BlogPostController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteBlogPostCommand command)
        {
            Handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
