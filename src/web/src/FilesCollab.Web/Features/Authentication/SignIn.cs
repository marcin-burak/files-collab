using FilesCollab.Web.Infrastructure.SqlServer.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilesCollab.Web.Features.Authentication;

internal static class SignIn
{
    public static IEndpointRouteBuilder MapSignInEndpoint(this IEndpointRouteBuilder builder, string uriPath)
    {
        //TODO: Test empty body behavior
        //TODO: Log request/response on error
        builder.MapPost(uriPath, async Task<Results<NoContent, UnauthorizedHttpResult>> ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] SignInRequest request, [FromServices] SignInManager<User> signInManager) =>
        {
            var signInResult = await signInManager.PasswordSignInAsync(request.Username, request.Password, isPersistent: true, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                return TypedResults.NoContent();
            }

            return TypedResults.Unauthorized();
        });

        return builder;
    }
}

//TODO: Data protection on logging?
internal sealed record SignInRequest
{
    public required string Username { get; init; }

    //TODO: SecureString type?
    public required string Password { get; init; }
}