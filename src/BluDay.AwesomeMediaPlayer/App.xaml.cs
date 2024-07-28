namespace BluDay.AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private MainWindow? _mainWindow;

    private readonly ResourceLoader _resourceLoader = new();

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() => InitializeComponent();

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _mainWindow = new MainWindow
        {
            Title                      = _resourceLoader.GetString("MainWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = "Assets/Icon-64.ico",
            Size                       = new SizeInt32(1600, 1280),
            DefaultAlignment           = ContentAlignment.MiddleCenter
        };

        _mainWindow.Activate();
    }
}