using System.ComponentModel.DataAnnotations;

namespace SupportService.Api.src.Controllers.Dto
{
    public class AuthUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
