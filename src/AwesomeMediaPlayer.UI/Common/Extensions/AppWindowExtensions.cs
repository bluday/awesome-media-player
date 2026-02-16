using Microsoft.UI.Windowing;
using System;
using System.Drawing;
using Windows.Graphics;

namespace AwesomeMediaPlayer.UI.Common.Extensions;

/// <summary>
/// Provides extension methods for <see cref="AppWindow"/> instances.
/// </summary>
public static class AppWindowExtensions
{
    /// <summary>
    /// Moves the window to the center of its current display area.
    /// </summary>
    /// <param name="source">
    /// An <see cref="AppWindow"/> instance, representing the targeted window to move.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void MoveToCenter(this AppWindow source)
    {
        source.MoveToCenter(
            DisplayArea.GetFromWindowId(source.Id, DisplayAreaFallback.Primary)
        );
    }

    /// <summary>
    /// Moves the window to the center of the specified display area.
    /// </summary>
    /// <param name="source">
    /// An <see cref="AppWindow"/> instance, representing the targeted window to move.
    /// </param>
    /// <param name="displayArea">
    /// A <see cref="DisplayArea"/> instance, representing the targeted display area.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when any of the parameters are <c>null</c>.
    /// </exception>
    public static void MoveToCenter(this AppWindow source, DisplayArea displayArea)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(displayArea);

        source.Move(new PointInt32(
            (displayArea.WorkArea.Width  - source.Size.Width)  / 2,
            (displayArea.WorkArea.Height - source.Size.Height) / 2
        ));
    }

    /// <summary>
    /// Resizes the window using the specified width and height values.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="AppWindow"/> instance to resize.
    /// </param>
    /// <param name="width">
    /// The new width value, in pixels.
    /// </param>
    /// <param name="height">
    /// The new height value, in pixels.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Resize(this AppWindow source, int width, int height)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.Resize(new SizeInt32(width, height));
    }

    /// <summary>
    /// Resizes the window using the width and height values from the specified
    /// <see cref="Size"/> instance.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="AppWindow"/> instance to resize.
    /// </param>
    /// <param name="size">
    /// A <see cref="Size"/> struct with the new width and height values.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Resize(this AppWindow source, Size size)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.Resize(new SizeInt32(size.Width, size.Height));
    }

    /// <summary>
    /// Restores the window on the desktop from the taskbar.
    /// </summary>
    /// <remarks>
    /// This only works if the window uses a presenter of type <see cref="OverlappedPresenter"/>,
    /// and will short circuit if it uses any other type of presenter.
    /// </remarks>
    /// <param name="source">
    /// The targeted <see cref="AppWindow"/> instance to resize.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Restore(this AppWindow source)
    {
        ArgumentNullException.ThrowIfNull(source);

        (source.Presenter as OverlappedPresenter)?.Restore();
    }
}