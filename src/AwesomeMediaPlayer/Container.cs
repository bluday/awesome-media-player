using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.ViewModels.Windows;
using AwesomeMediaPlayer.Infrastructure.Resources;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AwesomeMediaPlayer;

/// <summary>
/// Represents the DI (Dependency Injection) container for the application.
/// </summary>
public class Container
{
    private readonly ServiceProvider _rootServiceProvider;

    public ServiceProvider RootServiceProvider => _rootServiceProvider;

    public IReadOnlyList<ServiceDescriptor> RegisteredServices { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Container"/> class.
    /// </summary>
    public Container()
    {
        ServiceCollection services = new();

        ConfigureServices(services);

        _rootServiceProvider = services.BuildServiceProvider();

        RegisteredServices = services.AsReadOnly();
    }

    private static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging.AddConsole();
        logging.AddDebug();

        logging.SetMinimumLevel(LogLevel.Debug);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddLogging(ConfigureLogging);

        services
            .AddSingleton<WeakReferenceMessenger>();

        services
            .AddMemoryCache();

        services
            .AddSingleton<ILocalizedStringProvider, LocalizedStringProvider>();

        services
            .AddTransient<AboutViewModel>()
            .AddTransient<CurrentMediaInformationGeneralViewModel>()
            .AddTransient<HelpViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<MediaLibraryViewModel>()
            .AddTransient<PreferencesViewModel>();

        services
            .AddTransient<MainWindowViewModel>();

        services
            .AddTransient<MainViewTitleBarViewModel>();
    }

    public IServiceScope CreateScope()
    {
        return _rootServiceProvider.CreateScope();
    }
}