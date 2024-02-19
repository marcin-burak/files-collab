using FilesCollab.Web.Infrastructure.SqlServer.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilesCollab.Web.Features.Authentication;

internal static class SignUp
{
    public static IEndpointRouteBuilder MapSignUpEndpoint(this IEndpointRouteBuilder builder, string uriPath)
    {
        builder.MapPost(uriPath, async Task<Results<NoContent, StatusCodeHttpResult>> ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] SignUpRequest request, UserManager<User> userManager) =>
        {
            var userCreationResult = await userManager.CreateAsync(new()
            {
                UserName = request.Username
            }, request.Password.ToString() ?? throw new InvalidOperationException("Password failed."));

            if (userCreationResult.Succeeded)
            {
                return TypedResults.NoContent();
            }

            return TypedResults.StatusCode(500);
        });

        return builder;
    }
}

internal sealed record SignUpRequest
{
    public required string Username { get; init; }

    //TODO: SecureString type?
    public required string Password { get; init; }
}
