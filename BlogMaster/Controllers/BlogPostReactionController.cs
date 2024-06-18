using BlogMaster.Application.DTO.BlogPostReactions;
using BlogMaster.Application.UseCases.Commands.BlogPostReactions;
using BlogMaster.Application.UseCases.Commands.Reactions;
using BlogMaster.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostReactionController : Controller
    {
        private UseCaseHandler Handler { get; }
        public BlogPostReactionController(UseCaseHandler handler)
        {
            Handler = handler;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] ReactOnBlogDTO dto, [FromServices] IAddBlogPostReactionCommand command)
        {

            Handler.HandleCommand(command, dto);
            return StatusCode(201);

        }
        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromBody] ReactOnBlogDTO dto, [FromServices] IDeleteBlogPostReactionCommand command)
        {
            Handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
