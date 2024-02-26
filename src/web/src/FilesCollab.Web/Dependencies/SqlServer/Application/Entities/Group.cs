using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;



    public List<User> Users { get; } = [];

    public List<UserGroup> UserGroups { get; } = [];

    public List<Role> Roles { get; } = [];

    public List<GroupRole> GroupRoles { get; } = [];

    public List<Workspace> Workspaces { get; } = [];

    public List<GroupWorkspace> GroupWorkspaces { get; } = [];
}

internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(group => group.Id).IsClustered(false);
        builder.HasIndex(group => group.Name);
    }
}