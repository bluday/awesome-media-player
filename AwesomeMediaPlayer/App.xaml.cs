using AwesomeMediaPlayer.Data.ViewModels;
using AwesomeMediaPlayer.Views;
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
    private readonly IKeyedServiceProvider _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        ServiceCollection services = new();

        ConfigureServices(services);

        _rootServiceProvider = services.BuildServiceProvider();

        InitializeComponent();
    }

    private static void ConfigureLogging(ILoggingBuilder logging)
    {
        ArgumentNullException.ThrowIfNull(logging);

        logging
            .AddConsole()
            .AddDebug();

        logging
            .SetMinimumLevel(LogLevel.Debug);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddLogging(ConfigureLogging);

        services
            .AddSingleton<WeakReferenceMessenger>();

        services
            .AddMemoryCache();

        services
            .AddSingleton<ResourceLoader>();

        services
            .AddTransient<AboutView>()
            .AddTransient<CurrentMediaInformationGeneralView>()
            .AddTransient<HelpView>()
            .AddTransient<MainView>()
            .AddTransient<MediaLibraryView>()
            .AddTransient<PreferencesView>();

        services
            .AddTransient<AboutViewModel>()
            .AddTransient<CurrentMediaInformationGeneralViewModel>()
            .AddTransient<HelpViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<MediaLibraryViewModel>()
            .AddTransient<PreferencesViewModel>();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        var mainView      = _rootServiceProvider.GetRequiredService<MainView>();
        var mainViewModel = _rootServiceProvider.GetRequiredService<MainViewModel>();

        mainView.DataContext = mainViewModel;

        Window mainWindow = new() { Content = mainView };

        mainView.ConfigureWindow(mainWindow);

        mainWindow.Activate();
    }
}