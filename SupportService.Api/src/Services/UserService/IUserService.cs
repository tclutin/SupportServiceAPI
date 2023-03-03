using SupportService.Api.src.Controllers.Dto;

namespace SupportService.Api.src.Services.UserService
{
    public interface IUserService
    {
        string Register(RegUserDto dto);
        AuthResponse Login(AuthUserDto dto);
    }
}
