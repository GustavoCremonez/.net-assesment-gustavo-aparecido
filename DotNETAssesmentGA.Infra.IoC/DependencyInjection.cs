using DotNETAssesmentGA.Application.Interfaces;
using DotNETAssesmentGA.Application.Mappings;
using DotNETAssesmentGA.Application.Services;
using DotNETAssesmentGA.Domain.Interfaces;
using DotNETAssesmentGA.Infra.Data;
using DotNETAssesmentGA.Infra.Data.Contexts;
using DotNETAssesmentGA.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DotNETAssesmentGA.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                this IServiceCollection services,
                IConfiguration configuration
            )
        {
            services.AddDbContext<ApplicationDbContextSQL>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContextSQL).Assembly.FullName))
                );

            services.Configure<MongoDatabaseConfiguration>(opt =>
            {
                IConfigurationSection section = configuration.GetSection("MongoDatabaseConfiguration");

                opt.ConnectionString = section["ConnectionString"];
                opt.DatabaseName = section["DatabaseName"];
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddSingleton<IMongoDatabaseConfiguration>(opt => opt.GetRequiredService<IOptions<MongoDatabaseConfiguration>>().Value);
            services.AddScoped<IProductMongoRepository, ProductMongoRepository>();
            services.AddScoped<IProductSQLRepository, ProductoSQLRepository>();
            services.AddScoped<IProductServiceMongo, ProductServiceMongo>();
            services.AddScoped<IProductServiceSQL, ProductServiceSQL>();
            services.AddScoped<IMessengerSender, MessengerSender>();

            return services;
        }
    }
}