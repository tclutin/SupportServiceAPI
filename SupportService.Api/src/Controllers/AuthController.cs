using Microsoft.AspNetCore.Mvc;

namespace SupportService.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
