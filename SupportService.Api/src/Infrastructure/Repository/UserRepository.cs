
using SupportService.Api.src.Controllers.Dto;
using SupportService.Api.src.Entities;
using SupportService.Api.src.Infrastructure.Repository;
using SupportService.Api.src.Services.UserService;

namespace SupportService.Api.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void Create(User user)
        {
            _userDbContext.User.Add(user);
            _userDbContext.SaveChanges();
        }

        public User? Get(AuthUserDto dto)
        {
            return _userDbContext.User
                .Where(u => u.Username == dto.Username && u.Password == dto.Password)
                .FirstOrDefault();
        }

        public User? Get(RegUserDto dto)
        {
            return _userDbContext.User
                .Where(u => u.Username == dto.Username && u.Password == dto.Password)
                .FirstOrDefault();
        }
    }
}
