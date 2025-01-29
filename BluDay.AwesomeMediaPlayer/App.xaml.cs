namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private readonly Lazy<Shell> _shell;

    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="windowService">
    /// The window service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public App(IAppWindowService windowService, ILogger<App> logger)
    {
        _shell = new Lazy<Shell>(windowService.CreateWindow<Shell>);

        _logger = logger;

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _shell.Value.Activate();
    }

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
            .AddSingleton<IAppActivationService, AppActivationService>()
            .AddSingleton<IAppDialogService, AppDialogService>()
            .AddSingleton<IAppNavigationService, AppNavigationService>()
            .AddSingleton<IAppThemeService, AppThemeService>()
            .AddSingleton<IAppWindowService, AppWindowService>();

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