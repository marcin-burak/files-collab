using FilesCollab.Web.Features.Authentication;

namespace FilesCollab.Web.Features;

internal static class Endpoints
{
    public static WebApplication MapEndpoints(this WebApplication application)
    {
        application
           .MapGroup("/api/v1/authentication/")
           .MapSignUpEndpoint("sign-up")
           .MapSignInEndpoint("sign-in");

        return application;
    }
}
