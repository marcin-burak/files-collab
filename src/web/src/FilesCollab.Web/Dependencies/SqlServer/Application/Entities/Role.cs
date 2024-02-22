﻿namespace FilesCollab.Web.Dependencies.SqlServer.Application.Entities;

internal sealed class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<Group> Groups { get; set; }

    public static Role Administrator { get; } = new()
    {
        Id = Guid.Parse("9d058f91-a45f-4059-bbf5-0581973d902d"),
        Name = "Administator"
    };
}