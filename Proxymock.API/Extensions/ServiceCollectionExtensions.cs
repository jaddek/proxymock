using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proxymock.API.Database;
using Proxymock.API.Domain.Project;
using Proxymock.API.Options;

namespace Proxymock.API.Extensions;

public static class ServiceCollectionExtensions
{
    private static void AddDefaultDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<DBOptions>(
            configuration.GetSection(DBOptions.ConfigKey)
        );

        DBOptions databaseOptions = services.BuildServiceProvider().GetRequiredService<IOptions<DBOptions>>().Value;

        services.AddDbContext<DBContext>(options => options.UseNpgsql(databaseOptions.ToString()));
        services.AddScoped<ProjectRepository, ProjectRepository>();
    }

    internal static void AddDefaultServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDefaultDbContext(configuration);
        services.AddProblemDetails();
    }
}