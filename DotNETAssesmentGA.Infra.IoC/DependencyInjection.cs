using DotNETAssesmentGA.Application.Mappings;
using DotNETAssesmentGA.Domain.Interfaces;
using DotNETAssesmentGA.Infra.Data;
using DotNETAssesmentGA.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace DotNETAssesmentGA.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                this IServiceCollection services,
                IConfiguration configuration
            )
        {
            Assembly myHandlers = AppDomain.CurrentDomain.Load("DotNETAssesmentGA.Application");

            services.AddDbContext<ApplicationDbContextSQL>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContextSQL).Assembly.FullName))
                );

            IConfigurationSection mongoConfigurationSection = configuration.GetSection("MongoDatabaseConfiguration");

            services.Configure<MongoDatabaseConfiguration>(opt =>
            {
                opt.ConnectionString = configuration.GetSection("ConnectionString").Value;
                opt.DatabaseName = configuration.GetSection("DB_DotNETAssesmentGA").Value;
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddSingleton<IMongoDatabaseConfiguration>(opt => opt.GetRequiredService<IOptions<MongoDatabaseConfiguration>>().Value);

            return services;
        }
    }
}