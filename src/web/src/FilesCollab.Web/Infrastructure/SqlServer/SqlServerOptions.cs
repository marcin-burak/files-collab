using FilesCollab.Web.Dependencies.FluentValidation;
using FluentValidation;

namespace FilesCollab.Web.Infrastructure.SqlServer;

internal sealed class SqlServerOptions
{
    public string ConnectionString { get; set; } = string.Empty;

    public bool RunMigrationsOnStartup { get; set; }
}

internal sealed class SqlServerOptionsValidator : AbstractValidator<SqlServerOptions>
{
    public SqlServerOptionsValidator(IWebHostEnvironment environment)
    {
        RuleFor(options => options.ConnectionString)
            .NotEmpty()
            .Trimmed();

        When(_ => environment.IsProduction(), () =>
        {
            RuleFor(options => options.RunMigrationsOnStartup)
                .Equal(false)
                .WithMessage("'{PropertyName}' has to be set to false in production environment.");
        });
    }
}