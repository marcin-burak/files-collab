using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class UserRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }



    public User User { get; set; } = null!;

    public Role Role { get; set; } = null!;
}

internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(serRole => new { serRole.UserId, serRole.RoleId }).IsClustered(false);
    }
}