namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class UserPermission
{
    public Guid UserId { get; set; }

    public string PermissionId { get; set; } = null!;



    public User User { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}
