namespace BluDay.AwesomeMediaPlayer.Extensions;

/// <summary>
/// A utility class with method extensions for types in the <see cref="Windows.Graphics"/> namespace.
/// </summary>
public static class GraphicsExtensions
{
    /// <summary>
    /// The translated X value of the given <paramref name="alignment"/> value.
    /// </summary>
    /// <param name="source">
    /// The size of the targeted window or control.
    /// </param>
    /// <param name="alignment">
    /// The alignment value.
    /// </param>
    /// <param name="workArea">
    /// The targeted "work" area of a display.
    /// </param>
    /// <returns>
    /// The translated X value.
    /// </returns>
    public static int GetXFromAlignment(this SizeInt32 source, ContentAlignment alignment, RectInt32 workArea)
    {
        switch (alignment)
        {
            case ContentAlignment.TopCenter:
            case ContentAlignment.MiddleCenter:
            case ContentAlignment.BottomCenter:
                return (workArea.Width - source.Width) / 2;
            case ContentAlignment.TopRight:
            case ContentAlignment.MiddleRight:
            case ContentAlignment.BottomRight:
                return workArea.Width - source.Width;
        }

        return 0;
    }

    /// <summary>
    /// The translated X value of the given <paramref name="alignment"/> value.
    /// </summary>
    /// <returns>
    /// The translated Y value.
    /// </returns>
    /// <inheritdoc cref="GetXFromAlignment(SizeInt32, ContentAlignment, RectInt32)"/>
    public static int GetYFromAlignment(this SizeInt32 source, ContentAlignment alignment, RectInt32 workArea)
    {
        switch (alignment)
        {
            case ContentAlignment.MiddleLeft:
            case ContentAlignment.MiddleCenter:
            case ContentAlignment.MiddleRight:
                return (workArea.Height - source.Height) / 2;
            case ContentAlignment.BottomLeft:
            case ContentAlignment.BottomCenter:
            case ContentAlignment.BottomRight:
                return workArea.Height - source.Height;
        }

        return 0;
    }
}