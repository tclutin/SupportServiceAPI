using System.ComponentModel.DataAnnotations;

namespace SupportService.Api.src.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Role { get; set; } = "worker";

        public string Email { get; set; }

        public string Password { get; set; }

        public int Rating { get; set; } = 0;
    }
}
