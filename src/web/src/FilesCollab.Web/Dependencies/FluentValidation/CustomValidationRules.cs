using FluentValidation;

namespace FilesCollab.Web.Dependencies.FluentValidation;

internal static class CustomValidationRules
{
    public static IRuleBuilderOptions<T, string> Trimmed<T>(this IRuleBuilder<T, string> ruleBuilder) => ruleBuilder
        .Must(value => value.Length == value.Trim().Length)
        .WithMessage("'{PropertyName}' has to be trimmed.");
}
