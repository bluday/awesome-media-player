using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using Windows.Win32;
using Windows.Win32.Foundation;
using WinRT.Interop;

namespace AwesomeMediaPlayer.UI.Common.Extensions;

/// <summary>
/// Provides extension methods for <see cref="Window"/> instances.
/// </summary>
public static class WindowExtensions
{
    #region Constants
    /// <summary>
    /// The standard or user-default screen DPI value.
    /// </summary>
    public const int DEFAULT_DPI_SCALE = 96;
    #endregion

    #region Methods
    /// <summary>
    /// Focuses on the window programmatically.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Focus(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.Content?.Focus(FocusState.Programmatic);
    }

    /// <summary>
    /// Focuses on the window using the specified <see cref="FocusState"/> value.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <param name="focusState">
    /// Describes how the content of the window obtained focus.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Focus(this Window source, FocusState focusState)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.Content?.Focus(focusState);
    }

    /// <summary>
    /// Gets the current DPI scale factor for the window.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static double GetCurrentDpiScaleFactor(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        uint value = PInvoke.GetDpiForWindow((HWND)WindowNative.GetWindowHandle(source));

        return (double)value / DEFAULT_DPI_SCALE;
    }

    /// <summary>
    /// Restores the window on the desktop.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Restore(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        (source.AppWindow.Presenter as OverlappedPresenter)?.Restore();
    }
    #endregion
}