using FilesCollab.Web.Dependencies.Options;
using FilesCollab.Web.Dependencies.SqlServer.Application;
using FilesCollab.Web.Dependencies.SqlServer.Identity;
using FilesCollab.Web.Dependencies.SqlServer.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FilesCollab.Web.Dependencies.SqlServer;

internal static class DependencyInjection
{
    public static IServiceCollection AddSqlServerDependency(this IServiceCollection services, IConfiguration configuration) => services
        .AddOptionsByConvention<SqlServerOptions>()
        .AddApplicationDatabase(configuration)
        .AddIdentityDatabaseAndServices(configuration)
        .AddScoped<DatabaseInitialization>();

    private static IServiceCollection AddApplicationDatabase(this IServiceCollection services, IConfiguration configuration) => services
        .AddSqlServer<DatabaseContext>(configuration.GetOptionsByConvention<SqlServerOptions>().ApplicationConnectionString);

    private static IServiceCollection AddIdentityDatabaseAndServices(this IServiceCollection services, IConfiguration configuration) => services
        .AddSqlServer<IdentityContext>(configuration.GetOptionsByConvention<SqlServerOptions>().IdentityConnectionString)
        .AddIdentityCore<Account>()
        .AddSignInManager()
        .AddEntityFrameworkStores<IdentityContext>()
        .Services
        .AddAuthentication()
        .AddApplicationCookie()
        .Services;
}
