using FilesCollab.Web.Infrastructure.SqlServer;
using FilesCollab.Web.Infrastructure.SqlServer.Entities;
using Microsoft.AspNetCore.Identity;

namespace FilesCollab.Web.Dependencies.Identity;

internal static class DependencyInjection
{
    public static IServiceCollection AddIdentityDependency(this IServiceCollection services) => services
        .AddIdentityCore<User>()
        .AddSignInManager()
        .AddEntityFrameworkStores<IdentityContext>()
        .Services
        .AddAuthentication()
        .AddApplicationCookie()
        .Services;
}
