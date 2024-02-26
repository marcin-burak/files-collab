using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class GroupWorkspace
{
    public Guid GroupId { get; set; }

    public Guid WorkspaceId { get; set; }



    public Group Group { get; set; } = null!;

    public Workspace Workspace { get; set; } = null!;
}

internal sealed class GroupWorkspaceConfiguration : IEntityTypeConfiguration<GroupWorkspace>
{
    public void Configure(EntityTypeBuilder<GroupWorkspace> builder)
    {
        builder.HasKey(groupWorkspace => new { groupWorkspace.GroupId, groupWorkspace.WorkspaceId }).IsClustered(false);
    }
}