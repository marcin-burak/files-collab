namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class GroupPermission
{
    public Guid GroupId { get; set; }

    public string PermissionId { get; set; } = null!;



    public Group Group { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}
