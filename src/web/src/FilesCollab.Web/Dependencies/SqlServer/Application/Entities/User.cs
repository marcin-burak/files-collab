using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class User
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public ICollection<Group> Groups { get; set; }

    public ICollection<Role> Roles { get; set; }

    public ICollection<Workspace> Workspaces { get; set; }
}


internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(user => user.Username);
    }
}