using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace AwesomeMediaPlayer.Infrastructure.Extensions;

/// <summary>
/// Provides extension methods for registering concrete types and view models in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers a factory delegate for the specified service type that resolves instances using
    /// the <see cref="IServiceProvider"/> at runtime.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type to register a factory for.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the factory with.
    /// </param>
    /// <param name="lifetime">
    /// The service lifetime to apply to the registration.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddFactory<TService>(this IServiceCollection source, ServiceLifetime lifetime)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(source);

        Func<IServiceProvider, Func<TService>> implementationFactory =
            serviceProvider => serviceProvider.GetRequiredService<TService>;

        source.TryAddTransient<TService>();

        source.Add(ServiceDescriptor.Describe(
            typeof(Func<TService>),
            implementationFactory,
            lifetime
        ));

        return source;
    }

    /// <summary>
    /// Registers a factory delegate for the specified service type as a singleton, using the
    /// <see cref="IServiceProvider"/> to resolve instances.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type to register as singleton.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the singleton factory with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddFactoryAsSingleton<TService>(this IServiceCollection source)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddFactory<TService>(ServiceLifetime.Singleton);
    }

    /// <summary>
    /// Registers a factory delegate for the specified service type as transient, using the
    /// <see cref="IServiceProvider"/> to resolve instances.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type to register as transient.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the transient factory with.
    /// </param>
    /// <returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddFactoryAsTransient<TService>(this IServiceCollection source)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddFactory<TService>(ServiceLifetime.Transient);
    }
}