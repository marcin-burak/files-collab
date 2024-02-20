using FilesCollab.Web.Infrastructure.SqlServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilesCollab.Web.Infrastructure.SqlServer;

internal sealed class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityUserContext<User, int, IdentityUserClaim<int>, IdentityUserLogin<int>, IdentityUserToken<int>>(options)
{
}