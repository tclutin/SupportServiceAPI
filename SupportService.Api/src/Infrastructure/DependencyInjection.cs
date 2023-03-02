﻿
using Microsoft.Extensions.DependencyInjection;
using SupportService.Api.Services.AuthService;

namespace SupportService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
