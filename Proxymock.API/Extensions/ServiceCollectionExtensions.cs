using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proxymock.API.Database;
using Proxymock.API.Domain.Project;
using Proxymock.API.Options;

namespace Proxymock.API.Extensions
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