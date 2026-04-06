using AwesomeMediaPlayer.Infrastructure.Extensions;
using AwesomeMediaPlayer.Infrastructure.Localization;
using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeMediaPlayer.Configuration;

/// <summary>
/// Provides a method for configuring and registering client-specific services.
/// </summary>
internal static class ServiceConfiguration
{
    /// <summary>
    /// Registers configured services to the specified service collection.
    /// </summary>
    /// <param name="services">
    /// The service descriptor collection to register all of the configured
    /// client services to.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Throws if <paramref name="services"/> is <c>null</c>.
    /// </exception>
    internal static void Configure(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddLogging(LoggingConfiguration.Configure);

        services.AddMemoryCache();

        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

        services.AddSingleton<ILocalizedStringProvider, LocalizedStringProvider>();

        services.AddTransientWithFactory<MainWindow>();

        services.AddTransient<AboutViewModel>();
        services.AddTransient<CurrentMediaInformationGeneralViewModel>();
        services.AddTransient<HelpViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<MediaLibraryViewModel>();
        services.AddTransient<PreferencesViewModel>();
    }
}