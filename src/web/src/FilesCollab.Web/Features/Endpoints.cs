using FilesCollab.Web.Features.Authentication;
using FilesCollab.Web.Features.UserManagement.Users;

namespace FilesCollab.Web.Features;

internal static class Endpoints
{
    public static WebApplication MapEndpoints(this WebApplication application)
    {
        application
            .MapGroup("/api/v1/authentication/")
                .WithOpenApi()
                    .MapSignUpEndpoint("sign-up")
                    .MapSignInEndpoint("sign-in");

        application
            .MapGroup("/api/v1/user-management/")
                .RequireAuthorization()
                .WithOpenApi()
                    .MapListUsersEndpoint("users");

        return application;
    }
}
