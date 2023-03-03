using Microsoft.EntityFrameworkCore;
using SupportService.Api.src.Entities;

namespace SupportService.Api.src.Infrastructure.Repository
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }
}
