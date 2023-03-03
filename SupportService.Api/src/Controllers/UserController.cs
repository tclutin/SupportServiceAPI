using Microsoft.AspNetCore.Mvc;
using SupportService.Api.src.Controllers.Dto;

using SupportService.Api.src.Services.UserService;

namespace SupportService.Api.src.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService UserService)
        {
            _userService = UserService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(RegUser dto)
        {
            return Ok(_userService.Register(dto));
        }

        [HttpPost("login")]
        public IActionResult LogIn(AuthUser dto)
        {
            return Ok(_userService.Login(dto));
        }
    }
}
