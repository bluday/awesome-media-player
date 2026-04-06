using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeMediaPlayer.Infrastructure.Extensions;

/// <summary>
/// Provides method extensions for <see cref="IServiceCollection"/> instances.
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Static methods
    /// <inheritdoc cref="AddTransientWithFactory{TService, TImplementation}(IServiceCollection)"/>
    public static IServiceCollection AddTransientWithFactory<TImplementation>(
        this IServiceCollection source
    )
        where TImplementation : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddTransientWithFactory<TImplementation, TImplementation>();
    }

    /// <summary>
    /// Registers the specified service as a singleton with a resolvable factory
    /// for the service.
    /// </summary>
    /// <typeparam name="TService">
    /// The type of the service to add.
    /// </typeparam>
    /// <typeparam name="TImplementation">
    /// The type of the implementation to use.
    /// </typeparam>
    /// <param name="source">
    /// The service collection instance.
    /// </param>
    /// <returns>
    /// The current <see cref="IServiceCollection"/> instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Throws if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IServiceCollection AddTransientWithFactory<TService, TImplementation>(
        this IServiceCollection source
    )
        where TService        : class
        where TImplementation : class, TService
    {
        ArgumentNullException.ThrowIfNull(source);

        source.AddTransient<TService, TImplementation>();

        return source.AddSingleton<Func<TService>>(serviceProvider =>
        {
            return () => serviceProvider.GetRequiredService<TService>();
        });
    }
    #endregion
}