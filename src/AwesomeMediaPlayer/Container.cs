using AwesomeMediaPlayer.Infrastructure.Localization;
using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.ViewModels.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// A wrapper for <see cref="ServiceProvider"/>, providing additional information about the
/// container, such as registered service descriptors, active scopes, and whether the
/// container has been disposed of.
/// </summary>
public sealed partial class Container : IContainer
{
    #region Fields
    private readonly ServiceProvider _rootServiceProvider;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the <see cref="ServiceProvider"/> instance for the root scope of the container.
    /// </summary>
    public IKeyedServiceProvider RootServiceProvider => _rootServiceProvider;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="Container"/> class.
    /// </summary>
    public Container()
    {
        ServiceCollection services = new();

        ConfigureServices(services);

        _rootServiceProvider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(_rootServiceProvider);
    }
    #endregion

    #region Methods
    private static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging.AddConsole();
        logging.AddDebug();

        logging.SetMinimumLevel(LogLevel.Debug);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(ConfigureLogging);

        services.AddSingleton<WeakReferenceMessenger>();

        services.AddMemoryCache();

        services.AddSingleton<ILocalizedStringProvider, LocalizedStringProvider>();

        services.AddTransient<AboutViewModel>();
        services.AddTransient<CurrentMediaInformationGeneralViewModel>();
        services.AddTransient<HelpViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<MediaLibraryViewModel>();
        services.AddTransient<PreferencesViewModel>();

        services.AddTransient<MainWindowViewModel>();

        services.AddTransient<MainViewTitleBarViewModel>();
    }

    /// <summary>
    /// Creates a new limited scope for resolving services, allowing for isolated
    /// dependencies within a specific context or operation.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IServiceScope"/> representing the new scope.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Throws if the current instance has been disposed of.
    /// </exception>
    public IServiceScope CreateScope()
    {
        return _rootServiceProvider.CreateScope();
    }
    #endregion
}