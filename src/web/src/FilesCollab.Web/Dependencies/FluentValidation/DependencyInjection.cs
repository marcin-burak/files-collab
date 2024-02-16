using FluentValidation;
using System.Reflection;

namespace FilesCollab.Web.Dependencies.FluentValidation;

internal static class DependencyInjection
{
    public static IServiceCollection AddFluentValidationDependency(this IServiceCollection services) => services
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), lifetime: ServiceLifetime.Singleton, filter: scan => scan.ValidatorType.FullName!.StartsWith("FilesCollab"), includeInternalTypes: true);
}
