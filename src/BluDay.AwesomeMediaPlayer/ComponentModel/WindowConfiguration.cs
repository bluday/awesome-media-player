namespace BluDay.AwesomeMediaPlayer.ComponentModel;

/// <summary>
/// Represents initial configuration for a window.
/// </summary>
public sealed class WindowConfiguration
{
    /// <summary>
    /// Gets a value indicating whether the content extends into the title bar area.
    /// </summary>
    public bool? ExtendsContentIntoTitleBar { get; init; }

    /// <summary>
    /// Gets the app icon path for the title bar.
    /// </summary>
    public string? IconPath { get; init; }

    /// <summary>
    /// Gets the window title.
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// Gets the alignment of the window.
    /// </summary>
    public ContentAlignment? Alignment { get; init; }

    /// <summary>
    /// Gets the size of the window.
    /// </summary>
    public SizeInt32? Size { get; init; }
}