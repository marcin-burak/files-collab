namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class RolePermission
{
    public Guid RoleId { get; set; }

    public string PermissionId { get; set; } = null!;



    public Role Role { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}
