using Microsoft.AspNetCore.Mvc;

namespace SupportService.Api.Infrastructure.Repository
{
    public class AuthRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
