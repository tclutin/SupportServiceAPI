using Microsoft.IdentityModel.Tokens;
using SupportService.Api.src.Controllers.Dto;
using SupportService.Api.src.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SupportService.Api.src.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string Register(RegUserDto dto)
        {
            var user = _userRepository.Get(dto);

            if (user != null) return "The user already exists";

            var newUser = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
            };

            _userRepository.Create(newUser);

            return "Successful";
        }

        public AuthResponse Login(AuthUserDto dto)
        {
            var user = _userRepository.Get(dto);
            
           // if (user == null) { return "Error"; }

            var authResponse = new AuthResponse
            {
                Username= user.Username,
                Email = user.Email,
                Tokens = new Tokens { AccessToken = GenerateToken(user.Username) }
            };

            return authResponse;
        }

        private string GenerateToken(string username)
        {
            var singingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(1),
                claims: claims,
                signingCredentials: singingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
