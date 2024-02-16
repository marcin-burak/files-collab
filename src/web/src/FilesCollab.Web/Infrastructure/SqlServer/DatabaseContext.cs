using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilesCollab.Web.Infrastructure.SqlServer;

internal sealed class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<IdentityUser>(options)
{
}