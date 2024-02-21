using FilesCollab.Web.Dependencies.SqlServer.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilesCollab.Web.Dependencies.SqlServer.Application;

internal sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
}
