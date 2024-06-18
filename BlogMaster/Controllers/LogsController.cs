using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private UseCaseHandler Handler;

        public LogsController(UseCaseHandler commandHandler)
        {
            Handler = commandHandler;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] AuditLogSearchDTO dto, [FromServices] IGetAuditLogsQuery query)
        {
            return Ok(Handler.HandleQuery(query, dto));
        }
    }
}
