using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class Permission
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;



    public List<Role> Roles { get; } = [];

    public List<RolePermission> RolePermissions { get; } = [];



    public static Permission ManageWorkspaces => new()
    {
        Id = "MANAGE_WORKSPACES",
        Name = "Manage workspaces",
        Description = "Manage all workspaces."
    };
}

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(permission => permission.Id);
        builder.HasIndex(permission => permission.Name);

        builder.HasData(Permission.ManageWorkspaces);
    }
}