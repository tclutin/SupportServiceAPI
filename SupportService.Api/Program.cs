//return WEbApplicationBuilder
using SupportService.Infrasctructure;
using SupportService.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddServices();
    builder.Services.AddInfrasctructure();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

//return WEbApplication
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
