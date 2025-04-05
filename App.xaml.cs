namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default <see cref="Application"/>
/// class.
/// </summary>
public sealed partial class App : Application
{
    private readonly IAppActivationService _activationService;

    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="activationService">
    /// The app activation service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public App(IAppActivationService activationService, ILogger<App> logger)
    {
        _activationService = activationService;

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
        _activationService.ActivateAsync(e);
    }
}