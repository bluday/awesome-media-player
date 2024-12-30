namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// A utility class for managing the DI (Dependency Injection) container of the app.
/// </summary>
public static class Container
{
    private static IServiceProvider _rootServiceProvider = null!;

    /// <summary>
    /// Gets the root service provider for the DI container.
    /// </summary>
    /// <remarks>
    /// The container gets created if null.
    /// </remarks>
    public static IServiceProvider ServiceProvider
    {
        get => _rootServiceProvider ??= Create();
    }

    /// <summary>
    /// Creates the service provider with all of the registered app services.
    /// </summary>
    /// <returns>
    /// The root service provider instance.
    /// </returns>
    private static IServiceProvider Create()
    {
        ServiceCollection services = new();

        App.ConfigureServices(services);

        return services.BuildServiceProvider();
    }
}