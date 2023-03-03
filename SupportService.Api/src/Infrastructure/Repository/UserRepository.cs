using Microsoft.AspNetCore.Mvc;
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

        public string Create(User user)
        {
            List<User> listOfUser = _userDbContext.User.Where(item => item.Username== user.Username).ToList();
            if (listOfUser.Count != 0)
            {
                return "The user already exists";
            }

            _userDbContext.User.Add(user);
            _userDbContext.SaveChanges();
            return "Successfully";
        }

        public User? GetUser(AuthUser authUser)
        {
            return _userDbContext.User
                .Where(u => u.Username == authUser.Username && u.Password == authUser.Password)
                .FirstOrDefault();
        }
    }
}
