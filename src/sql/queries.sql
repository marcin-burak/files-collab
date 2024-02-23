select dbo.[User].Id, Username, [Name] as 'Role' from dbo.[User]
inner join dbo.[RoleUser] on UsersId = dbo.[User].[Id]
inner join dbo.[Role] on dbo.[Role].Id = RolesId

select dbo.[User].Id, dbo.[User].[Username], [Name] as 'Group' from dbo.[User]
inner join dbo.[GroupUser] on UsersId = dbo.[User].[Id]
inner join dbo.[Group] on dbo.[Group].Id = dbo.[GroupUser].[GroupsId]