using Microsoft.Extensions.Options;

namespace FilesCollab.Web.Dependencies.OpenApi;

internal static class Middleware
{
    public static IApplicationBuilder TryUseOpenApi(this IApplicationBuilder application)
    {
        var openApiOptions = application.ApplicationServices.GetRequiredService<IOptions<OpenApiOptions>>();
        if (openApiOptions.Value.Disabled)
        {
            return application;
        }

        return application
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Files Collab | Open API";
            });
    }
}
