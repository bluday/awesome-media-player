using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace AwesomeMediaPlayer.UI.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets the URI for the title bar icon.
    /// </summary>
    [ObservableProperty]
    public partial Uri? IconUri { get; set; }

    /// <summary>
    /// Gets or sets the subtitle for the title bar control.
    /// </summary>
    [ObservableProperty]
    public partial string? Subtitle { get; set; }

    /// <summary>
    /// Gets or sets the title for the title bar control.
    /// </summary>
    [ObservableProperty]
    public partial string? Title { get; set; }
}