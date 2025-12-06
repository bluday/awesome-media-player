using AwesomeMediaPlayer.Infrastructure.Resources;
using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.ViewModels.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AwesomeMediaPlayer;

/// <summary>
/// Represents the DI (Dependency Injection) container for the client, providing access
/// to the root service provider, a collection of all registered services, and a method
/// to create new service scopes for service resolution.
/// </summary>
internal sealed class Container
{
    private readonly ServiceProvider _rootServiceProvider;

    /// <summary>
    /// Gets the <see cref="ServiceProvider"/> instance for the root scope of the container.
    /// </summary>
    internal IKeyedServiceProvider RootServiceProvider => _rootServiceProvider;

    /// <summary>
    /// Gets a read-only collection of all service descriptors that have been registered
    /// witin the container, providing information about the available services.
    /// </summary>
    internal IReadOnlyCollection<ServiceDescriptor> RegisteredServices { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Container"/> class.
    /// </summary>
    internal Container()
    {
        ServiceCollection services = new();

        ConfigureServices(services);

        _rootServiceProvider = services.BuildServiceProvider();

        RegisteredServices = services.AsReadOnly();

        Ioc.Default.ConfigureServices(_rootServiceProvider);
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

    /// <summary>
    /// Creates a new limited scope for resolving services, allowing for isolated
    /// dependencies within a specific context or operation.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IServiceScope"/> representing the new scope.
    /// </returns>
    internal IServiceScope CreateScope()
    {
        return _rootServiceProvider.CreateScope();
    }
}