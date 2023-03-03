using Microsoft.AspNetCore.Mvc;
using SupportService.Api.src.Controllers.Dto;

using SupportService.Api.src.Services.UserService;

namespace SupportService.Api.src.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService UserService)
        {
            _userService = UserService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(RegUserDto dto)
        {
            if (dto == null) BadRequest(new { message = "Invalid request" });
            
            return Ok(_userService.Register(dto));
        }

        [HttpPost("login")]
        public IActionResult LogIn(AuthUserDto dto)
        {
            if (dto == null) BadRequest(new { message = "Invalid request" });

            return Ok(_userService.Login(dto));
        }
    }
}
