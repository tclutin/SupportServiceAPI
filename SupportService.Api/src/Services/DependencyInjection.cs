
using Microsoft.Extensions.DependencyInjection;
using SupportService.Api.Services.AuthService;

namespace SupportService.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
