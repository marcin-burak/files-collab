using FluentValidation;
using Microsoft.Extensions.Options;

namespace FilesCollab.Web.Dependencies.FluentValidation;

internal static class OptionsBuilderFluentValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateWithFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(serviceProvider =>
            new FluentValidationOptions<TOptions>(optionsBuilder.Name, serviceProvider.GetRequiredService<IValidator<TOptions>>())
        );
        return optionsBuilder;
    }
}

internal sealed class FluentValidationOptions<TOptions>(string? name, IValidator<TOptions> validator) : IValidateOptions<TOptions> where TOptions : class
{
    private readonly IValidator<TOptions> _validator = validator;

    public string? Name { get; } = name;

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        if (Name is not null && Name != name)
        {
            return ValidateOptionsResult.Skip;
        }

        ArgumentNullException.ThrowIfNull(options);

        var validationResult = _validator.Validate(options);
        if (validationResult.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var optionsTypeName = typeof(TOptions).Name;
        var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToArray();

        return ValidateOptionsResult.Fail(errors);
    }
}