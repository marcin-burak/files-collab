using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;



    public List<User> Users { get; } = [];

    public List<UserRole> UserRoles { get; } = [];



    public List<Group> Groups { get; } = [];

    public List<GroupRole> GroupRoles { get; } = [];



    public List<Permission> Permissions { get; } = [];

    public List<RolePermission> RolePermissions { get; } = [];
}

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.Name);
    }
}