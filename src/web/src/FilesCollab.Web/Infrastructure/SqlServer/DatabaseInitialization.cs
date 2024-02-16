﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilesCollab.Web.Infrastructure.SqlServer;

internal sealed class DatabaseInitialization(IOptionsSnapshot<SqlServerOptions> sqlServerOptions, IWebHostEnvironment environment, DatabaseContext databaseContext)
{
    private readonly IOptionsSnapshot<SqlServerOptions> _sqlServerOptions = sqlServerOptions;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly DatabaseContext _databaseContext = databaseContext;

    public async ValueTask TryRunDatabaseInitialization(CancellationToken cancellationToken)
    {
        if (_environment.IsProduction() || _sqlServerOptions.Value.RunMigrationsOnStartup is false)
        {
            return;
        }

        await _databaseContext.Database.MigrateAsync(cancellationToken);
    }
}