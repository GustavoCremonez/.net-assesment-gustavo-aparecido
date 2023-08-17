using DotNETAssesmentGA.API;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Startup startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();