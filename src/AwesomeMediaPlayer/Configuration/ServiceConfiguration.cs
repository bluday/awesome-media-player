using AwesomeMediaPlayer.Infrastructure.Extensions;
using AwesomeMediaPlayer.Infrastructure.Localization;
using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeMediaPlayer.Configuration;

/// <summary>
/// Provides a method for configuring and registering services.
/// </summary>
internal static class ServiceConfiguration
{
    /// <summary>
    /// Registers configured services to the specified service collection.
    /// </summary>
    /// <param name="services">
    /// The service descriptor collection to configure.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="services"/> is <c>null</c>.
    /// </exception>
    internal static void Configure(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddLogging(LoggingConfiguration.Configure);

        services.AddMemoryCache();

        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

        services.AddSingleton<ILocalizedStringProvider, LocalizedStringProvider>();

        services.AddTransientWithFactory<MainWindow>();

        services
            .AddTransient<AboutViewModel>()
            .AddTransient<CurrentMediaInformationGeneralViewModel>()
            .AddTransient<HelpViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<MainWindowViewModel>()
            .AddTransient<MediaLibraryViewModel>()
            .AddTransient<PreferencesViewModel>();
    }
}