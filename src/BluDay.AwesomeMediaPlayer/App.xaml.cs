namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Shell? _mainWindow;

    private readonly DispatcherQueue _dispatcherQueue;

    private readonly ResourceLoader _resourceLoader;

    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    /// <param name="dispatcherQueue">
    /// The main dispatcher queue for the app.
    /// </param>
    /// <param name="serviceProvider">
    /// The service provider for the root scope of the DI container.
    /// </param>
    public App(
        DispatcherQueue  dispatcherQueue,
        ResourceLoader   resourceLoader,
        IServiceProvider serviceProvider)
    {
        _dispatcherQueue = dispatcherQueue;

        _resourceLoader = resourceLoader;

        _serviceProvider = serviceProvider;

        InitializeComponent();
    }

    /// <summary>
    /// Creates, configures and activates the main window.
    /// </summary>
    private void CreateMainWindow()
    {
        if (_mainWindow is not null) return;

        _mainWindow = _serviceProvider.GetRequiredService<Shell>();

        ShellViewModel viewModel = _mainWindow.ViewModel;

        viewModel.DefaultConfiguration = new WindowConfiguration
        {
            Title                      = _resourceLoader.GetString("MainWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = "Assets/Icon-64.ico",
            Size                       = new SizeInt32(1600, 1000),
            Alignment                  = ContentAlignment.MiddleCenter
        };

        viewModel.ApplyDefaultConfiguration();
        viewModel.Activate();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        CreateMainWindow();
    }
}