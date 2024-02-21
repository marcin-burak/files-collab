using FilesCollab.Web.Dependencies.FluentValidation;
using FilesCollab.Web.Dependencies.OpenApi;
using FilesCollab.Web.Dependencies.SqlServer;
using FilesCollab.Web.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication().Services
    .AddAuthorization()
    .AddSqlServerDependency(builder.Configuration)
    .AddFluentValidationDependency()
    .AddOpenApiDependency(builder.Configuration);

var application = builder.Build();

application
    .UseHttpsRedirection()
    .TryUseOpenApi()
    .UseAuthentication()
    .UseAuthorization();

application.MapEndpoints();

await DatabaseInitialization.TryRunDatabaseInitialization(application.Services, CancellationToken.None);
await application.RunAsync(CancellationToken.None);