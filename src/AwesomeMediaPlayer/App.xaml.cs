using AwesomeMediaPlayer.Windows;
using BluDay.Net.DependencyInjection;
using BluDay.Net.Extensions;
using BluDay.Net.WinUI3.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private readonly ImplementationProvider<Window> _windowFactory;

    private readonly ILogger _logger;

    private readonly IKeyedServiceProvider _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        _rootServiceProvider = new ServiceCollection()
            .Add(ConfigureServices)
            .BuildServiceProvider();

        _windowFactory = _rootServiceProvider.GetRequiredService<ImplementationProvider<Window>>();
        _logger        = _rootServiceProvider.GetRequiredService<ILogger<App>>();

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
        _windowFactory.GetInstance<MainWindow>().Activate();
    }

    /// <summary>
    /// Configures the provided logging builder for the client.
    /// </summary>
    /// <param name="logging">
    /// The logging builder instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="logging"/> is null.
    /// </exception>
    public static void ConfigureLogging(ILoggingBuilder logging)
    {
        ArgumentNullException.ThrowIfNull(logging);

        logging
            .AddConsole()
            .AddDebug();

        logging
            .SetMinimumLevel(LogLevel.Debug);
    }

    /// <summary>
    /// Configures the provided service descriptor collection with core services.
    /// </summary>
    /// <param name="services">
    /// The service descriptor collection.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="services"/> is null.
    /// </exception>
    private void ConfigureServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddSingleton<App>()
            .AddSingleton<ResourceLoader>();

        services
            .AddViews()
            .AddViewModels()
            .AddWindows();

        services
            .AddSingleton<ImplementationProvider<ObservableObject>>()
            .AddSingleton<ImplementationProvider<Window>>();

        services
            .AddLogging(ConfigureLogging);

        services
            .AddMemoryCache();

        services
            .AddSingleton<WeakReferenceMessenger>();
    }
}