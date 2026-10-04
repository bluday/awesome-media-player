using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.Views;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.DependencyInjection;

namespace AwesomeMediaPlayer.Configuration;

/// <summary>
/// Provides a method for registering configured services to DI container.
/// </summary>
internal static class ServiceConfiguration
{
    private static void Configure(IServiceCollection services)
    {
        services.AddLogging(LoggingConfiguration.Configure);

        services.AddMemoryCache();

        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

        services
            .AddTransient<AboutView>()
            .AddTransient<AboutViewModel>()
            .AddTransient<CurrentMediaInformationGeneralView>()
            .AddTransient<CurrentMediaInformationGeneralViewModel>()
            .AddTransient<HelpView>()
            .AddTransient<HelpViewModel>()
            .AddTransient<MainWindow>()
            .AddTransient<MainWindowViewModel>()
            .AddTransient<MediaLibraryView>()
            .AddTransient<MediaLibraryViewModel>()
            .AddTransient<PreferencesView>()
            .AddTransient<PreferencesViewModel>();
    }

    /// <summary>
    /// Builds a new <see cref="ServiceProvider"/> with all application
    /// services registered.
    /// </summary>
    /// <returns>
    /// The configured <see cref="ServiceProvider"/> instance.
    /// </returns>
    public static ServiceProvider BuildServiceProvider()
    {
        ServiceCollection services = new();

        Configure(services);

        return services.BuildServiceProvider();
    }
}