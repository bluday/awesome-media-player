namespace AwesomeMediaPlayer.Infrastructure.Localization;

/// <summary>
/// Defines a contract for providing localized string resources.
/// </summary>
public interface ILocalizedStringProvider
{
    /// <summary>
    /// Gets the localized string for the specified key.
    /// </summary>
    /// <param name="key">
    /// The key for the desired localized string.
    /// </param>
    /// <returns>
    /// The localized string corresponding to the provided key.
    /// </returns>
    string GetString(string key);
}