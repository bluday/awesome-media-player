#if USES_COMMUNITY_TOOLKIT_MVVM
using CommunityToolkit.Mvvm.DependencyInjection;
#endif
using Microsoft.Extensions.Hosting;
using System;

namespace AwesomeMediaPlayer.UI.Extensions;

/// <summary>
/// Provides method extensions for <see cref="IHost"/> instances.
/// </summary>
public static class HostExtensions
{
    #region Static methods
    #if USES_COMMUNITY_TOOLKIT_MVVM
    /// <summary>
    /// Configures the default <see cref="Ioc"/> instance with the configured
    /// service provider used for the specified <see cref="IHost"/>.
    /// </summary>
    /// <param name="source">
    /// The target object.
    /// </param>
    /// <returns>
    /// The specified <see cref="IHost"/> to enable chaining.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IHost ConfigureCommunityToolkitIoc(this IHost source)
    {
        ArgumentNullException.ThrowIfNull(source);

        Ioc.Default.ConfigureServices(source.Services);

        return source;
    }
    #endif
    #endregion
}