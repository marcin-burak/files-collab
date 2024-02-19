using Microsoft.AspNetCore.Identity;

namespace FilesCollab.Web.Infrastructure.SqlServer.Entities;

internal sealed class User : IdentityUser<Guid>
{
}
