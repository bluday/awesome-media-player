﻿namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : WindowViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public MainWindowViewModel(ResourceLoader resourceLoader)
    {
        _defaultConfiguration = GetDefaultConfiguration(resourceLoader);

        // TODO: Show main view.
    }

    /// <summary>
    /// Gets default configuration presets for this window.
    /// </summary>
    /// <param name="resourceLoader">
    /// An instance of type <see cref="ResourceLoader"> for loading resources, such as titles
    /// and icon paths.
    /// </param>
    /// <returns>
    /// The configuration instance.
    /// </returns>
    public static WindowConfiguration GetDefaultConfiguration(ResourceLoader resourceLoader)
    {
        return new()
        {
            Title                      = resourceLoader.GetString("MainWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(1000, 800),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}