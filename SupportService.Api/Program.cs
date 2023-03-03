
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SupportService.Api.Infrastructure.Repository;
using SupportService.Api.src.Infrastructure.Repository;
using SupportService.Api.src.Services.UserService;
using System.Text;
bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
{
    if (expires != null)
    {
        return expires > DateTime.UtcNow;
    }
    return false;
}

//return WEbApplicationBuilder
var builder = WebApplication.CreateBuilder(args);
{
    IConfiguration configuration = builder.Configuration;

    builder.Services.AddDbContext<UserDbContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SupportService.Api")));

    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            ValidIssuer = configuration["JWT:Issuer"],

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = false,
                            ValidAudience = configuration["JWT:Audience"],

                            // будет ли валидироваться время существования
                            ValidateLifetime = true,
                            LifetimeValidator = CustomLifetimeValidator,
                            RequireExpirationTime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                            ValidateIssuerSigningKey = true,
                        };
                    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

//return WebApplication
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(builder => builder.AllowAnyOrigin());
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
