using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class UserGroup
{
    public Guid UserId { get; set; }

    public Guid GroupId { get; set; }



    public User User { get; set; } = null!;

    public Group Group { get; set; } = null!;
}

internal sealed class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasKey(userGroup => new { userGroup.UserId, userGroup.GroupId }).IsClustered(false);
    }
}