using SupportService.Api.src.Controllers.Dto;
using SupportService.Api.src.Entities;

namespace SupportService.Api.src.Services.UserService
{
    public interface IUserRepository
    {
        public string Create(User user);
        public User? GetUser(AuthUser authUser);
    }
}
