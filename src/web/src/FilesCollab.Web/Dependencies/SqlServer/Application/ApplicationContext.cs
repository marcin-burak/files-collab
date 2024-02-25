using FilesCollab.Web.Dependencies.SqlServer.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FilesCollab.Web.Dependencies.SqlServer.Application;

internal sealed class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }

    public DbSet<UserGroup> UserGroups { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<UserWorkspace> UserWorkspaces { get; set; }

    public DbSet<Group> Group { get; set; }

    public DbSet<GroupRole> GroupRoles { get; set; }

    public DbSet<GroupWorkspace> GroupWorkspaces { get; set; }

    public DbSet<Role> Role { get; set; }

    public DbSet<RolePermission> RolePermissions { get; set; }

    public DbSet<Permission> Permission { get; set; }

    public DbSet<Workspace> Workspace { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        //TODO: Not convention based?
        //TODO: Move to join tables configuration?
        modelBuilder.Entity<User>()
            .HasMany(user => user.Groups)
            .WithMany(group => group.Users)
            .UsingEntity<UserGroup>();

        modelBuilder.Entity<User>()
            .HasMany(user => user.Roles)
            .WithMany(role => role.Users)
            .UsingEntity<UserRole>();

        modelBuilder.Entity<User>()
            .HasMany(user => user.Workspaces)
            .WithMany(workspace => workspace.Users)
            .UsingEntity<UserWorkspace>();



        modelBuilder.Entity<Group>()
            .HasMany(group => group.Roles)
            .WithMany(role => role.Groups)
            .UsingEntity<GroupRole>();

        modelBuilder.Entity<Group>()
            .HasMany(group => group.Workspaces)
            .WithMany(workspace => workspace.Groups)
            .UsingEntity<GroupWorkspace>();



        modelBuilder.Entity<Role>()
            .HasMany(role => role.Permissions)
            .WithMany(permission => permission.Roles)
            .UsingEntity<RolePermission>();
    }
}
