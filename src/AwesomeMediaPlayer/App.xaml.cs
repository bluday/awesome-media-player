using AwesomeMediaPlayer.UI.ViewModels.Windows;
using AwesomeMediaPlayer.UI.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the base class.
/// </summary>
public sealed partial class App : Application
{
    private MainWindow? _mainWindow;

    private readonly IContainer _container;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        _container = new Container();

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
        _mainWindow = new MainWindow()
        {
            ViewModel = Ioc.Default.GetRequiredService<MainWindowViewModel>()
        };

        _mainWindow.ViewModel.ApplyLocalizedContent();

        _mainWindow.Activate();
    }
}