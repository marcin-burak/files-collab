using FilesCollab.Web.Dependencies.SqlServer.Application;
using FilesCollab.Web.Dependencies.SqlServer.Application.Entities;
using FilesCollab.Web.Dependencies.SqlServer.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilesCollab.Web.Dependencies.SqlServer;

internal sealed class DatabaseInitialization(IOptionsSnapshot<SqlServerOptions> sqlServerOptions, IWebHostEnvironment environment, ApplicationContext applicationContext, IdentityContext identityContext)
{
    private readonly IOptionsSnapshot<SqlServerOptions> _sqlServerOptions = sqlServerOptions;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ApplicationContext _applicationContext = applicationContext;
    private readonly IdentityContext _identityContext = identityContext;

    public static async ValueTask TryRunDatabaseInitialization(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        using var dependencyInjectionScope = serviceProvider.CreateScope();
        var databaseInitialization = dependencyInjectionScope.ServiceProvider.GetRequiredService<DatabaseInitialization>();

        await databaseInitialization.TryRunDatabaseInitialization(cancellationToken);
        await databaseInitialization.TrySeedData(cancellationToken);
    }

    private async ValueTask TryRunDatabaseInitialization(CancellationToken cancellationToken)
    {
        if (_environment.IsProduction() || _sqlServerOptions.Value.RunMigrationsOnStartup is false)
        {
            return;
        }

        await Task.WhenAll(
            _applicationContext.Database.MigrateAsync(cancellationToken),
            _identityContext.Database.MigrateAsync(cancellationToken)
        );
    }

    private async ValueTask TrySeedData(CancellationToken cancellationToken)
    {
        if (_environment.IsProduction() || _sqlServerOptions.Value.SeedData is false)
        {
            return;
        }



        var anyUserExists = _applicationContext.User.AnyAsync(cancellationToken);
        var anyGroupExists = _applicationContext.Group.AnyAsync(cancellationToken);
        var anyWorkspaceExists = _applicationContext.Workspace.AnyAsync(cancellationToken);

        await Task.WhenAll(
            anyUserExists,
            anyGroupExists,
            anyWorkspaceExists
        );

        if (anyUserExists.Result || anyGroupExists.Result || anyWorkspaceExists.Result)
        {
            return;
        }



        var userA = new User
        {
            Id = Guid.Parse("ad1ca9cb-d1f0-ec98-86fd-cff46e45f672"),
            Username = "User A"
        };

        var userB = new User
        {
            Id = Guid.Parse("22920e04-3ebe-7dd4-7a4a-1accd1e8852a"),
            Username = "User B"
        };

        var userC = new User
        {
            Id = Guid.Parse("37177060-e806-419c-ec00-2266aabfa95d"),
            Username = "User C"
        };



        var groupA = new Group
        {
            Id = Guid.Parse("2cae81d8-7d45-f854-c973-133154ca93c1"),
            Name = "Group A"
        };

        var groupB = new Group
        {
            Id = Guid.Parse("daf2aed6-a302-9348-121d-18d7ab191434"),
            Name = "Group B"
        };

        var groupC = new Group
        {
            Id = Guid.Parse("e249eb8d-6c70-d071-ddc2-c6a7e2ddcab9"),
            Name = "Group C"
        };



        var workspaceA = new Workspace
        {
            Id = Guid.Parse("170e3fe5-b627-e1e0-4b50-17d4f6240816"),
            Name = "Workspace A"
        };

        var workspaceB = new Workspace
        {
            Id = Guid.Parse("0f362fba-9cfb-cd4e-4e99-c9ba07b06dab"),
            Name = "Workspace B"
        };

        var workspaceC = new Workspace
        {
            Id = Guid.Parse("7c471996-8e38-b15c-a24d-a8a04eb924c5"),
            Name = "Workspace C"
        };



        //TODO: Create own passing tables to take over control over many-to-many relationships
        var administratorRole = await _applicationContext.Role.SingleAsync(role => role.Id == Role.Administrator.Id, cancellationToken);



        userA.Roles = new Role[]
        {
            administratorRole
        };

        userA.Groups = new Group[]
        {
            groupA,
            groupB,
            groupC
        };

        userA.Workspaces = new Workspace[]
        {
            workspaceA,
            workspaceB,
            workspaceC
        };



        userB.Groups = new Group[]
        {
            groupA,
            groupB
        };

        userB.Workspaces = new Workspace[]
        {
            workspaceB
        };



        userC.Groups = new Group[]
        {
            groupC
        };



        groupB.Workspaces = new Workspace[]
        {
            workspaceB,
            workspaceC
        };



        groupC.Workspaces = new Workspace[]
        {
            workspaceA,
            workspaceC
        };



        await _applicationContext.AddRangeAsync(
            new[]
            {
                userA,
                userB,
                userC,
            },
            cancellationToken
        );

        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
}
