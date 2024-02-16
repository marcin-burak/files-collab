using FilesCollab.Web.Dependencies.FluentValidation;

namespace FilesCollab.Web.Dependencies.Options;

internal static class Extensions
{
    public static IServiceCollection AddOptionsByConvention<TOptions>(this IServiceCollection services, bool skipStartupValidation = false) where TOptions : class, new()
    {
        var options = services.AddOptions<TOptions>().BindConfiguration(GetConfigurationSectionName<TOptions>());

        if (skipStartupValidation)
        {
            return services;
        }

        options.ValidateWithFluentValidation().ValidateOnStart();

        return services;
    }

    public static TOptions GetOptionsByConvention<TOptions>(this IConfiguration configuration) where TOptions : class, new()
    {
        var options = Activator.CreateInstance<TOptions>();

        configuration.Bind(GetConfigurationSectionName<TOptions>(), options);

        return options;
    }

    private static string GetConfigurationSectionName<TOptions>() where TOptions : class, new()
    {
        var optionsTypeNameWithoutOptionsSuffix = typeof(TOptions).Name[..^7];
        return optionsTypeNameWithoutOptionsSuffix;
    }
}
