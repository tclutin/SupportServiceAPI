using SupportService.Api.src.Controllers.Dto;
using SupportService.Api.src.Entities;

namespace SupportService.Api.src.Services.UserService
{
    public interface IUserService
    {
        public string Register(RegUser regUser);
        public object Login(AuthUser authUser);
    }
}
