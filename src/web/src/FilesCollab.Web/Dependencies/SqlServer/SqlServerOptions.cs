using FilesCollab.Web.Dependencies.FluentValidation;
using FluentValidation;

namespace FilesCollab.Web.Dependencies.SqlServer;

internal sealed class SqlServerOptions
{
    public string ApplicationConnectionString { get; set; } = string.Empty;

    public string IdentityConnectionString { get; set; } = string.Empty;

    public bool RunMigrationsOnStartup { get; set; }

    public bool SeedData { get; set; }
}

internal sealed class SqlServerOptionsValidator : AbstractValidator<SqlServerOptions>
{
    public SqlServerOptionsValidator(IWebHostEnvironment environment)
    {
        RuleFor(options => options.ApplicationConnectionString)
            .NotEmpty()
            .Trimmed();

        RuleFor(options => options.IdentityConnectionString)
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