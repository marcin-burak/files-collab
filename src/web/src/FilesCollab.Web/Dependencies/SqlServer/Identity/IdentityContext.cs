using FilesCollab.Web.Dependencies.SqlServer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilesCollab.Web.Dependencies.SqlServer.Identity;

internal sealed class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityUserContext<Account, int, IdentityUserClaim<int>, IdentityUserLogin<int>, IdentityUserToken<int>>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Account>().ToTable("Account");
        builder.Entity<IdentityUserClaim<int>>().ToTable("Claim");
        builder.Entity<IdentityUserLogin<int>>().ToTable("Login");
        builder.Entity<IdentityUserToken<int>>().ToTable("Token");
    }
}