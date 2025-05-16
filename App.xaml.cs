namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default <see cref="Application"/>
/// class.
/// </summary>
public sealed partial class App : Application
{
    private readonly IAppActivationService _activationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="activationService">
    /// The app activation service.
    /// </param>
    public App(IAppActivationService activationService)
    {
        _activationService = activationService;

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