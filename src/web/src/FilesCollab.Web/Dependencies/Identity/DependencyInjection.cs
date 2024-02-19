﻿using FilesCollab.Web.Infrastructure.SqlServer;
using FilesCollab.Web.Infrastructure.SqlServer.Entities;
using Microsoft.AspNetCore.Identity;

namespace FilesCollab.Web.Dependencies.Identity;

internal static class DependencyInjection
{
    public static IServiceCollection AddIdentityDependency(this IServiceCollection services) => services
        .AddIdentityCore<User>()
        .AddEntityFrameworkStores<DatabaseContext>()
        .Services
        .AddAuthentication()
        .AddApplicationCookie()
        .Services;
}
