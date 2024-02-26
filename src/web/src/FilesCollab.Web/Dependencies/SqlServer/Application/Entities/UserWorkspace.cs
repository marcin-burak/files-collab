using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class UserWorkspace
{
    public Guid UserId { get; set; }

    public Guid WorkspaceId { get; set; }



    public User User { get; set; } = null!;

    public Workspace Workspace { get; set; } = null!;
}

internal sealed class UserWorkspaceConfiguration : IEntityTypeConfiguration<UserWorkspace>
{
    public void Configure(EntityTypeBuilder<UserWorkspace> builder)
    {
        builder.HasKey(userWOrkspace => new { userWOrkspace.UserId, userWOrkspace.WorkspaceId }).IsClustered(false);
    }
}