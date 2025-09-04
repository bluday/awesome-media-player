using AwesomeMediaPlayer.UI.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the base class.
/// </summary>
public sealed partial class App : Application
{
    private MainWindow? _mainWindow;

    private readonly ServiceProvider _rootServiceProvider;

    private readonly IMessenger _messenger;

    private readonly ILogger<App> _logger;

    private readonly Func<MainWindow> _mainWindowFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        _rootServiceProvider = Container.Create();

        Ioc.Default.ConfigureServices(_rootServiceProvider);

        _messenger         = Resolve<WeakReferenceMessenger>();
        _mainWindowFactory = Resolve<Func<MainWindow>>();
        _logger            = Resolve<ILogger<App>>();
    }

    /// <summary>
    /// Shortcut method for resolving a required service of thte specified type.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type.
    /// </typeparam>
    /// <returns>
    /// The resolved service instance.
    /// </returns>
    private TService Resolve<TService>() where TService : class
    {
        return _rootServiceProvider.GetRequiredService<TService>();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _mainWindow = _mainWindowFactory();

        _mainWindow.ViewModel.ApplyLocalizedContent();

        _mainWindow.ApplyDefaultConfiguration();
        _mainWindow.Activate();
    }
}