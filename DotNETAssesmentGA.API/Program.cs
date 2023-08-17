using DotNETAssesmentGA.API;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Startup startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

WebApplication app = builder.Build();

IApiVersionDescriptionProvider apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseCors(builder => builder.AllowAnyMethod()
                              .AllowAnyOrigin()
                              .AllowAnyHeader());

app.MapControllers();

app.Run();