﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilesCollab.Web.Infrastructure.SqlServer;

internal sealed class DatabaseInitialization(IOptionsSnapshot<SqlServerOptions> sqlServerOptions, IWebHostEnvironment environment, IdentityContext identityContext)
{
    private readonly IOptionsSnapshot<SqlServerOptions> _sqlServerOptions = sqlServerOptions;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly IdentityContext _identityContext = identityContext;

    public static async ValueTask TryRunDatabaseInitialization(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        using var dependencyInjectionScope = serviceProvider.CreateScope();
        var databaseInitialization = dependencyInjectionScope.ServiceProvider.GetRequiredService<DatabaseInitialization>();
        await databaseInitialization.TryRunDatabaseInitialization(cancellationToken);
    }

    private async ValueTask TryRunDatabaseInitialization(CancellationToken cancellationToken)
    {
        if (_environment.IsProduction() || _sqlServerOptions.Value.RunMigrationsOnStartup is false)
        {
            return;
        }

        await _identityContext.Database.MigrateAsync(cancellationToken);
    }
}
