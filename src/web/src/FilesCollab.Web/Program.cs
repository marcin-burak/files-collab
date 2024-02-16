using FilesCollab.Web.Dependencies.FluentValidation;
using FilesCollab.Web.Infrastructure.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddFluentValidationDependency()
    .AddSqlServerDependency(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var dependencyInjectionScope = app.Services.CreateScope())
{
    var databaseInitialization = dependencyInjectionScope.ServiceProvider.GetRequiredService<DatabaseInitialization>();
    await databaseInitialization.TryRunDatabaseInitialization(CancellationToken.None);
}

await app.RunAsync(CancellationToken.None);