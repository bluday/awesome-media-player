using AwesomeMediaPlayer.UI.Windows;
using Microsoft.UI.Xaml;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the base class.
/// </summary>
public sealed partial class App : Application
{
    private MainWindow? _mainWindow;

    private readonly Container _container = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
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
        _mainWindow = new MainWindow();

        _mainWindow.ViewModel.ApplyLocalizedContent();

        _mainWindow.ApplyDefaultConfiguration();
        _mainWindow.Activate();
    }
}