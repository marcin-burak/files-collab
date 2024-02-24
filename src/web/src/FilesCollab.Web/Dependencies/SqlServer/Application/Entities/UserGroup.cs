namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class UserGroup
{
    public Guid UserId { get; set; }

    public Guid GroupId { get; set; }



    public User User { get; set; } = null!;

    public Group Group { get; set; } = null!;
}
