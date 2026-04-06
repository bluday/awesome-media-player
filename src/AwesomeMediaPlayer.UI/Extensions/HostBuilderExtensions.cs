using AwesomeMediaPlayer.UI.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using System;

namespace AwesomeMediaPlayer.UI.Extensions;

/// <summary>
/// Provides method extensions for <see cref="IHostBuilder"/> instances.
/// </summary>
public static class HostBuilderExtensions
{
    #region Static methods
    /// <summary>
    /// Registers the specified WinUI 3 app, along with a hosted service for WinUI 3
    /// applications, to the container of the host.
    /// </summary>
    /// <typeparam name="TApp">
    /// The derived type of the app class.
    /// </typeparam>
    /// <param name="source">
    /// The host builder to register the app for.
    /// </param>
    /// <returns>
    /// The current <see cref="IHostBuilder"/> instance.
    /// </returns>
    public static IHostBuilder UseWinUI3Application<TApp>(this IHostBuilder source)
        where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.ConfigureServices(services =>
        {
            services.AddHostedService<WinUI3ApplicationHostedService>();

            services.AddTransient<Application, TApp>();
        });
    }
    #endregion
}