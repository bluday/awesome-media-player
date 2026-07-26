using Microsoft.UI;
using Microsoft.UI.Windowing;
using System;
using Windows.UI;

namespace AwesomeMediaPlayer.UI.Windowing;

/// <summary>
/// Provides methods for configuring a <see cref="AppWindow"/>.
/// </summary>
public static class AppWindowConfigurator
{
    /// <summary>
    /// Applies dark colors to the native title bar of the specified window.
    /// </summary>
    /// <param name="window">
    /// The window of the title bar to configure.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="window"/> is <see langword="null"/>.
    /// </exception>
    public static void ApplyDarkTitleBarColors(AppWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);

        if (!AppWindowTitleBar.IsCustomizationSupported())
        {
            return;
        }

        AppWindowTitleBar titleBar = window.TitleBar;

        var buttonForegroundColor       = Colors.White;
        var hoverPressedBackgroundColor = Color.FromArgb(0xFF, 0x33, 0x33, 0x33);

        titleBar.ButtonBackgroundColor         = Colors.Transparent;
        titleBar.ButtonForegroundColor         = buttonForegroundColor;
        titleBar.ButtonHoverBackgroundColor    = hoverPressedBackgroundColor;
        titleBar.ButtonHoverForegroundColor    = buttonForegroundColor;
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        titleBar.ButtonPressedBackgroundColor  = hoverPressedBackgroundColor;
        titleBar.ButtonPressedForegroundColor  = buttonForegroundColor;
    }

    /// <summary>
    /// Applies light colors to the native title bar of the specified window.
    /// </summary>
    /// <param name="window">
    /// The window of the title bar to configure.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="window"/> is <see langword="null"/>.
    /// </exception>
    public static void ApplyLightTitleBarColors(AppWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);

        if (!AppWindowTitleBar.IsCustomizationSupported())
        {
            return;
        }

        AppWindowTitleBar titleBar = window.TitleBar;

        var buttonForegroundColor       = Colors.Black;
        var hoverPressedBackgroundColor = Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD);

        titleBar.ButtonBackgroundColor         = Colors.Transparent;
        titleBar.ButtonForegroundColor         = buttonForegroundColor;
        titleBar.ButtonHoverBackgroundColor    = hoverPressedBackgroundColor;
        titleBar.ButtonHoverForegroundColor    = buttonForegroundColor;
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        titleBar.ButtonPressedBackgroundColor  = hoverPressedBackgroundColor;
        titleBar.ButtonPressedForegroundColor  = buttonForegroundColor;
    }
}