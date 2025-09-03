using AwesomeMediaPlayer.Helpers;
using Microsoft.UI.Xaml;
using System;

namespace AwesomeMediaPlayer.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Window"/> class, offering additional
/// functionality related to DPI scaling and window behavior. These helpers are designed
/// to simplify common UI-related tasks in applications using Windows App SDK.
/// </summary>
public static class WindowExtensions
{
    /// <summary>
    /// Gets the decimal value of the DPI scaling factor for the specified <see cref="Window"/>
    /// instance.
    /// </summary>
    /// <param name="source">
    /// The <see cref="Window"/> instance for which to retrieve the DPI scale factor.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// A decimal value representing the window's DPI scale factor relative to standard DPI
    /// (96.0). For instance, 1.5 corresponds to 150% scaling.
    /// </returns>
    public static double GetDpiScaleFactorInDecimal(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return WindowHelper.GetDpiScaleFactorInDecimal(source);
    }
}