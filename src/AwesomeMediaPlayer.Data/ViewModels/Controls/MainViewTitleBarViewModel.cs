using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.IO;

namespace AwesomeMediaPlayer.Data.ViewModels.Windows;

/// <summary>
/// Represents the view model for the title bar in the main view.
/// </summary>
public sealed partial class MainViewTitleBarViewModel : ObservableObject
{
    /// <summary>
    /// The path to the icon used in the title bar of the main window.
    /// </summary>
    private static readonly string TitleBarIconPath = Path.Combine(
        AppContext.BaseDirectory, "Assets", "Icon-64.ico"
    );

    /// <summary>
    /// Gets the subtitle that is displayed beside the title.
    /// </summary>
    [ObservableProperty]
    public partial string? Subtitle { get; set; }

    /// <summary>
    /// Gets the title.
    /// </summary>
    [ObservableProperty]
    public partial string? Title { get; set; }

    /// <summary>
    /// Gets the icon URI for the title bar.
    /// </summary>
    [ObservableProperty]
    public partial Uri? IconUri { get; set; }

    /// <summary>
    /// Creates a configured view model instance.
    /// </summary>
    /// <returns>
    /// The created view model instance.
    /// </returns>
    public static MainViewTitleBarViewModel Create()
    {
        return new()
        {
            IconUri = new Uri(TitleBarIconPath)
        };
    }
}