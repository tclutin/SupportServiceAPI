using SupportService.Api.src.Controllers.Dto;
using SupportService.Api.src.Entities;

namespace SupportService.Api.src.Services.UserService
{
    public interface IUserRepository
    {
        void Create(User user);
        User? Get(AuthUserDto dto);
        User? Get(RegUserDto dto);
    }
}
