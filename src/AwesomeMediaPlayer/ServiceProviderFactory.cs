using AwesomeMediaPlayer.Configuration;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides a method for creating the DI container for the client.
/// </summary>
internal static class ServiceProviderFactory
{
    /// <summary>
    /// Creates a new <see cref="ServiceProvider"/> configured with
    /// the registered services.
    /// </summary>
    /// <returns>
    /// The new <see cref="ServiceProvider"/> instance.
    /// </returns>
    internal static ServiceProvider Create()
    {
        ServiceCollection services = new();

        ServiceConfiguration.Configure(services);

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(serviceProvider);

        return serviceProvider;
    }
}