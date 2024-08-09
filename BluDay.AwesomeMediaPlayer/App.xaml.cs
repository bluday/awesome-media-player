namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private Shell? _mainWindow;

    private readonly AppWindowService _windowService;

    private readonly ILogger _logger;

    private readonly DispatcherQueue _dispatcherQueue;

    private readonly ResourceLoader _resourceLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="windowService">
    /// The window service.
    /// </param>
    /// <param name="dispatcherQueue">
    /// The main <see cref="DispatcherQueue"/> instance for the app.
    /// </param>
    /// <param name="resourceLoader">
    /// The default app resource loader instance.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public App(
        AppWindowService windowService,
        DispatcherQueue  dispatcherQueue,
        ResourceLoader   resourceLoader,
        ILogger<App>     logger)
    {
        _windowService = windowService;

        _logger = logger;

        _dispatcherQueue = dispatcherQueue;

        _resourceLoader = resourceLoader;

        InitializeComponent();
    }

    /// <summary>
    /// Creates a new <see cref="IWindow"/> instance for the main window.
    /// </summary>
    /// <remarks>
    /// Returns if <see cref="_mainWindow"/> is not null.
    /// </remarks>
    private void CreateMainWindow()
    {
        if (_mainWindow is not null) return;

        _mainWindow = _windowService.CreateWindow<Shell>();

        ShellViewModel viewModel = _mainWindow.ViewModel;

        viewModel.DefaultConfiguration = new WindowConfiguration
        {
            Title                      = _resourceLoader.GetString("MainWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = "ms-appx:///Assets/Icon-64.ico",
            Size                       = new SizeInt32(1600, 1200),
            Alignment                  = ContentAlignment.MiddleCenter
        };

        viewModel.ApplyDefaultConfiguration();
        viewModel.Activate();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _dispatcherQueue.TryEnqueue(CreateMainWindow);
    }
}
