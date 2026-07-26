using Microsoft.UI.Xaml;
using System;
using Windows.Foundation;
using Windows.Graphics;

namespace AwesomeMediaPlayer.UI.Extensions;

/// <summary>
/// Provides extension methods for <see cref="FrameworkElement"/> instances.
/// </summary>
public static class FrameworkElementExtensions
{
    #region Constants
    /// <summary>
    /// The default bounding box scale factor.
    /// </summary>
    public const double DefaultBoundingBoxScaleFactor = 1.0;
    #endregion

    #region Static methods
    /// <summary>
    /// Computes the bounding box of the element in screen coordinates and returns
    /// it as an integer rectangle.
    /// <inheritdoc cref="GetBoundingBox(FrameworkElement, double)"/>
    public static RectInt32 GetBoundingBox(this FrameworkElement source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetBoundingBox(DefaultBoundingBoxScaleFactor);
    }

    /// <summary>
    /// Computes the bounding box of the element in screen coordinates and returns
    /// it as an integer rectangle, scaled by the specified factor.
    /// </summary>
    /// <param name="source">
    /// The <see cref="FrameworkElement"/> whose bounding box is to be calculated.
    /// </param>
    /// <param name="scaleFactor">
    /// The scale factor to apply to the resulting dimensions.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
    /// <returns>
    /// A <see cref="RectInt32"/> value representing the scaled bounding box of
    /// the element.
    /// </returns>
    public static RectInt32 GetBoundingBox(this FrameworkElement source, double scaleFactor)
    {
        ArgumentNullException.ThrowIfNull(source);

        Rect transformedRect = source
            .TransformToVisual(null)
            .TransformBounds(new Rect(
                x: 0,
                y: 0,
                source.ActualWidth,
                source.ActualHeight
            ));

        return new(
            (int)transformedRect.X,
            (int)transformedRect.Y,
            (int)(transformedRect.Width  * scaleFactor),
            (int)(transformedRect.Height * scaleFactor)
        );
    }
    #endregion
}