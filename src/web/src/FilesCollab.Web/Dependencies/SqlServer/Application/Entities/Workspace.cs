using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class Workspace
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;



    public List<User> Users { get; } = [];

    public List<UserWorkspace> UserWorkspaces { get; } = [];



    public List<Group> Groups { get; } = [];

    public List<GroupWorkspace> GroupWorkspaces { get; } = [];
}

internal sealed class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.HasIndex(workspace => workspace.Name);
    }
}