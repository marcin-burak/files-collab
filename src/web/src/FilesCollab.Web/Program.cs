using FilesCollab.Web.Dependencies.FluentValidation;
using FilesCollab.Web.Dependencies.OpenApi;
using FilesCollab.Web.Infrastructure.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFluentValidationDependency()
    .AddOpenApiDependency(builder.Configuration)
    .AddSqlServerDependency(builder.Configuration);

var application = builder.Build();

application
    .UseHttpsRedirection()
    .TryUseOpenApi();

await DatabaseInitialization.TryRunDatabaseInitialization(application.Services, CancellationToken.None);
await application.RunAsync(CancellationToken.None);