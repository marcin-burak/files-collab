using FilesCollab.Web.Dependencies.Options;

namespace FilesCollab.Web.Infrastructure.SqlServer;

internal static class DependencyInjection
{
    public static IServiceCollection AddSqlServerDependency(this IServiceCollection services, IConfiguration configuration) => services
        .AddOptionsByConvention<SqlServerOptions>()
        .AddScoped<DatabaseInitialization>()
        .AddSqlServer<IdentityContext>(configuration.GetOptionsByConvention<SqlServerOptions>().ConnectionString);
}
