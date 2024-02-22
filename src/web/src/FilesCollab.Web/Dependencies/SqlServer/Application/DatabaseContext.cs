using FilesCollab.Web.Dependencies.SqlServer.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilesCollab.Web.Dependencies.SqlServer.Application;

internal sealed class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }

    public DbSet<Group> Group { get; set; }

    public DbSet<Role> Role { get; set; }

    public DbSet<Workspace> Workspace { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Role>()
            .HasData(Entities.Role.Administrator);
    }
}
