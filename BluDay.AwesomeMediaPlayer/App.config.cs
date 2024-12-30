namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    /// <summary>
    /// Configures the logging factory and provider through the provided builder instance.
    /// </summary>
    /// <param name="logging">
    /// The logging builder instance.
    /// </param>
    public static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug);
    }

    /// <summary>
    /// Configures and registers platform-specific service descriptors.
    /// </summary>
    /// <param name="services">
    /// The service descriptor collection.
    /// </param>
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddLogging(ConfigureLogging);

        services
            .AddSingleton<AppActivationService>()
            .AddSingleton<AppDialogService>()
            .AddSingleton<AppNavigationService>()
            .AddSingleton<AppThemeService>()
            .AddSingleton<AppWindowService>();

        services
            .AddSingleton<ImplementationProvider<IBluWindow>>();

        services
            .AddSingleton(WeakReferenceMessenger.Default);

        services
            .AddSingleton<App>()
            .AddSingleton<ResourceLoader>();

        services
            .AddTransient<Shell>();

        services
            .AddViews()
            .AddViewModels();
    }
}
