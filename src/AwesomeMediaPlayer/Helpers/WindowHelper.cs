using Microsoft.UI.Xaml;
using System;
using WinRT.Interop;

namespace AwesomeMediaPlayer.Helpers;

/// <summary>
/// Provides utility methods and constants for working with <see cref="Window"/> instances.
/// </summary>
public static class WindowHelper
{
    /// <summary>
    /// The standard DPI (dots per inch) value used for 1:1 scaling on most displays. Commonly
    /// used as a baseline for DPI-aware calculations.
    /// </summary>
    public const double STANDARD_DPI = 96.0;

    /// <summary>
    /// Calculates the DPI scaling factor for the specified window as a decimal value, relative
    /// to the standard DPI baseline (96.0). Useful for determining how UI elements should be
    /// scaled on high-DPI displays.
    /// </summary>
    /// <param name="source">
    /// The <see cref="Window"/> instance for which to determine the DPI scaling factor.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    /// <returns>
    /// A decimal value representing the DPI scale factor. For example, a return value of 1.25
    /// indicates a 125% scale relative to standard DPI.
    /// </returns>
    public static double GetDpiScaleFactorInDecimal(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return NativeWindowHelper.GetDpiForWindow(WindowNative.GetWindowHandle(source));
    }
}