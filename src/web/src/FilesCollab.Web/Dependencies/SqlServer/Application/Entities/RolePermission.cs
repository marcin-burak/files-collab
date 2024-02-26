using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class RolePermission
{
    public Guid RoleId { get; set; }

    public string PermissionId { get; set; } = null!;



    public Role Role { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(rolePermission => new { rolePermission.RoleId, rolePermission.PermissionId }).IsClustered(false);
    }
}