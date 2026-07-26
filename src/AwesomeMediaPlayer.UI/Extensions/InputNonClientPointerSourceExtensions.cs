using Microsoft.UI.Input;
using System;
using System.Collections.Generic;
using Windows.Graphics;

namespace AwesomeMediaPlayer.UI.Extensions;

/// <summary>
/// Provides extension methods for <see cref="InputNonClientPointerSource"/>
/// instances.
/// </summary>
public static class InputNonClientPointerSourceExtensions
{
    /// <summary>
    /// Clears and sets the specified rects for the specified region in the
    /// non-client area of the window.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="InputNonClientPointerSource"/> instance.
    /// </param>
    /// <param name="region">
    /// The region kind.
    /// </param>
    /// <param name="rects">
    /// The calculated rectangles to set for the specified region.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> or <paramref name="rects"/>
    /// is <see langword="null"/>.
    /// </exception>
    public static void ReplaceRegionRects(
        this InputNonClientPointerSource source,
        NonClientRegionKind              region,
        IEnumerable<RectInt32>           rects)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(rects);

        source.ClearRegionRects(region);
        source.SetRegionRects(region, [.. rects]);
    }
}