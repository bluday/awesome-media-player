using AwesomeMediaPlayer.Data.ViewModels;
using AwesomeMediaPlayer.Data.ViewModels.Windows;
using AwesomeMediaPlayer.Infrastructure.Extensions;
using AwesomeMediaPlayer.Infrastructure.Resources;
using AwesomeMediaPlayer.UI.Views;
using AwesomeMediaPlayer.UI.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides dependency injection container setup for the application.
/// </summary>
public static class Container
{
    /// <summary>
    /// Configures and registers service descriptors required by the application.
    /// </summary>
    /// <param name="services">
    /// The service collection to which services will be added.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="services"/> is <c>null</c>.
    /// </exception>
    public static void ConfigureServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddLogging(Logging.ConfigureLogging);

        services
            .AddSingleton<WeakReferenceMessenger>();

        services
            .AddMemoryCache();

        services
            .AddSingleton<ILocalizedStringProvider, LocalizedStringProvider>();

        services
            .AddFactoryAsSingleton<MainWindow>();

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

        services
            .AddTransient<MainWindowViewModel>();

        services
            .AddTransient<MainViewTitleBarViewModel>();
    }

    /// <summary>
    /// Creates a new DI container instance with pre-configured services.
    /// </summary>
    /// <returns>
    /// The created service provider instance for the root scope of the DI container.
    /// </returns>
    public static ServiceProvider Create()
    {
        ServiceCollection services = new();

        ConfigureServices(services);

        return services.BuildServiceProvider();
    }
}