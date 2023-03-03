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

        public string Register(RegUser regUser)
        {
            var user = new User
            {
                Username = regUser.Username,
                Email = regUser.Email,
                Password = regUser.Password,
            };

            return _userRepository.Create(user);
        }

        public object Login(AuthUser authUser)
        {
            var user = _userRepository.GetUser(authUser);
            
            if (user == null) { return "Error"; }

            var tokens = new Tokens
            {
                accessToken = GenerateToken(user.Username),
                refreshToken = ""
            };

            return tokens;
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
                expires: DateTime.Now.AddMinutes(1),
                claims: claims,
                signingCredentials: singingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
