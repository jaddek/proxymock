using Calendario.API.Database;
using Calendario.API.Domain.Project;
using Calendario.API.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Calendario.API.Extensions
{

    public static class ServiceCollectionExtensions
    {
        internal static void AddDefaultDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<DBOptions>(
                configuration.GetSection(DBOptions.ConfigKey)
            );

            DBOptions DatabaseOptions = services.BuildServiceProvider().GetRequiredService<IOptions<DBOptions>>().Value;

            services.AddDbContext<DBContext>(options => options.UseNpgsql(DatabaseOptions.ToString()));
            services.AddScoped<ProjectRepository, ProjectRepository>();

        }
    }
}