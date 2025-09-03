namespace AwesomeMediaPlayer.Infrastructure.UI;

/// <summary>
/// Specifies the available system backdrop materials that can be applied to a window.
/// </summary>
public enum BackdropKind
{
    /// <summary>
    /// No backdrop material is applied.
    /// </summary>
    None,

    /// <summary>
    /// Applies the default Mica material, which reflects the desktop wallpaper and theme.
    /// </summary>
    Mica,

    /// <summary>
    /// Applies the alternative Mica material, optimized for performance and subtle contrast.
    /// </summary>
    MicaAlt,

    /// <summary>
    /// Applies the Acrylic material, providing a translucent, blurred background effect.
    /// </summary>
    Acrylic
}