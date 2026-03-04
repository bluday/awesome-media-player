using AwesomeMediaPlayer.Infrastructure.Constants;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace AwesomeMediaPlayer.UI.ViewModels;

/// <summary>
/// Represents the base class for a derived window view model.
/// </summary>
public abstract partial class WindowViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets URI of the title bar icon.
    /// </summary>
    [ObservableProperty]
    public partial Uri? IconUri { get; set; } = new(Icons.IconPath);

    /// <summary>
    /// Gets or sets the subtitle for the title bar.
    /// </summary>
    [ObservableProperty]
    public partial string? Subtitle { get; set; } = "Alpha";

    /// <summary>
    /// Gets or sets the title for the title bar.
    /// </summary>
    [ObservableProperty]
    public partial string? Title { get; set; } = "Awesome Media Player";
}