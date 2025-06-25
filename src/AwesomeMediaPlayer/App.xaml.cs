using AwesomeMediaPlayer.Windows;
using BluDay.Net.DependencyInjection;
using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private readonly Lazy<ImplementationProvider<Window>> _windowFactory;

    private readonly Lazy<ILogger> _logger;

    private readonly IKeyedServiceProvider _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        _rootServiceProvider = new ServiceCollection()
            .AddLogging(ConfigureLogging)
            .Add(ConfigureServices)
            .BuildServiceProvider();

        _windowFactory = new Lazy<ImplementationProvider<Window>>(
            () => _rootServiceProvider.GetRequiredService<ImplementationProvider<Window>>()
        );

        _logger = new Lazy<ILogger>(
            () => _rootServiceProvider.GetRequiredService<ILogger<App>>()
        );

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
        _windowFactory.Value.GetInstance<MainWindow>().Activate();
    }
}