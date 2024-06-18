using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.DTO.Users;
using BlogMaster.Application.UseCases.Commands.Users;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.Implementation.UseCases;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler Handler;
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".jpeg", ".png" };

        public UsersController(UseCaseHandler commandHandler)
        {
            Handler = commandHandler;
        }
        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchUsersDTO dto, [FromServices] IGetAllUsersQuery query)
        {
            return Ok(Handler.HandleQuery(query, dto));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromForm] RegisterUserDto dto, [FromServices] IRegisterUserCommand command)
        {
            if (dto.ProfilePicture != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.ProfilePicture.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file of uploading image.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "Images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.ProfilePicture.CopyTo(stream);
                dto.ProfilePicturePath = fileName;
            }

            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] EditUserDTO dto, [FromServices] IEditUserCommand command)
        {
            Handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            Handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
