using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;



    public List<Group> Groups { get; } = [];

    public List<UserGroup> UserGroups { get; } = [];

    public List<Role> Roles { get; } = [];

    public List<UserRole> UserRoles { get; } = [];

    public List<Workspace> Workspaces { get; } = [];

    public List<UserWorkspace> UserWorkspaces { get; } = [];
}


internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(user => user.Username);
    }
}