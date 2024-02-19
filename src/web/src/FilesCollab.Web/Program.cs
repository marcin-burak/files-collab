using FilesCollab.Web.Dependencies.FluentValidation;
using FilesCollab.Web.Dependencies.Identity;
using FilesCollab.Web.Dependencies.OpenApi;
using FilesCollab.Web.Features;
using FilesCollab.Web.Infrastructure.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication().Services
    .AddAuthorization()
    .AddIdentityDependency()
    .AddFluentValidationDependency()
    .AddOpenApiDependency(builder.Configuration)
    .AddSqlServerDependency(builder.Configuration);

var application = builder.Build();

application
    .UseHttpsRedirection()
    .TryUseOpenApi()
    .UseAuthentication()
    .UseAuthorization();

application.MapEndpoints();

await DatabaseInitialization.TryRunDatabaseInitialization(application.Services, CancellationToken.None);
await application.RunAsync(CancellationToken.None);