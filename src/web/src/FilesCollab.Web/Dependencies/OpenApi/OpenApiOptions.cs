using FluentValidation;

namespace FilesCollab.Web.Dependencies.OpenApi;

internal sealed class OpenApiOptions
{
    public bool Disabled { get; set; }
}

internal sealed class OpenApiOptionsValidator : AbstractValidator<OpenApiOptions>
{
    public OpenApiOptionsValidator(IWebHostEnvironment environment)
    {
        When(_ => environment.IsProduction(), () =>
        {
            RuleFor(options => options.Disabled)
                .Equal(true)
                .WithMessage("Open API features have to be disabled in production environment.");
        });
    }
}