namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class GroupWorkspace
{
    public Guid GroupId { get; set; }

    public Guid WorkspaceId { get; set; }



    public Group Group { get; set; } = null!;

    public Workspace Workspace { get; set; } = null!;
}
