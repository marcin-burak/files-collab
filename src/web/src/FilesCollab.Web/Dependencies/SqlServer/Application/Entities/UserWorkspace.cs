namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class UserWorkspace
{
    public Guid UserId { get; set; }

    public Guid WorkspaceId { get; set; }



    public User User { get; set; } = null!;

    public Workspace Workspace { get; set; } = null!;
}
