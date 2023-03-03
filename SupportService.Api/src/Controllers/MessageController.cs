using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportService.Api.src.Controllers.Dto;

using SupportService.Api.src.Services.UserService;

namespace SupportService.Api.src.Controllers
{
    [ApiController]
    [Route("message")]
    public class MessageController : ControllerBase
    {


        public MessageController()
        {
        }

        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("заеис");
        }

    }
}
