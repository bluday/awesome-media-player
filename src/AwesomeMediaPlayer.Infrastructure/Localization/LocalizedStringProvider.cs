using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace AwesomeMediaPlayer.Infrastructure.Localization;

/// <summary>
/// Repesents a provider for localized string resources used within the application.
/// </summary>
public sealed class LocalizedStringProvider : ILocalizedStringProvider
{
    private ResourceLoader _resourceLoader = new();

    /// <summary>
    /// Gets the localized string for the specified key.
    /// </summary>
    /// <param name="key">
    /// The key for the desired localized string.
    /// </param>
    /// <returns>
    /// The localized string corresponding to the provided key.
    /// </returns>
    public string GetString(string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        return _resourceLoader.GetString(key);
    }
}