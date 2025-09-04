using Microsoft.UI.Windowing;
using System;
using Windows.Graphics;

namespace AwesomeMediaPlayer.Infrastructure.Extensions;

/// <summary>
/// Extension methods for <see cref="AppWindow"/> to assist with positioning and resizing.
/// </summary>
public static class AppWindowExtensions
{
    /// <summary>
    /// Gets the center position of the <see cref="AppWindow"/> relative to its current display area.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <returns>
    /// The center position as a <see cref="PointInt32"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static PointInt32 GetCenterPositionForDisplay(this AppWindow source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetCenterPositionForDisplay(source.GetDisplayArea());
    }

    /// <summary>
    /// Gets the center position of the <see cref="AppWindow"/> relative to a specified display area.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <param name="displayArea">
    /// The display area to calculate center position within.
    /// </param>
    /// <returns>
    /// The center position as a <see cref="PointInt32"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> or <paramref name="displayArea"/> is null.
    /// </exception>
    public static PointInt32 GetCenterPositionForDisplay(this AppWindow source, DisplayArea displayArea)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(displayArea);

        SizeInt32 windowSize = source.Size;

        RectInt32 displayWorkArea = displayArea.WorkArea;

        return new(
            (displayWorkArea.Width  - windowSize.Width)  / 2,
            (displayWorkArea.Height - windowSize.Height) / 2
        );
    }

    /// <summary>
    /// Gets the display area where the <see cref="AppWindow"/> is currently located, using the
    /// default fallback.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <returns>
    /// The display area of the window.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static DisplayArea GetDisplayArea(this AppWindow source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetDisplayArea(DisplayAreaFallback.Nearest);
    }

    /// <summary>
    /// Gets the display area where the <see cref="AppWindow"/> is currently located, with a
    /// specified fallback option.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <param name="displayAreaFallback">
    /// The fallback strategy if no direct display is found.
    /// </param>
    /// <returns>
    /// The display area of the window.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static DisplayArea GetDisplayArea(this AppWindow source, DisplayAreaFallback displayAreaFallback)
    {
        ArgumentNullException.ThrowIfNull(source);

        return DisplayArea.GetFromWindowId(source.Id, displayAreaFallback);
    }

    /// <summary>
    /// Moves the <see cref="AppWindow"/> to the center of its current display area.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static void MoveToCenter(this AppWindow source)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.MoveToCenter(source.GetDisplayArea());
    }

    /// <summary>
    /// Moves the <see cref="AppWindow"/> to the center of the specified display area.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <param name="displayArea">
    /// The display area to center the window within.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> or <paramref name="displayArea"/> is null.
    /// </exception>
    public static void MoveToCenter(this AppWindow source, DisplayArea displayArea)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(displayArea);

        source.Move(source.GetCenterPositionForDisplay(displayArea));
    }

    /// <summary>
    /// Resizes the <see cref="AppWindow"/> to the specified width and height.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <param name="width">
    /// The target width in pixels.
    /// </param>
    /// <param name="height">
    /// The target height in pixels.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static void Resize(this AppWindow source, int width, int height)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.Resize(width, height, scaleFactor: null);
    }

    /// <summary>
    /// Resizes the <see cref="AppWindow"/> to the specified dimensions, optionally applying
    /// a scale factor.
    /// </summary>
    /// <param name="source">
    /// The <see cref="AppWindow"/> instance.
    /// </param>
    /// <param name="width">
    /// The target width in pixels.
    /// </param>
    /// <param name="height">
    /// The target height in pixels.
    /// </param>
    /// <param name="scaleFactor">
    /// Optional scale factor to apply to the size.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static void Resize(this AppWindow source, int width, int height, double? scaleFactor)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (scaleFactor.HasValue)
        {
            width  = (int)(width  / scaleFactor);
            height = (int)(height / scaleFactor);
        }

        source.Resize(new SizeInt32(width, height));
    }
}