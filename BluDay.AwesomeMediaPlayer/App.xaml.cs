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
    public App(AppWindowService windowService, ILogger<App> logger)
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
}
