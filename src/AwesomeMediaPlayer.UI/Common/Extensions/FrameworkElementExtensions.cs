using Microsoft.UI.Xaml;
using System;
using Windows.Foundation;
using Windows.Graphics;

namespace AwesomeMediaPlayer.UI.Common.Extensions;

/// <summary>
/// Provides extension methods for <see cref="FrameworkElement"/> instances.
/// </summary>
public static class FrameworkElementExtensions
{
    /// <summary>
    /// Computes the bounding box of the element in screen coordinates and returns it as an integer
    /// rectangle, optionally scaled by the specified factor.
    /// </summary>
    /// <param name="source">
    /// The <see cref="FrameworkElement"/> whose bounding box is to be calculated.
    /// </param>
    /// <param name="scale">
    /// The scale factor to apply to the resulting dimensions. If negative, a default of 1 is used.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// A <see cref="RectInt32"/> representing the scaled bounding box of the element.
    /// </returns>
    public static RectInt32 GetBoundingBox(this FrameworkElement source, double scale)
    {
        ArgumentNullException.ThrowIfNull(source);

        Rect rect = source
            .TransformToVisual(null)
            .TransformBounds(
                new Rect(0, 0, source.ActualWidth, source.ActualHeight)
            );

        scale = scale < 0 ? 1 : scale;

        return new RectInt32(
            (int)(rect.X * scale),
            (int)(rect.Y * scale),
            (int)(rect.Width  * scale),
            (int)(rect.Height * scale)
        );
    }
}