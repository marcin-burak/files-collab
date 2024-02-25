select dbo.[User].Id, Username, [Name] as 'Role' from dbo.[User]
inner join dbo.[UserRoles] on UserId = dbo.[User].[Id]
inner join dbo.[Role] on dbo.[Role].Id = dbo.[UserRoles].RoleId

select dbo.[User].Id, dbo.[User].[Username], [Name] as 'Group' from dbo.[User]
inner join dbo.[UserGroups] on dbo.[UserGroups].UserId = dbo.[User].[Id]
inner join dbo.[Group] on dbo.[Group].Id = dbo.[UserGroups].[GroupId]