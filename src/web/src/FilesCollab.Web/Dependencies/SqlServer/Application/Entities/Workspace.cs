namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class Workspace
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<Group> Groups { get; set; }
}
