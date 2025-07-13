using AwesomeMediaPlayer.ViewModels;
using AwesomeMediaPlayer.Views;
using BluDay.Net.WinUI3.Extensions;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
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

        Window mainWindow = new()
        {
            Content                    = mainView,
            ExtendsContentIntoTitleBar = true,
            Title                      = new ResourceLoader().GetString("General/AppDisplayName"),
            SystemBackdrop             = new MicaBackdrop()
        };

        AppWindow appWindow = mainWindow.AppWindow;

        appWindow.Resize(1600, 1200);

        appWindow.MoveToCenter();

        mainWindow.Activate();
    }

    /// <summary>
    /// Configures the provided logging builder for the client.
    /// </summary>
    /// <param name="logging">
    /// The logging builder instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="logging"/> is <c>null</c>.
    /// </exception>
    public static void ConfigureLogging(ILoggingBuilder logging)
    {
        ArgumentNullException.ThrowIfNull(logging);

        logging
            .AddConsole()
            .AddDebug();

        logging.SetMinimumLevel(LogLevel.Debug);
    }

    /// <summary>
    /// Configures the provided service descriptor collection with core services.
    /// </summary>
    /// <param name="services">
    /// The service descriptor collection.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="services"/> is <c>null</c>.
    /// </exception>
    private void ConfigureServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddLogging(ConfigureLogging);

        services.AddMemoryCache();

        services.AddSingleton<WeakReferenceMessenger>();

        services.AddSingleton<ResourceLoader>();

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
}