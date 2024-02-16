using FilesCollab.Web.Dependencies.Options;

namespace FilesCollab.Web.Dependencies.OpenApi;

internal static class DependencyInjection
{
    public static IServiceCollection AddOpenApiDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsByConvention<OpenApiOptions>();

        var openApiOptions = configuration.GetOptionsByConvention<OpenApiOptions>();
        if (openApiOptions.Disabled)
        {
            return services;
        }

        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Version = "v1",
                    Title = "Files Collab API",
                    Description = "The main web API for Files Collab solution."
                });
            });
    }
}
