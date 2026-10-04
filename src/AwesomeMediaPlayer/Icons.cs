using System;
using System.IO;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides icon paths for the application.
/// </summary>
public static class Icons
{
    private static readonly DirectoryInfo IconsDirectory = new(
        Path.Combine(AppContext.BaseDirectory, "Assets", "Icons")
    );

    private static readonly DirectoryInfo WindowIconsDirectory = new(
        Path.Combine(IconsDirectory.FullName, "Window")
    );

    /// <summary>
    /// The window icon.
    /// </summary>
    public static readonly FileInfo WindowIcon = new(
        Path.Combine(WindowIconsDirectory.FullName, "icon.ico")
    );
}