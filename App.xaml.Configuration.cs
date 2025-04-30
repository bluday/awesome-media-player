namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Contains methods for configuring logging and services in the application.
/// </summary>
public sealed partial class App
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
            .AddDebug();

        logging
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
            .AddMemoryCache();

        services
            .AddSingleton<WeakReferenceMessenger>();

        services
            .AddSingleton<App>()
            .AddSingleton<ResourceLoader>();

        services
            .AddSingleton<ImplementationProvider<Window>>();

        services
            .AddDesktopClientServices();

        services
            .AddViews()
            .AddViewModels()
            .AddWindows();
    }
}