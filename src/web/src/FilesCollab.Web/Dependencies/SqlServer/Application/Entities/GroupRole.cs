namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class GroupRole
{
    public Guid GroupId { get; set; }

    public Guid RoleId { get; set; }



    public Group Group { get; set; } = null!;

    public Role Role { get; set; } = null!;
}
