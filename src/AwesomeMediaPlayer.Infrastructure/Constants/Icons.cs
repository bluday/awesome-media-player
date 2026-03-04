using System;
using System.IO;

namespace AwesomeMediaPlayer.Infrastructure.Constants;

/// <summary>
/// A collection of constants for icon paths and names.
/// </summary>
public static class Icons
{
    /// <summary>
    /// The absolute icon path as a <see cref="string"/>.
    /// </summary>
    public static readonly string IconPath = Path.Combine(
        AppContext.BaseDirectory, "Assets", "Icon-64.ico"
    );
}