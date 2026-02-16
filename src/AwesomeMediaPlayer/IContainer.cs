using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// A wrapper for <see cref="ServiceProvider"/>, providing additional information about the
/// container, such as registered service descriptors, active scopes, and whether the
/// container has been disposed of.
/// </summary>
public interface IContainer
{
    #region Properties
    /// <summary>
    /// Gets the <see cref="ServiceProvider"/> instance for the root scope of the container.
    /// </summary>
    IKeyedServiceProvider RootServiceProvider { get; }
    #endregion

    #region Methods
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
    IServiceScope CreateScope();
    #endregion
}