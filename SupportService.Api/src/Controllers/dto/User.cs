using System.ComponentModel.DataAnnotations;

namespace SupportService.Api.src.Controllers.Dto
{
    public class AuthUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
