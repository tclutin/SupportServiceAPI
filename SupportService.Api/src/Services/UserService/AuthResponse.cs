using SupportService.Api.src.Entities;
using System.Text.Json.Serialization;

namespace SupportService.Api.src.Services.UserService
{
    public class AuthResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Role { get; set; } = "worker";

        public string Email { get; set; }

        public int Rating { get; set; } = 0;

        public Tokens Tokens { get; set; }
    }
}
