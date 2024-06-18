using BlogMaster.Application.DTO.UseCases;
using BlogMaster.Application.UseCases.Commands.UseCases;
using BlogMaster.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCasesController : ControllerBase
    {

        private UseCaseHandler Handler { get; }
        public UseCasesController(UseCaseHandler handler)
        {
            Handler = handler;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(
            [FromServices] IAddUserUseCaseCommand command,
            [FromBody] AddUserUseCaseDTO request)
        {
            Handler.HandleCommand(command, request);
            return StatusCode(201);
        }



        [HttpDelete]
        [Authorize]
        public IActionResult Delete(
            [FromServices] IDeleteUserUseCaseCommand command,
            [FromBody] DeleteUserUseCaseDTO request)
        {
            Handler.HandleCommand(command, request);
            return NoContent();
        }
    }
}
