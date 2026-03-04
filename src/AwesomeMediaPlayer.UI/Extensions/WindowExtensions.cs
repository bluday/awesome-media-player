using Microsoft.UI.Input;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using Windows.Win32;
using Windows.Win32.Foundation;
using WinRT.Interop;

namespace AwesomeMediaPlayer.UI.Infrastructure.Extensions;

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
    /// Thrown if <paramref name="source"/> is <c>null</c>.
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
    /// Thrown if <paramref name="source"/> is <c>null</c>.
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
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static double GetCurrentDpiScaleFactor(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        uint value = PInvoke.GetDpiForWindow((HWND)WindowNative.GetWindowHandle(source));

        return (double)value / DEFAULT_DPI_SCALE;
    }

    /// <summary>
    /// Retrieves the <see cref="DisplayArea"/> for the specified <see cref="Window"/>.
    /// </summary>
    /// <remarks>
    /// A convenient shortcut method for retrieving the display area.
    /// </remarks>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static DisplayArea GetDisplayArea(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return GetDisplayArea(source, DisplayAreaFallback.None);
    }

    /// <summary>
    /// Retrieves the <see cref="DisplayArea"/> for the specified <see cref="Window"/>.
    /// </summary>
    /// <remarks>
    /// A convenient shortcut method for retrieving the display area.
    /// </remarks>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <param name="displayAreaFallback">
    /// The fallback <see cref="DisplayArea"/> to use if the window has no associated
    /// display area.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static DisplayArea GetDisplayArea(this Window source, DisplayAreaFallback displayAreaFallback)
    {
        ArgumentNullException.ThrowIfNull(source);

        return DisplayArea.GetFromWindowId(source.AppWindow.Id, displayAreaFallback);
    }

    /// <summary>
    /// Retrieves the <see cref="InputNonClientPointerSource"/> for the specified
    /// <see cref="Window"/>.
    /// </summary>
    /// <remarks>
    /// A convenient shortcut method for retrieving the display area.
    /// </remarks>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static InputNonClientPointerSource GetInputNonClientPointerSource(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return InputNonClientPointerSource.GetForWindowId(source.AppWindow.Id);
    }

    /// <summary>
    /// Restores the window on the desktop.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="Window"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static void Restore(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        (source.AppWindow.Presenter as OverlappedPresenter)?.Restore();
    }
    #endregion
}