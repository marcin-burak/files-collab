using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class GroupRole
{
    public Guid GroupId { get; set; }

    public Guid RoleId { get; set; }



    public Group Group { get; set; } = null!;

    public Role Role { get; set; } = null!;
}

internal sealed class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
{
    public void Configure(EntityTypeBuilder<GroupRole> builder)
    {
        builder.HasKey(groupRole => new { groupRole.GroupId, groupRole.RoleId }).IsClustered(false);
    }
}